using Guna.UI2.WinForms;

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
    }
}
