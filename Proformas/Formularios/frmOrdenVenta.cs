using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Proformas.Formularios
{
    public partial class frmOrdenVenta : Form
    {
        private Conexion conexion = new Conexion();
        private string connectionString = "Data Source=DESKTOP-VK5KHQR;Initial Catalog=proformas2.0;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        
        public frmOrdenVenta()
        {
            InitializeComponent();
            this.Load += frmOrdenVenta_Load;
           // CargarClientes();
            CargarDetalleProformas();
            //cmbClientes_SelectedIndexChanged();
            //cmbProformas.SelectedIndexChanged += cmbClientes_SelectedIndexChanged;

        }

        private void frmOrdenVenta_Load(object sender, EventArgs e)
        {
            dgvDetalleProforma.CellValueChanged += dgvDetalle_CellValueChanged;
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtCedula.Text.Trim();
            if (texto.Length == 10 && EsNumerico(texto))
            {
                BuscarClientePorCedula();
            }
            else
            {
                MessageBox.Show("Ingrese una cédula válida (10 dígitos numéricos).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarCampos();
            }
        }
        private void LimpiarCampos()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtEstado1.Clear();
            cmbProformas.Items.Clear(); // Limpiar el ComboBox de proformas
            dgvDetalleProforma.DataSource = null; // Limpiar el DataGridView de detalles
            txtTotal.Clear();
        }

        private bool EsNumerico(string texto)
        {
            return long.TryParse(texto, out _);
        }

        private void pbxCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void BuscarClientePorCedula()
        {
            string cedula = txtCedula.Text.Trim();
            string query = "SELECT Nombre, Correo, FechaRegistro, Estado FROM Clientes WHERE NumeroIdentificacion = @cedula";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion.ConnectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cedula", cedula);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                txtCedula.Text = cedula;
                                txtNombre.Text = reader["Nombre"].ToString();
                                txtCorreo.Text = reader["Correo"].ToString();
                                txtTelefono.Text = Convert.ToDateTime(reader["FechaRegistro"]).ToString("yyyy-MM-dd");
                                txtEstado1.Text = reader["Estado"].ToString();

                                await CargarProformasAsync(cedula);
                            }
                            else
                            {
                                LimpiarCampos();
                                MessageBox.Show("No se encontraron clientes con esta cédula.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarProformasAsync(string cedula)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conexion.ConnectionString))
                {
                    await conn.OpenAsync();
                    string queryClienteID = "SELECT ClienteID FROM Clientes WHERE NumeroIdentificacion = @cedula";
                    int clienteID = -1;

                    using (SqlCommand cmdCliente = new SqlCommand(queryClienteID, conn))
                    {
                        cmdCliente.Parameters.AddWithValue("@cedula", cedula);
                        object result = await cmdCliente.ExecuteScalarAsync();

                        if (result != null)
                        {
                            clienteID = Convert.ToInt32(result);
                        }
                        else
                        {
                            cmbProformas.Items.Clear();
                            MessageBox.Show("No se encontró ClienteID para esta cédula.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    string queryProformas = "SELECT ProformaID FROM Proformas WHERE ClienteID = @ClienteID";
                    using (SqlCommand cmdProformas = new SqlCommand(queryProformas, conn))
                    {
                        cmdProformas.Parameters.AddWithValue("@ClienteID", clienteID);
                        using (SqlDataReader reader = await cmdProformas.ExecuteReaderAsync())
                        {
                            cmbProformas.Items.Clear();
                            while (await reader.ReadAsync())
                            {
                                cmbProformas.Items.Add(reader["ProformaID"].ToString());
                            }

                            if (cmbProformas.Items.Count == 0)
                            {
                                MessageBox.Show("El cliente no tiene proformas registradas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proformas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarDetalleProforma(int proformaID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conexion.ConnectionString))
                {
                    await conn.OpenAsync();

                    string query = @"SELECT 
                                dp.ProductoID, 
                                p.Nombre AS Producto,
                                dp.Cantidad, 
                                dp.PrecioUnitario, 
                                dp.Descuento, 
                                dp.Total 
                             FROM DetalleProforma dp
                             INNER JOIN Productos p ON dp.ProductoID = p.ProductoID
                             WHERE dp.ProformaID = @ProformaID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProformaID", proformaID);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvDetalleProforma.DataSource = dt;

                            if (dgvDetalleProforma.Columns.Contains("Cantidad"))
                            {
                                dgvDetalleProforma.Columns["Cantidad"].ReadOnly = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el detalle de la proforma: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbProformas.SelectedItem != null && int.TryParse(cmbProformas.SelectedItem.ToString(), out int proformaID))
            {
                await CargarDetalleProforma(proformaID);

                if (dgvDetalleProforma.Columns.Contains("Cantidad"))
                {
                    dgvDetalleProforma.Columns["Cantidad"].ReadOnly = false;
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una proforma antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDetalleProforma.Columns[e.ColumnIndex].Name == "Cantidad")
            {
                DataGridViewRow row = dgvDetalleProforma.Rows[e.RowIndex];
                if (row.Cells["Cantidad"].Value != null && int.TryParse(row.Cells["Cantidad"].Value.ToString(), out int cantidad))
                {
                    decimal precioUnitario = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value);
                    decimal descuento = Convert.ToDecimal(row.Cells["Descuento"].Value);
                    decimal total = (cantidad * precioUnitario) - descuento;

                    row.Cells["Total"].Value = total;
                    CalcularTotalVenta();
                }
            }
        }

        private void CalcularTotalVenta()
        {
            decimal totalVenta = dgvDetalleProforma.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Cells["Total"].Value != null)
                .Sum(row => Convert.ToDecimal(row.Cells["Total"].Value));

            txtTotal.Text = totalVenta.ToString("0.00");
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }
        //private void CargarClientes()
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            string query = "SELECT ProformaID,ClienteID,FechaVencimiento,FechaCotizacion,TotalProforma,Estatus,VendedorID  FROM Proformas";
        //            SqlDataAdapter da = new SqlDataAdapter(query, conn);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);

        //            cmbProformas.DataSource = dt;
        //            cmbProformas.DisplayMember = "nombre";  // Mostrar el nombre del cliente
        //            cmbProformas.ValueMember = "id_cliente"; // Guardar el ID del cliente
        //            cmbProformas.SelectedIndex = -1; // No seleccionar ninguno por defecto
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error al cargar clientes: " + ex.Message);
        //        }
        //    }
        //}

        private void CargarDetalleProformas()
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //try
                //{
                //    conn.Open();
                //    string query = "SELECT id_proforma, id_cliente, id_sucursal, fecha, total, estado FROM Proformas WHERE id_cliente = @idCliente";
                //    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                //    da.SelectCommand.Parameters.AddWithValue("@idCliente", idCliente);
                //    DataTable dt = new DataTable();
                //    da.Fill(dt);
                //    dgvDetalleProforma.DataSource = dt;
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Error al filtrar proformas: " + ex.Message);
                //}
                string query = "SELECT ProformaID,ClienteID,FechaVencimiento,FechaCotizacion,TotalProforma,Estatus,VendedorID  FROM Proformas";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDetalleProforma.DataSource = dt;
            }
          

        }
        //private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbProformas.SelectedIndex != -1) // Asegurar que se ha seleccionado un cliente
        //    {
        //        int idCliente = Convert.ToInt32(cmbProformas.SelectedValue);
        //        CargarDetalleProformas(idCliente);
        //    }
        //}

        //private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbClientes.SelectedIndex == -1) // Si no hay selección, mostrar todas las proformas
        //    {
        //        CargarProformas();
        //    }
        //    else
        //    {
        //        int idCliente = Convert.ToInt32(cmbClientes.SelectedValue);
        //        FiltrarProformasPorCliente(idCliente);
        //    }
        //}


    }
}
