﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Proformas.Formularios
{
    public partial class GestiónProformas : Form
    {
        public GestiónProformas()
        {
            InitializeComponent();
            customizeDesing();
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
            hideSubMenu();
        }

        private void btnNProforma_Click(object sender, EventArgs e)
        {
            //openChildForm(new frmProformas());
            //codigo
            hideSubMenu();
        }

        private void btnOV_Click(object sender, EventArgs e)
        {

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

        private void btnBodegas_Click_1(object sender, EventArgs e)
        {
            openChildForm(new frmBodegas());
            //codigo
            hideSubMenu();
        }

        private void btnSucursal_Click(object sender, EventArgs e)
        {
            //por hacer
            //openChildForm(new frmSucursales());
            //codigo
            hideSubMenu();
        }

        private void bntProductos_Click(object sender, EventArgs e)
        {

        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnCFn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btncfn2_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnConfiguracioon_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlconfiguracion);
        }
    }
}
#endregion