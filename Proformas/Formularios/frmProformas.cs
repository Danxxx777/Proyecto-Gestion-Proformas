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
        //private string connectionString = "Data Source=DESKTOP-VK5KHQR;Initial Catalog=proformas2.0;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
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
                string query = "SELECT p.ProductoID, p.Nombre, sp.PrecioUnitario FROM Productos p " +
                               "INNER JOIN SucursalProducto sp ON p.ProductoID = sp.ProductoID";
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
                decimal precio = row.Cells["PrecioUnitario"].Value != DBNull.Value
                    ? Convert.ToDecimal(row.Cells["PrecioUnitario"].Value)
                    : 0;

                // Verificar si el producto ya está en dgvDproductos
                foreach (DataGridViewRow detalleRow in dgvDproductos.Rows)
                {
                    if (detalleRow.Cells["ProductoID"].Value != null &&
                        Convert.ToInt32(detalleRow.Cells["ProductoID"].Value) == productoID)
                    {
                        int cantidadActual = detalleRow.Cells["Cantidad"].Value != null
                            ? Convert.ToInt32(detalleRow.Cells["Cantidad"].Value)
                            : 0;

                        detalleRow.Cells["Cantidad"].Value = cantidadActual + 1;
                        detalleRow.Cells["Total"].Value = (cantidadActual + 1) * precio;
                        CalcularTotales();
                        return;
                    }
                }

                // Agregar nuevo producto con cantidad 1
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

            // Obtener el porcentaje de descuento sin modificar txtDescuento1
            decimal porcentajeDescuento;
            if (!decimal.TryParse(txtDescuento1.Text, out porcentajeDescuento) || porcentajeDescuento < 0)
            {
                porcentajeDescuento = 0;
            }

            if (porcentajeDescuento > 50)
            {
                porcentajeDescuento = 50;
            }

            // Calcular el descuento en valor monetario
            decimal descuento = subtotal * (porcentajeDescuento / 100);
            lblinfoDescuento.Text = $": {descuento:C2} ({porcentajeDescuento}%)";

            // Calcular total final después del descuento
            decimal totalFinal = subtotal + iva - descuento;
            txtTotalfinal.Text = totalFinal.ToString("0.00");
        }




        private void frmProformas_Load(object sender, EventArgs e)
        {
            // Configuración de columnas para dgvDproductos
            dgvDproductos.ColumnCount = 5;
            dgvDproductos.Columns[0].Name = "ProductoID";
            dgvDproductos.Columns[1].Name = "Nombre";
            dgvDproductos.Columns[2].Name = "Cantidad";
            dgvDproductos.Columns[3].Name = "PrecioUnitario";
            dgvDproductos.Columns[4].Name = "Total";

            // Formatear columnas de precios
            dgvDproductos.Columns[3].DefaultCellStyle.Format = "C2";
            dgvDproductos.Columns[4].DefaultCellStyle.Format = "C2";

            CargarSucursales(); // Carga las sucursales en el ComboBox
            if (cboSucursales.Items.Count > 0)
            {
                cboSucursales.SelectedIndex = 0; // Selecciona la primera sucursal por defecto
            }
        }

        private void pbxCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                return;
            }

            if (porcentajeDescuento > 50)
            {
                MessageBox.Show("El descuento no puede ser mayor al 50% del subtotal.", "Descuento Excesivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescuento1.Text = "50"; // Mantener el porcentaje dentro del límite permitido
            }

            // Recalcular los totales sin modificar el txtDescuento1
            CalcularTotales();

            MessageBox.Show("Descuento aplicado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void dgvDproductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDproductos.Columns["Cantidad"].Index) // Si la celda editada es la de cantidad
            {
                try
                {
                    if (dgvDproductos.Rows[e.RowIndex].Cells["Cantidad"].Value == null)
                        dgvDproductos.Rows[e.RowIndex].Cells["Cantidad"].Value = 1;

                    int nuevaCantidad = Convert.ToInt32(dgvDproductos.Rows[e.RowIndex].Cells["Cantidad"].Value);

                    if (nuevaCantidad <= 0)
                    {
                        MessageBox.Show("La cantidad debe ser mayor a 0.", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvDproductos.Rows[e.RowIndex].Cells["Cantidad"].Value = 1;
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
                    dgvDproductos.Rows[e.RowIndex].Cells["Cantidad"].Value = 1;
                }
            }
        }
        private void dgvDproductos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvDproductos.CurrentCell.ColumnIndex == dgvDproductos.Columns["Cantidad"].Index)
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
                    // 🔹 Obtener la Sucursal seleccionada
                    if (cboSucursales.SelectedValue == null)
                    {
                        MessageBox.Show("Seleccione una sucursal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int sucursalID = Convert.ToInt32(cboSucursales.SelectedValue);

                    // 🔹 Verificar si el Cliente existe
                    string queryClienteExistente = "SELECT COUNT(*) FROM Clientes WHERE NumeroIdentificacion = @Cedula";
                    using (SqlCommand cmdCheckCliente = new SqlCommand(queryClienteExistente, conn, transaction))
                    {
                        cmdCheckCliente.Parameters.AddWithValue("@Cedula", txtNcedula.Text);
                        int existe = (int)await cmdCheckCliente.ExecuteScalarAsync();

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

                    // 🔹 Obtener el ClienteID
                    string queryObtenerClienteID = "SELECT ClienteID FROM Clientes WHERE NumeroIdentificacion = @Cedula";
                    int clienteID;
                    using (SqlCommand cmdObtenerCliente = new SqlCommand(queryObtenerClienteID, conn, transaction))
                    {
                        cmdObtenerCliente.Parameters.AddWithValue("@Cedula", txtNcedula.Text);
                        clienteID = Convert.ToInt32(await cmdObtenerCliente.ExecuteScalarAsync());
                    }

                    // 🔹 Obtener el VendedorID
                    if (!int.TryParse(lblVendedorID.Text, out int vendedorID))
                    {
                        MessageBox.Show("Error: VendedorID debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 🔹 Obtener el nuevo número de proforma y actualizarlo en la sucursal
                    string queryNumeroProforma = "SELECT UltimoNumeroProforma FROM Sucursales WHERE SucursalID = @SucursalID";
                    int nuevoNumeroProforma;
                    using (SqlCommand cmdNumeroProforma = new SqlCommand(queryNumeroProforma, conn, transaction))
                    {
                        cmdNumeroProforma.Parameters.AddWithValue("@SucursalID", sucursalID);
                        nuevoNumeroProforma = Convert.ToInt32(await cmdNumeroProforma.ExecuteScalarAsync()) + 1;
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

                    // 🔹 Insertar los detalles de la Proforma y actualizar el stock
                    foreach (DataGridViewRow row in dgvDproductos.Rows)
                    {
                        if (row.Cells["ProductoID"].Value != null)
                        {
                            int productoID = Convert.ToInt32(row.Cells["ProductoID"].Value);
                            int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                            decimal precioUnitario = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value);
                            decimal total = Convert.ToDecimal(row.Cells["Total"].Value);
                            decimal descuento = Convert.ToDecimal(txtDescuento1.Text);

                            // Insertar en DetalleProforma
                            string queryDetalle = "INSERT INTO DetalleProforma (ProformaID, ProductoID, Cantidad, PrecioUnitario, Total, Descuento) " +
                                                  "VALUES (@ProformaID, @ProductoID, @Cantidad, @PrecioUnitario, @Total, @Descuento)";
                            using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conn, transaction))
                            {
                                cmdDetalle.Parameters.AddWithValue("@ProformaID", proformaID);
                                cmdDetalle.Parameters.AddWithValue("@ProductoID", productoID);
                                cmdDetalle.Parameters.AddWithValue("@Cantidad", cantidad);
                                cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", precioUnitario);
                                cmdDetalle.Parameters.AddWithValue("@Total", total);
                                cmdDetalle.Parameters.AddWithValue("@Descuento", descuento);
                                await cmdDetalle.ExecuteNonQueryAsync();
                            }

                            // 🔹 Descontar stock en SucursalProducto
                            string queryActualizarStock = "UPDATE SucursalProducto SET Stock = Stock - @Cantidad " +
                                                          "WHERE ProductoID = @ProductoID AND SucursalID = @SucursalID";
                            using (SqlCommand cmdActualizarStock = new SqlCommand(queryActualizarStock, conn, transaction))
                            {
                                cmdActualizarStock.Parameters.AddWithValue("@Cantidad", cantidad);
                                cmdActualizarStock.Parameters.AddWithValue("@ProductoID", productoID);
                                cmdActualizarStock.Parameters.AddWithValue("@SucursalID", sucursalID);
                                await cmdActualizarStock.ExecuteNonQueryAsync();
                            }
                        }
                    }

                    // 🔹 Actualizar el número de proforma en la sucursal
                    string queryActualizarProforma = "UPDATE Sucursales SET UltimoNumeroProforma = @UltimoNumero WHERE SucursalID = @SucursalID";
                    using (SqlCommand cmdActualizarProforma = new SqlCommand(queryActualizarProforma, conn, transaction))
                    {
                        cmdActualizarProforma.Parameters.AddWithValue("@UltimoNumero", nuevoNumeroProforma);
                        cmdActualizarProforma.Parameters.AddWithValue("@SucursalID", sucursalID);
                        await cmdActualizarProforma.ExecuteNonQueryAsync();
                    }

                    // 🔹 Confirmar la transacción
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

        private void CargarSucursales()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT SucursalID, NombreSucursal FROM Sucursales WHERE Estado = 'Act'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboSucursales.DisplayMember = "NombreSucursal"; // Lo que se mostrará en el ComboBox
                cboSucursales.ValueMember = "SucursalID"; // El ID que se usará internamente
                cboSucursales.DataSource = dt;
            }
        }

        private void cboSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSucursales.SelectedValue != null)
            {
                int sucursalID = Convert.ToInt32(cboSucursales.SelectedValue);
                CargarProductosPorSucursal(sucursalID);
            }
        }
        private void CargarProductosPorSucursal(int sucursalID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT p.ProductoID, p.Nombre, sp.Stock, sp.PrecioUnitario
                         FROM Productos p
                         INNER JOIN SucursalProducto sp ON p.ProductoID = sp.ProductoID
                         WHERE sp.SucursalID = @SucursalID AND sp.Stock > 0"; // Solo productos con stock disponible

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@SucursalID", sucursalID);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProductos.DataSource = dt;
            }
        }

        private void btnLimpiarProductos_Click(object sender, EventArgs e)
        {
            dgvDproductos.Rows.Clear();
            CalcularTotales(); // Recalcular totales después de limpiar
        }
    }
}
