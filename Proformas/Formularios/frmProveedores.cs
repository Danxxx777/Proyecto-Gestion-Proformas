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
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            frmBodegas frmbdgas = new frmBodegas();
            frmbdgas.Show();
            this.Hide();
        }

        private void pbxCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
