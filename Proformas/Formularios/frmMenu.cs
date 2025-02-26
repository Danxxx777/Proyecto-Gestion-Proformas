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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
            customizeDesing();
        }
        private void customizeDesing()
        {
            pnlSubmenuClientes.Visible = false;
            pnlSubmenuProformas.Visible = false;
            pnlSubmenuOrdenVenta.Visible = false;
            pnlSubmenuProductos.Visible = false;

        }
        private void hideSubMenu()
        {
            if (pnlSubmenuClientes.Visible == true)
                pnlSubmenuClientes.Visible = false;
            if (pnlSubmenuProformas.Visible == true)
                pnlSubmenuProformas.Visible = false;
            if (pnlSubmenuOrdenVenta.Visible == true)
                pnlSubmenuOrdenVenta.Visible = false;
            if (pnlSubmenuProductos.Visible == true)
                pnlSubmenuProductos.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }


        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnClientes_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSubmenuClientes);
        }
        private void btnAgregarQuitar_Click(object sender, EventArgs e)
        {
            //codigo
            hideSubMenu();
        }
    }
}
