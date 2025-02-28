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
    //marlon
    //gomez
    public partial class frmPrincipal : Form
    {
        private string nombreUsuario;
        private int vendedorID;
        public frmPrincipal(string nombreUsuario, int vendedorID)
        {

            InitializeComponent();
            this.nombreUsuario = nombreUsuario;
            this.vendedorID = vendedorID;
            lblNombre.Text = nombreUsuario;

            Rectangle screenSize = Screen.PrimaryScreen.WorkingArea;


            this.Size = new Size(screenSize.Width, screenSize.Height);


            this.StartPosition = FormStartPosition.CenterScreen;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Application.Exit(); // Cierra toda la aplicación correctamente
            }
        }


        private void btnProformasPrincipal_Click(object sender, EventArgs e)
        {

            splitContainer1.Panel2.Controls.Clear();

            // Verificar que los valores no sean nulos o incorrectos
            if (string.IsNullOrEmpty(nombreUsuario) || vendedorID <= 0)
            {
                MessageBox.Show("No hay usuario autenticado. Inicia sesión primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear instancia del formulario y pasarle los valores correctos
            frmProformas frm = new frmProformas(nombreUsuario, vendedorID);

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void btnOrdenVenta_Click(object sender, EventArgs e)
        {

            splitContainer1.Panel2.Controls.Clear();


            frmOrdenVenta frm = new frmOrdenVenta();


            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;


            splitContainer1.Panel2.Controls.Add(frm);


            frm.Show();
        }




        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            Rectangle screenSize = Screen.PrimaryScreen.WorkingArea;


            this.Size = new Size(screenSize.Width, screenSize.Height);


            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Rectangle screenSize = Screen.PrimaryScreen.WorkingArea;


            this.Size = new Size(screenSize.Width, screenSize.Height);


            this.StartPosition = FormStartPosition.CenterScreen;


            Form login = Application.OpenForms["Login"]; // Busca el formulario de login por su nombre
            if (login != null)
            {
                login.Close(); // Cierra el login solo cuando el principal ya está activo
            }
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {

            splitContainer1.Panel2.Controls.Clear();


            frmClientes frm = new frmClientes();


            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;


            splitContainer1.Panel2.Controls.Add(frm);


            frm.Show();
        }

        private void btnBodegas_Click(object sender, EventArgs e)
        {

            splitContainer1.Panel2.Controls.Clear();


            frmBodegas frm = new frmBodegas();


            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;


            splitContainer1.Panel2.Controls.Add(frm);


            frm.Show();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {

            splitContainer1.Panel2.Controls.Clear();


            frmProveedores frm = new frmProveedores();


            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;


            splitContainer1.Panel2.Controls.Add(frm);


            frm.Show();
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {

            splitContainer1.Panel2.Controls.Clear();


            frmEmpresa frm = new frmEmpresa();


            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;


            splitContainer1.Panel2.Controls.Add(frm);

            frm.Show();

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Application.Exit(); // Cierra toda la aplicación correctamente
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();


            frmProductos frm = new frmProductos();


            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;


            splitContainer1.Panel2.Controls.Add(frm);

            frm.Show();
        }
    }
}
