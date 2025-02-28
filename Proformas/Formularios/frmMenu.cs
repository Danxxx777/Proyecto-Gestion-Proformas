using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Controls;
using System.Windows.Forms;

namespace Proformas.Formularios
{
    public partial class GestiónProformas : Form
    {
        private string nombreUsuario;
        private int vendedorID;
        public GestiónProformas(string nombreUsuario, int vendedorID)
        {
            InitializeComponent();
            customizeDesing();
            this.nombreUsuario = nombreUsuario;
            this.vendedorID = vendedorID;


        }
        private void customizeDesing()
        {
            pnlSubmenuClientes.Visible = false;
            pnlSubmenuProducto.Visible = false;
            pnlSubmenuProducto.Visible = false;
            pnlconfiguracion.Visible = false;

        }
        private void hideSubMenu()
        {
            if (pnlSubmenuClientes.Visible == true)
                pnlSubmenuClientes.Visible = false;
            //if (pnlSubmenuProformas.Visible == true)
            //    pnlSubmenuProformas.Visible = false;
            if (pnlSubmenuProducto.Visible == true)
                pnlSubmenuProducto.Visible = false;
            if (pnlSubmenuProducto.Visible == true)
                pnlSubmenuProducto.Visible = false;
            if (pnlconfiguracion.Visible == true)
                pnlconfiguracion.Visible = false;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #region Clientes
        private void btnClientes_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSubmenuClientes);
        }
        private void btnClientes_Click_1(object sender, EventArgs e)
        {
            openChildForm(new frmClientes());
            //codigo
            hideSubMenu();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            //openChildForm(new frmUsuarios());
            //codigo
            hideSubMenu();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            openChildForm(new frmVendedor());
            //codigo
            hideSubMenu();
        }

        private void btnProveedor_Click_1(object sender, EventArgs e)
        {
            openChildForm(new frmProveedores());
            //codigo
            hideSubMenu();
        }
        #endregion
        #region Proformas
        private void btnProformas_Click(object sender, EventArgs e)
        {
            pnlForm.Controls.Clear();

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

            pnlForm.Controls.Add(frm);
            frm.Show();

            hideSubMenu();
        }


        #endregion
        #region Productos
        private void btnProductos_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSubmenuProducto);
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(childForm);
            pnlForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnAgregarP_Click(object sender, EventArgs e)
        {
            openChildForm(new frmProductos());
            //codigo
            hideSubMenu();
        }

        private void btnServicio_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTiposPS());
            //codigo
            hideSubMenu();
        }

        private void btnTipo_Click(object sender, EventArgs e)
        {
            //nuevo formulario por crear
            //codigo
            hideSubMenu();
        }

        private void bntProductos_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlconfiguracion);
        }

        private void btnCFn_Click(object sender, EventArgs e)
        {
            openChildForm(new frmBodegas());
            hideSubMenu();
        }

        private void btncfn2_Click(object sender, EventArgs e)
        {
            //por crear
            //openChildForm(new frmSucursales());
            hideSubMenu();
        }

        private void btnORVenta_Click(object sender, EventArgs e)
        {
            pnlForm.Controls.Clear();


            frmOrdenVenta frm = new frmOrdenVenta();


            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;


            pnlForm.Controls.Add(frm);


            frm.Show();
        }
    }
}
#endregion