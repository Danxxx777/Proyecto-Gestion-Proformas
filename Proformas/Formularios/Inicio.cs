using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using Proformas.Formularios;

namespace Proformas
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gtbUsuario_Enter(object sender, EventArgs e)
        {
            if (gtbUsuario.Text == "Usuario")
            {
                gtbUsuario.Text = "";
            }
        }

        private void gtbUsuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(gtbUsuario.Text))
            {
                gtbUsuario.Text = "Usuario";
            }
        }

        private void gtbcontraseña_Enter(object sender, EventArgs e)
        {
            if (gtbcontraseña.Text == "Contraseña")
            {
                gtbcontraseña.Text = "";
                gtbcontraseña.PasswordChar = '*';
            }
        }

        private void gtbcontraseña_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(gtbcontraseña.Text))
            {
                gtbcontraseña.Text = "Contraseña";
                gtbcontraseña.PasswordChar = '\0';
            }
            
        }

        private void pbxCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Instancia de la clase Conexion
            Conexion miConexion = new Conexion();

            // Obtener los valores de los TextBox
            string usuario = gtbUsuario.Text.Trim();
            string contraseña = gtbcontraseña.Text.Trim();

            // Obtener los datos del usuario y el ID del vendedor
            var datosUsuario = miConexion.ObtenerDatosUsuario(usuario, contraseña);
            string nombreUsuario = datosUsuario.nombreUsuario;
            int vendedorID = datosUsuario.vendedorID;

            if (!string.IsNullOrEmpty(nombreUsuario))
            {
                MessageBox.Show("Login exitoso", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                // 🔹 Crear una instancia de frmPrincipal y pasarle los datos del usuario
                GestiónProformas principal = new GestiónProformas(nombreUsuario, vendedorID);
                principal.Show(); // Abrir el formulario principal
                this.Hide(); // Ocultar el formulario de login
            }
            
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }








        private bool ValidarUsuario(string usuario, string contraseña)
        {
            bool esValido = false;

            string connectionString = "Server=Ryzen7\\SQLEXPRESS;Database=BDProformas;Trusted_Connection=True;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario AND Contraseña = @Contraseña";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                        int count = (int)cmd.ExecuteScalar();
                        esValido = (count > 0);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return esValido;
        }
    }
}
