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

        }
    }
}
