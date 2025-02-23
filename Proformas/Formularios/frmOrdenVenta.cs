using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Proformas.Formularios
{
    public partial class frmOrdenVenta : Form
    {
        private Conexion conexion = new Conexion();

        public frmOrdenVenta()
        {
            InitializeComponent();

            // Evento para detectar cambios en el txtfiltroCedula
            this.Load += frmOrdenVenta_Load;



        }

        private void frmOrdenVenta_Load(object sender, EventArgs e)
        {
            // Opcional: Cargar datos adicionales en el ComboBox si es necesario
            //txtCedula.TextChanged += TxtFiltroCedula_TextChanged;
        }
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // 🔹 Bloquea caracteres no numéricos
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



        private void pbxCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtFiltroCedula_TextChanged(object sender, EventArgs e)
        {
            // txtCedula.TextChanged -= TxtFiltroCedula_TextChanged;  // 🔴 COMENTADO

            string texto = txtCedula.Text.Trim();

            if (texto.Length == 10 && EsNumerico(texto))
            {
                BuscarClientePorCedula();
            }
            else
            {
                LimpiarCampos();
            }

            // txtCedula.TextChanged += TxtFiltroCedula_TextChanged;  // 🔴 COMENTADO
        }



        private async void BuscarClientePorCedula()
        {
            string cedula = txtCedula.Text.Trim();
            string query = "SELECT Nombre, Correo, FechaRegistro, Estado FROM Clientes WHERE NumeroIdentificacion = @cedula";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion.ConnectionString))
                {
                    await conn.OpenAsync(); // 🔹 Abrimos la conexión en modo asíncrono
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cedula", cedula);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync()) // 🔹 Leer datos en segundo plano
                        {
                            if (await reader.ReadAsync()) // 🔹 Si se encuentra un cliente
                            {
                                txtCedula.Invoke((MethodInvoker)(() => txtCedula.Text = cedula));
                                txtNombre.Invoke((MethodInvoker)(() => txtNombre.Text = reader["Nombre"].ToString()));
                                txtCorreo.Invoke((MethodInvoker)(() => txtCorreo.Text = reader["Correo"].ToString()));
                                txtTelefono.Invoke((MethodInvoker)(() => txtTelefono.Text = Convert.ToDateTime(reader["FechaRegistro"]).ToString("yyyy-MM-dd")));
                                txtEstado1.Invoke((MethodInvoker)(() => txtEstado1.Text = reader["Estado"].ToString()));

                                await CargarProformasAsync(cedula); // 🔹 Llamamos la carga de proformas en segundo plano
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
                    await conn.OpenAsync(); // 🔹 Abrimos la conexión en segundo plano

                    // Obtener ClienteID
                    string queryClienteID = "SELECT ClienteID FROM Clientes WHERE NumeroIdentificacion = @cedula";
                    int clienteID = -1;

                    using (SqlCommand cmdCliente = new SqlCommand(queryClienteID, conn))
                    {
                        cmdCliente.Parameters.AddWithValue("@cedula", cedula);
                        object result = await cmdCliente.ExecuteScalarAsync(); // 🔹 Obtener ClienteID en segundo plano

                        if (result != null)
                        {
                            clienteID = Convert.ToInt32(result);
                        }
                        else
                        {
                            cmbProformas.Invoke((MethodInvoker)(() => cmbProformas.Items.Clear()));
                            MessageBox.Show("No se encontró ClienteID para esta cédula.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // Obtener Proformas
                    string queryProformas = "SELECT ProformaID FROM Proformas WHERE ClienteID = @ClienteID";
                    using (SqlCommand cmdProformas = new SqlCommand(queryProformas, conn))
                    {
                        cmdProformas.Parameters.AddWithValue("@ClienteID", clienteID);
                        using (SqlDataReader reader = await cmdProformas.ExecuteReaderAsync()) // 🔹 Leer en segundo plano
                        {
                            cmbProformas.Invoke((MethodInvoker)(() => cmbProformas.Items.Clear()));

                            while (await reader.ReadAsync()) // 🔹 Leer cada resultado en segundo plano
                            {
                                cmbProformas.Invoke((MethodInvoker)(() => cmbProformas.Items.Add(reader["ProformaID"].ToString())));
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



        private bool EsNumerico(string texto)
        {
            return long.TryParse(texto, out _);
        }

        private void LimpiarCampos()
        {
           
            txtCedula.Clear();
            txtNombre.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtEstado1.Clear();
            cmbProformas.Items.Clear(); // Limpiar el ComboBox
        }

        private void cmbProformas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProformas.SelectedItem != null)
            {
                int proformaID = Convert.ToInt32(cmbProformas.SelectedItem);
                CargarDetalleProforma(proformaID);
            }
        }
        private void CargarDetalleProforma(int proformaID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conexion.ConnectionString))
                {
                    conn.Open();

                    // Consulta para obtener los detalles de la proforma
                    string query = @"SELECT Producto, Cantidad, PrecioUnitario, Descuento 
                             FROM DetalleProforma 
                             WHERE ProformaID = @ProformaID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProformaID", proformaID);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvDetalleProfroma.DataSource = dt; // Cargar los datos en el DataGridView
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el detalle de la proforma: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }

}


