using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Proformas.Formularios
{
    public partial class frmClienteProforma : Form
    {
        private string connectionString = "Data Source=Ryzen7\\SQLEXPRESS;Initial Catalog=BDProformas;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";

        public string ClienteNombre { get; private set; } // Propiedad para devolver el nombre del cliente a frmProformas

        public frmClienteProforma()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text.Trim();
            string nombre = txtCliente.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string tipoCliente = txtTipoCliente.Text.Trim();
            string estado = txtEstado.Text.Trim();

            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(cedula) || string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Cédula y Nombre son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();

                // Verificar si el cliente ya existe
                string queryVerificar = "SELECT COUNT(*) FROM Clientes WHERE NumeroIdentificacion = @Cedula";
                using (SqlCommand cmdVerificar = new SqlCommand(queryVerificar, conn))
                {
                    cmdVerificar.Parameters.AddWithValue("@Cedula", cedula);
                    int count = Convert.ToInt32(await cmdVerificar.ExecuteScalarAsync());

                    if (count > 0)
                    {
                        MessageBox.Show("El cliente ya está registrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                // Insertar el nuevo cliente
                string queryInsertar = "INSERT INTO Clientes (NumeroIdentificacion, Nombre, Correo, TipoCliente, Estado, FechaRegistro) " +
                                       "VALUES (@Cedula, @Nombre, @Correo, @TipoCliente, @Estado, GETDATE())";

                using (SqlCommand cmdInsertar = new SqlCommand(queryInsertar, conn))
                {
                    cmdInsertar.Parameters.AddWithValue("@Cedula", cedula);
                    cmdInsertar.Parameters.AddWithValue("@Nombre", nombre);
                    cmdInsertar.Parameters.AddWithValue("@Correo", correo);
                    cmdInsertar.Parameters.AddWithValue("@TipoCliente", tipoCliente);
                    cmdInsertar.Parameters.AddWithValue("@Estado", estado);

                    await cmdInsertar.ExecuteNonQueryAsync();
                }
            }

            ClienteNombre = nombre; // Guardar el nombre del cliente para pasarlo a frmProformas
            MessageBox.Show("Cliente registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK; // Indica que se guardó correctamente
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            string texto = txtCedula.Text.Trim();
            if (texto.Length == 10 && EsNumerico(texto))
            {
                BuscarClientePorCedula();
            }
        }
        private async void BuscarClientePorCedula()
        {
            string cedula = txtCedula.Text.Trim(); // Usar el campo correcto para buscar por cédula
            if (string.IsNullOrWhiteSpace(cedula) || cedula.Length != 10)
            {
                return; // No hace nada si el campo está vacío o no tiene 10 dígitos
            }

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
                                txtCliente.Invoke((MethodInvoker)(() => txtCliente.Text = reader["Nombre"].ToString()));
                                txtCorreo.Invoke((MethodInvoker)(() => txtCorreo.Text = reader["Correo"].ToString()));
                                txtTipoCliente.Invoke((MethodInvoker)(() => txtTipoCliente.Text = reader["TipoCliente"].ToString()));
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

        private void LimpiarCampos()
        {
           
            txtCorreo.Text = "";
            txtCliente.Text = "";
            txtEstado.Text = "";
        }

        private bool EsNumerico(string texto)
        {
            return int.TryParse(texto, out _);
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {

        }
        
    }
}

