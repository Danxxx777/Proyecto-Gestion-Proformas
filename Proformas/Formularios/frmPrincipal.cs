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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {

            InitializeComponent();
            //btnProformasPrincipal.FlatStyle = FlatStyle.Flat;
            //btnProformasPrincipal.FlatAppearance.BorderSize = 0;
            // Obtener el tamaño de la pantalla
            Rectangle screenSize = Screen.PrimaryScreen.WorkingArea;

            // Ajustar el tamaño del formulario al tamaño de la pantalla
            this.Size = new Size(screenSize.Width, screenSize.Height);

            // Centrar el formulario en la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProformasPrincipal_Click(object sender, EventArgs e)
        {
            // Primero, limpiar el Panel2 de cualquier control que esté abierto
            splitContainer1.Panel2.Controls.Clear();

            // Crear instancia del formulario que deseas mostrar
            frmProformas frm = new frmProformas();

            // Para que el formulario se “anide” dentro del Panel2:
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            // Agregar el formulario al Panel2
            splitContainer1.Panel2.Controls.Add(frm);

            // Mostrar el formulario
            frm.Show();
        }

        private void btnOrdenVenta_Click(object sender, EventArgs e)
        {
            // Primero, limpiar el Panel2 de cualquier control que esté abierto
            splitContainer1.Panel2.Controls.Clear();

            // Crear instancia del formulario que deseas mostrar
            frmOrdenVenta frm = new frmOrdenVenta();

            // Para que el formulario se “anide” dentro del Panel2:
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            // Agregar el formulario al Panel2
            splitContainer1.Panel2.Controls.Add(frm);

            // Mostrar el formulario
            frm.Show();
        }




        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            Rectangle screenSize = Screen.PrimaryScreen.WorkingArea;

            // Ajustar el tamaño del formulario al tamaño de la pantalla
            this.Size = new Size(screenSize.Width, screenSize.Height);

            // Centrar el formulario en la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Rectangle screenSize = Screen.PrimaryScreen.WorkingArea;

            // Ajustar el tamaño del formulario al tamaño de la pantalla
            this.Size = new Size(screenSize.Width, screenSize.Height);

            // Centrar el formulario en la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            // Primero, limpiar el Panel2 de cualquier control que esté abierto
            splitContainer1.Panel2.Controls.Clear();

            // Crear instancia del formulario que deseas mostrar
            frmClientes frm = new frmClientes();

            // Para que el formulario se “anide” dentro del Panel2:
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            // Agregar el formulario al Panel2
            splitContainer1.Panel2.Controls.Add(frm);

            // Mostrar el formulario
            frm.Show();
        }

        private void btnBodegas_Click(object sender, EventArgs e)
        {
            // Primero, limpiar el Panel2 de cualquier control que esté abierto
            splitContainer1.Panel2.Controls.Clear();

            // Crear instancia del formulario que deseas mostrar
            frmBodegas frm = new frmBodegas();

            // Para que el formulario se “anide” dentro del Panel2:
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            // Agregar el formulario al Panel2
            splitContainer1.Panel2.Controls.Add(frm);

            // Mostrar el formulario
            frm.Show();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            // Primero, limpiar el Panel2 de cualquier control que esté abierto
            splitContainer1.Panel2.Controls.Clear();

            // Crear instancia del formulario que deseas mostrar
            frmProveedores frm = new frmProveedores();

            // Para que el formulario se “anide” dentro del Panel2:
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            // Agregar el formulario al Panel2
            splitContainer1.Panel2.Controls.Add(frm);

            // Mostrar el formulario
            frm.Show();
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            // Primero, limpiar el Panel2 de cualquier control que esté abierto
            splitContainer1.Panel2.Controls.Clear();

            // Crear instancia del formulario que deseas mostrar
            frmEmpresa frm = new frmEmpresa();

            // Para que el formulario se “anide” dentro del Panel2:
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            // Agregar el formulario al Panel2
            splitContainer1.Panel2.Controls.Add(frm);

            // Mostrar el formulario
            frm.Show();

        }
    }
}
