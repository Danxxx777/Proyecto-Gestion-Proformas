using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Proformas.Formularios
{
    public partial class frmOrdenVenta : Form
    {
        private Conexion conexion = new Conexion();
        private string connectionString = "Data Source=DESKTOP-VK5KHQR;Initial Catalog=BaseAct;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";


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
            //CargarProformasEnComboBox();
            cmbProformas.SelectedIndexChanged += cmbProformas_SelectedIndexChanged;
            CargarEstados();
            cmbEstado.SelectedIndexChanged += cmbEstado_SelectedIndexChanged;


        }
        private void cmbProformas_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbProformas.SelectedIndex != -1 && cmbProformas.SelectedValue != null)
            {
                object selectedValue = cmbProformas.SelectedValue;

                // Si el valor seleccionado es un DataRowView, extraer el ProformaID
                if (selectedValue is DataRowView rowView)
                {
                    selectedValue = rowView["ProformaID"];
                }

                // Evitar errores con DBNull o la opción vacía (-1)
                if (selectedValue == DBNull.Value || selectedValue.ToString() == "-1")
                {
                    return; // No hacer nada si el valor no es válido
                }

                // Intentar convertir el valor a entero y cargar el detalle de la proforma
                if (int.TryParse(selectedValue.ToString(), out int idProforma))
                {
                    cmbProformas.SelectedIndexChanged -= cmbProformas_SelectedIndexChanged; // Desactivar evento
                    CargarDetalleProforma(idProforma); // ✅ Carga directo sin mensajes
                    cmbProformas.SelectedIndexChanged += cmbProformas_SelectedIndexChanged; // Reactivar evento
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
            Application.Exit();
        }

        private async Task BuscarClientePorCedula()
        {
            string cedula = txtCedula.Text.Trim();
            string query = "SELECT ClienteID, Nombre, Correo, FechaRegistro, Estado FROM Clientes WHERE NumeroIdentificacion = @cedula";

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
                                int clienteID = reader.GetInt32(0); // Obtener ClienteID como entero
                                txtCedula.Text = cedula;
                                txtNombre.Text = reader["Nombre"].ToString();
                                txtCorreo.Text = reader["Correo"].ToString();
                                txtTelefono.Text = Convert.ToDateTime(reader["FechaRegistro"]).ToString("yyyy-MM-dd");
                                txtEstado1.Text = reader["Estado"].ToString();

                                // ✅ Pasar clienteID en lugar de cedula (error corregido)
                                await CargarProformasAsync(clienteID);
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

        private void CargarEstados()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Aprobado");
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.SelectedIndex = -1; // Para que no seleccione nada por defecto
        }
        private async Task CargarEstadoProforma(int idProforma)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();

                    string query = "SELECT Estatus FROM Proformas WHERE ProformaID = @idProforma";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idProforma", idProforma);
                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null)
                        {
                            string estado = result.ToString();
                            cmbEstado.SelectedItem = estado; // Seleccionar el estado actual
                        }
                        else
                        {
                            cmbEstado.SelectedIndex = -1; // Si no hay estado, dejar vacío
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar el estado de la proforma: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //private async Task CargarDetalleProforma(int idProforma)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            await conn.OpenAsync();

        //            string query = @"
        //    SELECT 
        //        dp.DetalleID,
        //        dp.ProformaID,
        //        dp.ProductoID,
        //        p.Nombre AS Producto, 
        //        dp.Cantidad, 
        //        dp.PrecioUnitario, 
        //        dp.Descuento,
        //        dp.Total AS Subtotal 
        //    FROM DetalleProforma dp
        //    LEFT JOIN Productos p ON dp.ProductoID = p.ProductoID
        //    WHERE dp.ProformaID = @idProforma";

        //            using (SqlCommand cmd = new SqlCommand(query, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@idProforma", idProforma);
        //                SqlDataAdapter da = new SqlDataAdapter(cmd);
        //                DataTable dt = new DataTable();
        //                da.Fill(dt);

        //                if (dt.Rows.Count > 0)
        //                {
        //                    dgvDetalleProforma.DataSource = dt;
        //                }
        //                else
        //                {
        //                    dgvDetalleProforma.DataSource = null;
        //                    MessageBox.Show($"⚠ No hay detalles para la Proforma {idProforma}.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                }
        //            }

        //            await CargarEstadoProforma(idProforma); // 🔹 Cargar estado después de cargar los detalles
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"❌ Error al cargar los detalles de la proforma: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}
        private async void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEstado.SelectedItem != null && cmbProformas.SelectedValue != null)
            {
                if (int.TryParse(cmbProformas.SelectedValue.ToString(), out int idProforma))
                {
                    string nuevoEstado = cmbEstado.SelectedItem.ToString();

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            await conn.OpenAsync();

                            string query = "UPDATE Proformas SET Estatus = @estatus WHERE ProformaID = @idProforma";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@estatus", nuevoEstado);
                                cmd.Parameters.AddWithValue("@idProforma", idProforma);

                                int filasAfectadas = await cmd.ExecuteNonQueryAsync();
                                if (filasAfectadas > 0)
                                {
                                    MessageBox.Show("✅ Estado actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("⚠ No se pudo actualizar el estado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"❌ Error al actualizar el estado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private async Task CargarProformasAsync(int clienteID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conexion.ConnectionString))
                {
                    await conn.OpenAsync();

                    string queryProformas = "SELECT ProformaID FROM Proformas WHERE ClienteID = @ClienteID";
                    using (SqlCommand cmdProformas = new SqlCommand(queryProformas, conn))
                    {
                        cmdProformas.Parameters.AddWithValue("@ClienteID", clienteID);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmdProformas))
                        {
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
                                MessageBox.Show("⚠ El cliente no tiene proformas registradas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cmbProformas.DataSource = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al cargar proformas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        private async Task CargarDetalleProforma(int idProforma)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();

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

                        // Cargar datos en el DataGridView sin mostrar mensajes
                        dgvDetalleProforma.DataSource = dt.Rows.Count > 0 ? dt : null;
                    }
                }
                catch (Exception ex)
                {
                    // Si necesitas loggear el error sin mostrar un MessageBox, puedes escribirlo en la consola.
                    Console.WriteLine("Error al cargar los detalles de la proforma: " + ex.Message);
                }
            }
        }






        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            //if (cmbProformas.SelectedItem == null || !int.TryParse(cmbProformas.SelectedValue.ToString(), out int idProforma))
            //{
            //    MessageBox.Show("Por favor, seleccione una proforma antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    try
            //    {
            //        await conn.OpenAsync();
            //        using (SqlTransaction transaction = conn.BeginTransaction()) // Se usa una transacción para evitar datos inconsistentes
            //        {
            //            try
            //            {
            //                // 🔹 1. Guardar cambios en DetalleProforma
            //                foreach (DataGridViewRow row in dgvDetalleProforma.Rows)
            //                {
            //                    if (row.Cells["ProductoID"].Value == null) continue; // Evitar filas vacías

            //                    int productoID = Convert.ToInt32(row.Cells["ProductoID"].Value);
            //                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
            //                    decimal precioUnitario = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value);
            //                    decimal descuento = Convert.ToDecimal(row.Cells["Descuento"].Value);
            //                    decimal total = Convert.ToDecimal(row.Cells["Total"].Value);

            //                    string queryUpdateDetalle = @"
            //                UPDATE DetalleProforma
            //                SET Cantidad = @Cantidad, PrecioUnitario = @PrecioUnitario, 
            //                    Descuento = @Descuento, Total = @Total
            //                WHERE ProformaID = @ProformaID AND ProductoID = @ProductoID";

            //                    using (SqlCommand cmd = new SqlCommand(queryUpdateDetalle, conn, transaction))
            //                    {
            //                        cmd.Parameters.AddWithValue("@Cantidad", cantidad);
            //                        cmd.Parameters.AddWithValue("@PrecioUnitario", precioUnitario);
            //                        cmd.Parameters.AddWithValue("@Descuento", descuento);
            //                        cmd.Parameters.AddWithValue("@Total", total);
            //                        cmd.Parameters.AddWithValue("@ProformaID", idProforma);
            //                        cmd.Parameters.AddWithValue("@ProductoID", productoID);

            //                        await cmd.ExecuteNonQueryAsync();
            //                    }
            //                }

            //                // 🔹 2. Guardar el estado de la proforma si ha cambiado
            //                if (cmbEstado.SelectedItem != null)
            //                {
            //                    string nuevoEstado = cmbEstado.SelectedItem.ToString();

            //                    string queryUpdateEstado = "UPDATE Proformas SET Estatus = @Estatus WHERE ProformaID = @ProformaID";
            //                    using (SqlCommand cmdEstado = new SqlCommand(queryUpdateEstado, conn, transaction))
            //                    {
            //                        cmdEstado.Parameters.AddWithValue("@Estatus", nuevoEstado);
            //                        cmdEstado.Parameters.AddWithValue("@ProformaID", idProforma);
            //                        await cmdEstado.ExecuteNonQueryAsync();
            //                    }
            //                }

            //                // 🔹 3. Confirmar cambios
            //                transaction.Commit();
            //                MessageBox.Show("✅ Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            catch (Exception ex)
            //            {
            //                transaction.Rollback(); // Revertir cambios si hay un error
            //                MessageBox.Show($"❌ Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"❌ Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
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

                    // Evitar valores NULL en el DataTable
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["ProformaID"] == DBNull.Value)
                        {
                            row["ProformaID"] = -1;  // Se usa -1 en lugar de NULL
                        }
                    }

                    // Agregar una fila vacía con -1 para evitar problemas de conversión
                    DataRow filaVacia = dt.NewRow();
                    filaVacia["ProformaID"] = -1;  // Identificador de opción vacía
                    dt.Rows.InsertAt(filaVacia, 0);

                    // Asignar al ComboBox
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
