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
    }
}
