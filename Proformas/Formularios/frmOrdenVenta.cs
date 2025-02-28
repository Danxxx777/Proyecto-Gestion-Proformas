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
            //CargarDetalleProformas();
            //cmbClientes_SelectedIndexChanged();
            //cmbProformas.SelectedIndexChanged += cmbClientes_SelectedIndexChanged;

        }

        private void frmOrdenVenta_Load(object sender, EventArgs e)
        {
            dgvDetalleProforma.CellValueChanged += dgvDetalle_CellValueChanged;
            CargarProformasEnComboBox();
            cmbProformas.SelectedIndexChanged += cmbProformas_SelectedIndexChanged;

        }
        private void cmbProformas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProformas.SelectedIndex != -1 && cmbProformas.SelectedValue != null)
            {
                if (int.TryParse(cmbProformas.SelectedValue.ToString(), out int idProforma))
                {
                    MessageBox.Show($"Seleccionaste la ProformaID: {idProforma}", "Debug");
                    CargarDetalleProforma(idProforma);
                }
                else
                {
                    MessageBox.Show("Error: No se pudo convertir el valor seleccionado en un ID válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                            cmbProformas.DataSource = null;
                            MessageBox.Show("⚠ No se encontró ClienteID para esta cédula.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    string queryProformas = "SELECT ProformaID FROM Proformas WHERE ClienteID = @ClienteID";
                    using (SqlCommand cmdProformas = new SqlCommand(queryProformas, conn))
                    {
                        cmdProformas.Parameters.AddWithValue("@ClienteID", clienteID);
                        SqlDataAdapter da = new SqlDataAdapter(cmdProformas);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            cmbProformas.DataSource = dt;
                            cmbProformas.DisplayMember = "ProformaID";
                            cmbProformas.ValueMember = "ProformaID";
                            cmbProformas.SelectedIndex = -1; // No seleccionar nada por defecto
                        }
                        else
                        {
                            cmbProformas.DataSource = null;
                            MessageBox.Show("⚠ El cliente no tiene proformas registradas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al cargar proformas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private async Task CargarDetalleProforma(int idProforma)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();

                    // Depuración: Mostrar el ID de la Proforma que se está buscando.
                    MessageBox.Show($"🔍 Buscando detalles para ProformaID: {idProforma}", "Depuración");

                    string query = @"
                SELECT 
                    dp.DetalleID,
                    dp.ProformaID,
                    dp.ProductoID,
                    p.Nombre AS Producto, 
                    dp.Cantidad, 
                    dp.PrecioUnitario, 
                    dp.Descuento,
                    dp.Total AS Subtotal 
                FROM DetalleProforma dp
                LEFT JOIN Productos p ON dp.ProductoID = p.ProductoID
                WHERE dp.ProformaID = @idProforma";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idProforma", idProforma);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Depuración: Verificar si la consulta devolvió registros
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show($"✅ Se encontraron {dt.Rows.Count} registros de detalles.", "Depuración");
                            dgvDetalleProforma.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show($"⚠ No hay detalles para la Proforma {idProforma}.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvDetalleProforma.DataSource = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Error al cargar los detalles de la proforma: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
        private void CargarProformasPorCliente(int idCliente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ProformaID FROM Proformas WHERE ClienteID = @idCliente";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@idCliente", idCliente);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbProformas.DataSource = dt;
                    cmbProformas.DisplayMember = "ProformaID"; // Mostrar los IDs en el ComboBox
                    cmbProformas.ValueMember = "ProformaID"; // Guardar el ID real
                    cmbProformas.SelectedIndex = -1; // No seleccionar nada al inicio
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar proformas del cliente: " + ex.Message);
                }
            }
        }


       
          

        
        private void CargarProformasEnComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ProformaID FROM Proformas";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Agregar una fila vacía al DataTable para la opción "Selecciona una opción"
                    DataRow filaVacia = dt.NewRow();
                    filaVacia["ProformaID"] = DBNull.Value;  // O un valor como 0 si no permite nulos
                    dt.Rows.InsertAt(filaVacia, 0);  // Insertar al inicio

                    // Asignar DataSource al ComboBox
                    cmbProformas.DataSource = dt;
                    cmbProformas.DisplayMember = "ProformaID";
                    cmbProformas.ValueMember = "ProformaID";
                    cmbProformas.SelectedIndex = 0; // Seleccionar la opción vacía al inicio
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar proformas: " + ex.Message);
                }
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
