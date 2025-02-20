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

        private void gtbcontrase�a_Enter(object sender, EventArgs e)
        {
            if (gtbcontrase�a.Text == "Contrase�a")
            {
                gtbcontrase�a.Text = "";
                gtbcontrase�a.PasswordChar = '*';
            }

        }

        private void gtbcontrase�a_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(gtbcontrase�a.Text))
            {
                gtbcontrase�a.Text = "Contrase�a";
                gtbcontrase�a.PasswordChar = '\0';
            }
        }

        private void pbxCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
