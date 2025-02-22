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
            txtCedula.TextChanged += TxtFiltroCedula_TextChanged;
        }

        private void frmOrdenVenta_Load(object sender, EventArgs e)
        {
            // Opcional: Cargar datos adicionales en el ComboBox si es necesario
        }

        private void pbxCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtFiltroCedula_TextChanged(object sender, EventArgs e)
        {
            if (txtCedula.Text.Length == 10 && EsNumerico(txtCedula.Text))
            {
                BuscarClientePorCedula();
            }
            else
            {
                LimpiarCampos();
            }
        }

        private void BuscarClientePorCedula()
        {
            string cedula = txtCedula.Text.Trim();
            string query = "SELECT Nombre, Correo, FechaRegistro, Estado FROM Clientes WHERE NumeroIdentificacion = @cedula";

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cedula", cedula);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Si se encuentra un cliente
                            {
                                txtCedula.Text = cedula;
                                txtNombre.Text = reader["Nombre"].ToString();
                                txtCorreo.Text = reader["Correo"].ToString();
                                txtTelefono.Text = Convert.ToDateTime(reader["FechaRegistro"]).ToString("yyyy-MM-dd"); // Convertimos FechaRegistro
                                txtEstado1.Text = reader["Estado"].ToString();

                                // Opcional: Llenar el ComboBox con valores relacionados
                                CargarProformas(cedula);
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


        private void CargarProformas(string cedula)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conexion.ConnectionString))
                {
                    conn.Open();

                    // 🔹 Primero, obtener ClienteID desde Clientes usando la cédula
                    string queryClienteID = "SELECT ClienteID FROM Clientes WHERE NumeroIdentificacion = @cedula";
                    int clienteID = -1; // Valor predeterminado si no encuentra el ClienteID

                    using (SqlCommand cmdCliente = new SqlCommand(queryClienteID, conn))
                    {
                        cmdCliente.Parameters.AddWithValue("@cedula", cedula);
                        object result = cmdCliente.ExecuteScalar(); // Devuelve un único valor

                        if (result != null)
                        {
                            clienteID = Convert.ToInt32(result);
                        }
                        else
                        {
                            cmbProformas.Items.Clear();
                            MessageBox.Show("No se encontró ClienteID para esta cédula.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return; // Sale del método si no encontró un ClienteID
                        }
                    }

                    // 🔹 Ahora, buscar Proformas usando ClienteID
                    string queryProformas = "SELECT ProformaID FROM Proformas WHERE ClienteID = @ClienteID";

                    using (SqlCommand cmdProformas = new SqlCommand(queryProformas, conn))
                    {
                        cmdProformas.Parameters.AddWithValue("@ClienteID", clienteID);
                        using (SqlDataReader reader = cmdProformas.ExecuteReader())
                        {
                            cmbProformas.Items.Clear(); // Limpiar el ComboBox antes de llenarlo

                            while (reader.Read())
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


