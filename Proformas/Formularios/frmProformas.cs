using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proformas.Formularios
{
    public partial class frmProformas : Form
    {
        private string connectionString = "Data Source=Ryzen7\\SQLEXPRESS;Initial Catalog=BDProformas;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
       
        private string nombreUsuario;
        private int vendedorID;
        public frmProformas(string nombreUsuario, int vendedorID)
        {
            InitializeComponent();
            this.nombreUsuario = nombreUsuario;
            this.vendedorID = vendedorID;
            lblVendedorID.Text = vendedorID.ToString();
            CargarProductos();
        }
        private async void BuscarClientePorCedula()
        {
            string cedula = txtNcedula.Text.Trim();
            string query = "SELECT Nombre, Correo, TipoCliente, Estado FROM Clientes WHERE NumeroIdentificacion = @cedula";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cedula", cedula);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                txtNcliente.Invoke((MethodInvoker)(() => txtNcliente.Text = reader["Nombre"].ToString()));
                                txtCorreoP.Invoke((MethodInvoker)(() => txtCorreoP.Text = reader["Correo"].ToString()));
                                txtTcliente.Invoke((MethodInvoker)(() => txtTcliente.Text = reader["TipoCliente"].ToString()));
                                txtEstado.Invoke((MethodInvoker)(() => txtEstado.Text = reader["Estado"].ToString()));
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
        private void txtNcedula_TextChanged(object sender, EventArgs e)
        {
            string texto = txtNcedula.Text.Trim();
            if (texto.Length == 10 && EsNumerico(texto))
            {
                BuscarClientePorCedula();
            }
            else
            {
                LimpiarCampos();
            }
        }
        private void CargarProductos()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductoID, Nombre, PrecioUnitario FROM Productos";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProductos.DataSource = dt;
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProductos.Rows[e.RowIndex];
                int productoID = Convert.ToInt32(row.Cells["ProductoID"].Value);
                string nombre = row.Cells["Nombre"].Value.ToString();
                decimal precio = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value);

                // Verificar si el producto ya está en el DataGridView de detalles
                foreach (DataGridViewRow detalleRow in dgvDproductos.Rows)
                {
                    if (Convert.ToInt32(detalleRow.Cells["ProductoID"].Value) == productoID)
                    {
                        // Si ya existe, solo sumamos la cantidad
                        int cantidadActual = Convert.ToInt32(detalleRow.Cells["Cantidad"].Value);
                        detalleRow.Cells["Cantidad"].Value = cantidadActual + 1;
                        detalleRow.Cells["Total"].Value = (cantidadActual + 1) * precio;
                        CalcularTotales();
                        return;
                    }
                }

                // Si no existe, agregarlo con cantidad 1
                dgvDproductos.Rows.Add(productoID, nombre, 1, precio, precio);
                CalcularTotales();
            }
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string cedula = txtNcedula.Text.Trim();
            string nombreCliente = txtNcliente.Text.Trim();
            string correo = txtCorreoP.Text.Trim();
            string tipoCliente = txtTcliente.Text.Trim();
            string estado = txtEstado.Text.Trim();
            DateTime fechaRegistro = DateTime.Now; // Se toma la fecha actual

            // 🔹 Validar que los campos esenciales no estén vacíos
            if (string.IsNullOrWhiteSpace(cedula) ||
                string.IsNullOrWhiteSpace(nombreCliente) ||
                string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(tipoCliente) ||
                string.IsNullOrWhiteSpace(estado))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    int clienteID;

                    // 🔹 Verificar si el cliente ya existe
                    string queryVerificarCliente = "SELECT ClienteID FROM Clientes WHERE NumeroIdentificacion = @Cedula";
                    using (SqlCommand cmdVerificar = new SqlCommand(queryVerificarCliente, conn, transaction))
                    {
                        cmdVerificar.Parameters.AddWithValue("@Cedula", cedula);
                        object resultado = cmdVerificar.ExecuteScalar();

                        if (resultado != null) // Cliente ya existe
                        {
                            MessageBox.Show("El cliente ya está registrado en la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            transaction.Commit();
                            return;
                        }
                    }

                    // 🔹 Insertar Cliente porque no existe
                    string queryInsertarCliente = "INSERT INTO Clientes (NumeroIdentificacion, Nombre, Correo, TipoCliente, FechaRegistro, Estado) " +
                                                  "VALUES (@Cedula, @Nombre, @Correo, @TipoCliente, @FechaRegistro, @Estado);";

                    using (SqlCommand cmdInsertCliente = new SqlCommand(queryInsertarCliente, conn, transaction))
                    {
                        cmdInsertCliente.Parameters.AddWithValue("@Cedula", cedula);
                        cmdInsertCliente.Parameters.AddWithValue("@Nombre", nombreCliente);
                        cmdInsertCliente.Parameters.AddWithValue("@Correo", correo);
                        cmdInsertCliente.Parameters.AddWithValue("@TipoCliente", tipoCliente);
                        cmdInsertCliente.Parameters.AddWithValue("@FechaRegistro", fechaRegistro);
                        cmdInsertCliente.Parameters.AddWithValue("@Estado", estado);

                        cmdInsertCliente.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Cliente registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 🔹 Limpiar los campos después de guardar
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al registrar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDproductos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalcularTotales();
        }

        private void CalcularTotales()
        {
            decimal subtotal = 0;

            // Calcular el subtotal sumando los valores de la columna "Total"
            foreach (DataGridViewRow row in dgvDproductos.Rows)
            {
                if (row.Cells["Cantidad"].Value != null && row.Cells["PrecioUnitario"].Value != null)
                {
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    decimal precioUnitario = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value);
                    decimal total = cantidad * precioUnitario;
                    row.Cells["Total"].Value = total;
                    subtotal += total;
                }
            }

            txtSubtotal.Text = subtotal.ToString("0.00");

            // Calcular el IVA (15%)
            decimal iva = subtotal * 0.15m;
            txtIva.Text = iva.ToString("0.00");

            // Obtener el descuento en porcentaje desde txtDescuento1
            decimal porcentajeDescuento = 0;
            if (!decimal.TryParse(txtDescuento1.Text, out porcentajeDescuento) || porcentajeDescuento < 0)
            {
                porcentajeDescuento = 0;
                txtDescuento1.Text = "0";
            }

            // Verificar que el porcentaje no sea mayor a 50%
            if (porcentajeDescuento > 50)
            {
                MessageBox.Show("El descuento no puede ser mayor al 50% del subtotal.", "Descuento Excesivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                porcentajeDescuento = 50;
                txtDescuento1.Text = "50";
            }

            // Calcular el descuento en valor monetario
            decimal descuento = subtotal * (porcentajeDescuento / 100);
            lblinfoDescuento.Text = $": {descuento:C2} ({porcentajeDescuento}%)";
            txtDescuento1.Text = descuento.ToString("0.00");

            // Calcular total final después del descuento
            decimal totalFinal = subtotal + iva - descuento;
            txtTotalfinal.Text = totalFinal.ToString("0.00");
        }



        private void frmProformas_Load(object sender, EventArgs e)
        {
            // Definir columnas del DataGridView si no están definidas
            dgvDproductos.ColumnCount = 5;
            dgvDproductos.Columns[0].Name = "ProductoID";
            dgvDproductos.Columns[1].Name = "Nombre";
            dgvDproductos.Columns[2].Name = "Cantidad";
            dgvDproductos.Columns[3].Name = "PrecioUnitario";
            dgvDproductos.Columns[4].Name = "Total";

            // Opcional: Formato para PrecioUnitario y Total
            dgvDproductos.Columns[3].DefaultCellStyle.Format = "C2";
            dgvDproductos.Columns[4].DefaultCellStyle.Format = "C2";
        }

        private void pbxCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDescuento1_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtDescuento1.Text, out decimal porcentajeDescuento) || porcentajeDescuento < 0)
            {
                txtDescuento1.Text = "0";
            }

            if (porcentajeDescuento > 50)
            {
                MessageBox.Show("El descuento no puede ser mayor al 50% del subtotal.", "Descuento Excesivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescuento1.Text = "50";
            }

            CalcularTotales();
        }
        private void txtDescuento_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(lblinfoDescuento.Text, out decimal descuento))
            {
                decimal subtotal = Convert.ToDecimal(txtSubtotal.Text);
                decimal maxDescuento = subtotal * 0.50m; // Máximo 50% del subtotal

                if (descuento > maxDescuento)
                {
                    MessageBox.Show($"El descuento no puede superar el 50% del subtotal ({maxDescuento:C2}).", "Descuento Excesivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblinfoDescuento.Text = maxDescuento.ToString("0.00");
                }
            }
            CalcularTotales();
        }

        private void btnDescuento_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtDescuento1.Text, out decimal porcentajeDescuento) || porcentajeDescuento < 0)
            {
                MessageBox.Show("Ingrese un porcentaje de descuento válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescuento1.Text = "0";
                return;
            }

            if (porcentajeDescuento > 50)
            {
                MessageBox.Show("El descuento no puede ser mayor al 50% del subtotal.", "Descuento Excesivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescuento1.Text = "50";
            }

            // Aplicar el cálculo y refrescar el total
            CalcularTotales();
            MessageBox.Show("", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void dgvDproductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDproductos.Columns["Cantidad"].Index) // Verifica si es la columna de cantidad
            {
                try
                {
                    int nuevaCantidad = Convert.ToInt32(dgvDproductos.Rows[e.RowIndex].Cells["Cantidad"].Value);
                    if (nuevaCantidad <= 0)
                    {
                        MessageBox.Show("La cantidad debe ser mayor a 0.", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvDproductos.Rows[e.RowIndex].Cells["Cantidad"].Value = 1; // Restablece a 1 si es inválido
                    }

                    // Recalcular el total de la fila
                    decimal precioUnitario = Convert.ToDecimal(dgvDproductos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value);
                    dgvDproductos.Rows[e.RowIndex].Cells["Total"].Value = nuevaCantidad * precioUnitario;

                    // Recalcular los totales generales
                    CalcularTotales();
                }
                catch
                {
                    MessageBox.Show("Ingrese un valor numérico válido para la cantidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvDproductos.Rows[e.RowIndex].Cells["Cantidad"].Value = 1; // Evita valores inválidos
                }
            }
        }
        private void dgvDproductos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvDproductos.CurrentCell.ColumnIndex == dgvDproductos.Columns["Cantidad"].Index) // Si es la columna de cantidad
            {
                TextBox txtCantidad = e.Control as TextBox;
                if (txtCantidad != null)
                {
                    txtCantidad.KeyPress -= new KeyPressEventHandler(ValidarEntradaNumerica);
                    txtCantidad.KeyPress += new KeyPressEventHandler(ValidarEntradaNumerica);
                }
            }
        }

        private void ValidarEntradaNumerica(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea caracteres no numéricos
            }
        }

        private async void btnGuardarProforma_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 🔹 Verificar si el Cliente ya existe en la base de datos
                    string queryClienteExistente = "SELECT COUNT(*) FROM Clientes WHERE NumeroIdentificacion = @Cedula";
                    using (SqlCommand cmdCheckCliente = new SqlCommand(queryClienteExistente, conn, transaction))
                    {
                        cmdCheckCliente.Parameters.AddWithValue("@Cedula", txtNcedula.Text);
                        int existe = (int)await cmdCheckCliente.ExecuteScalarAsync();

                        // 🔹 Si no existe, insertarlo en la base de datos
                        if (existe == 0)
                        {
                            string queryInsertCliente = "INSERT INTO Clientes (NumeroIdentificacion, Nombre, Correo, TipoCliente, Estado) " +
                                                        "VALUES (@Cedula, @Nombre, @Correo, @TipoCliente, @Estado)";
                            using (SqlCommand cmdInsertCliente = new SqlCommand(queryInsertCliente, conn, transaction))
                            {
                                cmdInsertCliente.Parameters.AddWithValue("@Cedula", txtNcedula.Text);
                                cmdInsertCliente.Parameters.AddWithValue("@Nombre", txtNcliente.Text);
                                cmdInsertCliente.Parameters.AddWithValue("@Correo", txtCorreoP.Text);
                                cmdInsertCliente.Parameters.AddWithValue("@TipoCliente", txtTcliente.Text);
                                cmdInsertCliente.Parameters.AddWithValue("@Estado", txtEstado.Text);
                                await cmdInsertCliente.ExecuteNonQueryAsync();
                            }
                        }
                    }

                    // 🔹 Obtener el ClienteID recién insertado o existente
                    string queryObtenerClienteID = "SELECT ClienteID FROM Clientes WHERE NumeroIdentificacion = @Cedula";
                    int clienteID;
                    using (SqlCommand cmdObtenerCliente = new SqlCommand(queryObtenerClienteID, conn, transaction))
                    {
                        cmdObtenerCliente.Parameters.AddWithValue("@Cedula", txtNcedula.Text);
                        clienteID = Convert.ToInt32(await cmdObtenerCliente.ExecuteScalarAsync());
                    }

                    // 🔹 Obtener el VendedorID desde el Label
                    if (!int.TryParse(lblVendedorID.Text, out int vendedorID))
                    {
                        MessageBox.Show("Error: VendedorID debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 🔹 Insertar la Proforma
                    string queryProforma = "INSERT INTO Proformas (ClienteID, FechaVencimiento, FechaCotizacion, TotalProforma, Estatus, VendedorID) " +
                                           "VALUES (@ClienteID, @FechaVencimiento, GETDATE(), @TotalProforma, 'Pendiente', @VendedorID); " +
                                           "SELECT SCOPE_IDENTITY();";
                    int proformaID;
                    using (SqlCommand cmdProforma = new SqlCommand(queryProforma, conn, transaction))
                    {
                        cmdProforma.Parameters.AddWithValue("@ClienteID", clienteID);
                        cmdProforma.Parameters.AddWithValue("@FechaVencimiento", Fvencimiento.Value);
                        cmdProforma.Parameters.AddWithValue("@TotalProforma", Convert.ToDecimal(txtTotalfinal.Text));
                        cmdProforma.Parameters.AddWithValue("@VendedorID", vendedorID);
                        proformaID = Convert.ToInt32(await cmdProforma.ExecuteScalarAsync());
                    }

                    // 🔹 Insertar los detalles de la Proforma
                    foreach (DataGridViewRow row in dgvDproductos.Rows)
                    {
                        if (row.Cells["ProductoID"].Value != null)
                        {
                            string queryDetalle = "INSERT INTO DetalleProforma (ProformaID, ProductoID, Cantidad, PrecioUnitario, Total, Descuento) " +
                                                  "VALUES (@ProformaID, @ProductoID, @Cantidad, @PrecioUnitario, @Total, @Descuento)";
                            using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conn, transaction))
                            {
                                cmdDetalle.Parameters.AddWithValue("@ProformaID", proformaID);
                                cmdDetalle.Parameters.AddWithValue("@ProductoID", row.Cells["ProductoID"].Value);
                                cmdDetalle.Parameters.AddWithValue("@Cantidad", row.Cells["Cantidad"].Value);
                                cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", row.Cells["PrecioUnitario"].Value);
                                cmdDetalle.Parameters.AddWithValue("@Total", row.Cells["Total"].Value);
                                cmdDetalle.Parameters.AddWithValue("@Descuento", Convert.ToDecimal(txtDescuento1.Text));
                                await cmdDetalle.ExecuteNonQueryAsync();
                            }
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Proforma registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al registrar la proforma: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LimpiarFormulario()
        {
            // Limpiar los TextBox del cliente
            txtNproformas.Clear();
            txtNcedula.Clear();
            txtNcliente.Clear();
            txtCorreoP.Clear();
            txtTcliente.Clear();
            txtEstado.Clear();

            // Limpiar la selección del DateTimePicker de Fecha de Vencimiento
            Fvencimiento.Value = DateTime.Now;

            // Limpiar los campos relacionados con la proforma
            txtDescuento1.Text = "0,00";
            lblinfoDescuento.Text = ": 0,00 € (0%)";
            txtSubtotal.Text = "0,00";
            txtIva.Text = "0,00";
            txtTotalfinal.Text = "0,00";

            // Limpiar el DataGridView de detalle de productos
            dgvDproductos.Rows.Clear();
        }
        private void LimpiarCampos()
        {
            txtNcliente.Text = "";
            txtCorreoP.Text = "";
            txtTcliente.Text = "";
            txtEstado.Text = "";
        }

        private bool EsNumerico(string texto)
        {
            return int.TryParse(texto, out _);
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarClientePorCedula();
        }
        private async Task<bool> ClienteExiste(string clienteID)
        {
            bool existe = false;
            string query = "SELECT COUNT(*) FROM Clientes WHERE NumeroIdentificacion = @ClienteID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ClienteID", clienteID);
                    int count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                    existe = (count > 0);
                }
            }
            return existe;
        }

    }
}
