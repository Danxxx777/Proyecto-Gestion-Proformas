namespace Proformas.Formularios
{
    partial class frmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlPrincipal = new Panel();
            bntProductos = new Button();
            pnlSubmenuProducto = new Panel();
            btnSucursal = new FontAwesome.Sharp.IconButton();
            btnBodegas = new FontAwesome.Sharp.IconButton();
            btnTipo = new FontAwesome.Sharp.IconButton();
            btnServicio = new FontAwesome.Sharp.IconButton();
            btnAgregarP = new FontAwesome.Sharp.IconButton();
            btnProductos = new Button();
            pnlSubmenuProformas = new Panel();
            btnOV = new Button();
            btnProformas = new Button();
            pnlSubmenuClientes = new Panel();
            btnProveedor = new FontAwesome.Sharp.IconButton();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            btnUsuario = new FontAwesome.Sharp.IconButton();
            btnClientes = new FontAwesome.Sharp.IconButton();
            btnUsuarios = new Button();
            panel2 = new Panel();
            pnlNose = new Panel();
            pnlForm = new Panel();
            panel1 = new Panel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            iconButton4 = new FontAwesome.Sharp.IconButton();
            iconButton5 = new FontAwesome.Sharp.IconButton();
            iconButton6 = new FontAwesome.Sharp.IconButton();
            pnlPrincipal.SuspendLayout();
            pnlSubmenuProducto.SuspendLayout();
            pnlSubmenuProformas.SuspendLayout();
            pnlSubmenuClientes.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPrincipal
            // 
            pnlPrincipal.AutoScroll = true;
            pnlPrincipal.BackColor = Color.FromArgb(11, 7, 17);
            pnlPrincipal.Controls.Add(panel1);
            pnlPrincipal.Controls.Add(bntProductos);
            pnlPrincipal.Controls.Add(pnlSubmenuProducto);
            pnlPrincipal.Controls.Add(btnProductos);
            pnlPrincipal.Controls.Add(pnlSubmenuProformas);
            pnlPrincipal.Controls.Add(btnProformas);
            pnlPrincipal.Controls.Add(pnlSubmenuClientes);
            pnlPrincipal.Controls.Add(btnUsuarios);
            pnlPrincipal.Controls.Add(panel2);
            pnlPrincipal.Dock = DockStyle.Left;
            pnlPrincipal.ForeColor = Color.FromArgb(11, 7, 17);
            pnlPrincipal.Location = new Point(0, 0);
            pnlPrincipal.Name = "pnlPrincipal";
            pnlPrincipal.Size = new Size(208, 561);
            pnlPrincipal.TabIndex = 0;
            pnlPrincipal.Paint += panel1_Paint;
            // 
            // bntProductos
            // 
            bntProductos.Dock = DockStyle.Top;
            bntProductos.FlatAppearance.BorderSize = 0;
            bntProductos.FlatAppearance.MouseDownBackColor = Color.FromArgb(37, 37, 37);
            bntProductos.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 37, 37);
            bntProductos.FlatStyle = FlatStyle.Flat;
            bntProductos.ForeColor = Color.Gainsboro;
            bntProductos.Location = new Point(0, 530);
            bntProductos.Name = "bntProductos";
            bntProductos.Padding = new Padding(10, 0, 0, 0);
            bntProductos.Size = new Size(191, 45);
            bntProductos.TabIndex = 7;
            bntProductos.Text = "Productos";
            bntProductos.TextAlign = ContentAlignment.MiddleLeft;
            bntProductos.UseVisualStyleBackColor = true;
            // 
            // pnlSubmenuProducto
            // 
            pnlSubmenuProducto.Controls.Add(btnSucursal);
            pnlSubmenuProducto.Controls.Add(btnBodegas);
            pnlSubmenuProducto.Controls.Add(btnTipo);
            pnlSubmenuProducto.Controls.Add(btnServicio);
            pnlSubmenuProducto.Controls.Add(btnAgregarP);
            pnlSubmenuProducto.Dock = DockStyle.Top;
            pnlSubmenuProducto.Location = new Point(0, 339);
            pnlSubmenuProducto.Name = "pnlSubmenuProducto";
            pnlSubmenuProducto.Size = new Size(191, 191);
            pnlSubmenuProducto.TabIndex = 6;
            // 
            // btnSucursal
            // 
            btnSucursal.BackColor = Color.FromArgb(31, 30, 68);
            btnSucursal.Dock = DockStyle.Top;
            btnSucursal.ForeColor = Color.Gainsboro;
            btnSucursal.IconChar = FontAwesome.Sharp.IconChar.PersonCirclePlus;
            btnSucursal.IconColor = Color.Black;
            btnSucursal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSucursal.IconSize = 30;
            btnSucursal.Location = new Point(0, 140);
            btnSucursal.Margin = new Padding(4, 3, 10, 3);
            btnSucursal.Name = "btnSucursal";
            btnSucursal.Size = new Size(191, 35);
            btnSucursal.TabIndex = 12;
            btnSucursal.Text = "Sucursales";
            btnSucursal.TextAlign = ContentAlignment.MiddleRight;
            btnSucursal.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnSucursal.UseMnemonic = false;
            btnSucursal.UseVisualStyleBackColor = false;
            btnSucursal.Click += btnSucursal_Click;
            // 
            // btnBodegas
            // 
            btnBodegas.BackColor = Color.FromArgb(31, 30, 68);
            btnBodegas.Dock = DockStyle.Top;
            btnBodegas.ForeColor = Color.Gainsboro;
            btnBodegas.IconChar = FontAwesome.Sharp.IconChar.PersonCirclePlus;
            btnBodegas.IconColor = Color.Black;
            btnBodegas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBodegas.IconSize = 30;
            btnBodegas.Location = new Point(0, 105);
            btnBodegas.Margin = new Padding(4, 3, 10, 3);
            btnBodegas.Name = "btnBodegas";
            btnBodegas.Size = new Size(191, 35);
            btnBodegas.TabIndex = 11;
            btnBodegas.Text = "Bodegas ";
            btnBodegas.TextAlign = ContentAlignment.MiddleRight;
            btnBodegas.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnBodegas.UseMnemonic = false;
            btnBodegas.UseVisualStyleBackColor = false;
            btnBodegas.Click += btnBodegas_Click_1;
            // 
            // btnTipo
            // 
            btnTipo.BackColor = Color.FromArgb(31, 30, 68);
            btnTipo.Dock = DockStyle.Top;
            btnTipo.ForeColor = Color.Gainsboro;
            btnTipo.IconChar = FontAwesome.Sharp.IconChar.PersonCirclePlus;
            btnTipo.IconColor = Color.Black;
            btnTipo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTipo.IconSize = 30;
            btnTipo.Location = new Point(0, 70);
            btnTipo.Margin = new Padding(4, 3, 10, 3);
            btnTipo.Name = "btnTipo";
            btnTipo.Size = new Size(191, 35);
            btnTipo.TabIndex = 10;
            btnTipo.Text = "Tipos";
            btnTipo.TextAlign = ContentAlignment.MiddleRight;
            btnTipo.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnTipo.UseMnemonic = false;
            btnTipo.UseVisualStyleBackColor = false;
            btnTipo.Click += btnTipo_Click;
            // 
            // btnServicio
            // 
            btnServicio.BackColor = Color.FromArgb(31, 30, 68);
            btnServicio.Dock = DockStyle.Top;
            btnServicio.ForeColor = Color.Gainsboro;
            btnServicio.IconChar = FontAwesome.Sharp.IconChar.PersonCirclePlus;
            btnServicio.IconColor = Color.Black;
            btnServicio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnServicio.IconSize = 30;
            btnServicio.Location = new Point(0, 35);
            btnServicio.Margin = new Padding(4, 3, 10, 3);
            btnServicio.Name = "btnServicio";
            btnServicio.Size = new Size(191, 35);
            btnServicio.TabIndex = 9;
            btnServicio.Text = "Servicios";
            btnServicio.TextAlign = ContentAlignment.MiddleRight;
            btnServicio.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnServicio.UseMnemonic = false;
            btnServicio.UseVisualStyleBackColor = false;
            btnServicio.Click += btnServicio_Click;
            // 
            // btnAgregarP
            // 
            btnAgregarP.BackColor = Color.FromArgb(31, 30, 68);
            btnAgregarP.Dock = DockStyle.Top;
            btnAgregarP.ForeColor = Color.Gainsboro;
            btnAgregarP.IconChar = FontAwesome.Sharp.IconChar.PersonCirclePlus;
            btnAgregarP.IconColor = Color.Black;
            btnAgregarP.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAgregarP.IconSize = 30;
            btnAgregarP.Location = new Point(0, 0);
            btnAgregarP.Margin = new Padding(4, 3, 10, 3);
            btnAgregarP.Name = "btnAgregarP";
            btnAgregarP.Size = new Size(191, 35);
            btnAgregarP.TabIndex = 8;
            btnAgregarP.Text = "Agregar/Editar";
            btnAgregarP.TextAlign = ContentAlignment.MiddleRight;
            btnAgregarP.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnAgregarP.UseMnemonic = false;
            btnAgregarP.UseVisualStyleBackColor = false;
            btnAgregarP.Click += btnAgregarP_Click;
            // 
            // btnProductos
            // 
            btnProductos.Dock = DockStyle.Top;
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.FlatAppearance.MouseDownBackColor = Color.FromArgb(37, 37, 37);
            btnProductos.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 37, 37);
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.ForeColor = Color.Gainsboro;
            btnProductos.Location = new Point(0, 294);
            btnProductos.Name = "btnProductos";
            btnProductos.Padding = new Padding(10, 0, 0, 0);
            btnProductos.Size = new Size(191, 45);
            btnProductos.TabIndex = 5;
            btnProductos.Text = "Productos";
            btnProductos.TextAlign = ContentAlignment.MiddleLeft;
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;
            // 
            // pnlSubmenuProformas
            // 
            pnlSubmenuProformas.Controls.Add(btnOV);
            pnlSubmenuProformas.Dock = DockStyle.Top;
            pnlSubmenuProformas.Location = new Point(0, 253);
            pnlSubmenuProformas.Name = "pnlSubmenuProformas";
            pnlSubmenuProformas.Size = new Size(191, 41);
            pnlSubmenuProformas.TabIndex = 4;
            // 
            // btnOV
            // 
            btnOV.BackColor = Color.FromArgb(11, 7, 17);
            btnOV.Dock = DockStyle.Top;
            btnOV.FlatAppearance.BorderSize = 0;
            btnOV.FlatAppearance.MouseDownBackColor = Color.FromArgb(37, 37, 37);
            btnOV.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 37, 37);
            btnOV.FlatStyle = FlatStyle.Flat;
            btnOV.ForeColor = Color.Gainsboro;
            btnOV.Location = new Point(0, 0);
            btnOV.Name = "btnOV";
            btnOV.Padding = new Padding(10, 0, 0, 0);
            btnOV.Size = new Size(191, 40);
            btnOV.TabIndex = 3;
            btnOV.Text = "Orden de Venta ";
            btnOV.TextAlign = ContentAlignment.MiddleLeft;
            btnOV.UseVisualStyleBackColor = false;
            btnOV.Click += btnOV_Click;
            // 
            // btnProformas
            // 
            btnProformas.Dock = DockStyle.Top;
            btnProformas.FlatAppearance.BorderSize = 0;
            btnProformas.FlatAppearance.MouseDownBackColor = Color.FromArgb(37, 37, 37);
            btnProformas.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 37, 37);
            btnProformas.FlatStyle = FlatStyle.Flat;
            btnProformas.ForeColor = Color.Gainsboro;
            btnProformas.Location = new Point(0, 208);
            btnProformas.Name = "btnProformas";
            btnProformas.Padding = new Padding(10, 0, 0, 0);
            btnProformas.Size = new Size(191, 45);
            btnProformas.TabIndex = 3;
            btnProformas.Text = "Proformas";
            btnProformas.TextAlign = ContentAlignment.MiddleLeft;
            btnProformas.UseVisualStyleBackColor = true;
            btnProformas.Click += btnProformas_Click;
            // 
            // pnlSubmenuClientes
            // 
            pnlSubmenuClientes.Controls.Add(btnProveedor);
            pnlSubmenuClientes.Controls.Add(iconButton2);
            pnlSubmenuClientes.Controls.Add(btnUsuario);
            pnlSubmenuClientes.Controls.Add(btnClientes);
            pnlSubmenuClientes.Dock = DockStyle.Top;
            pnlSubmenuClientes.Location = new Point(0, 60);
            pnlSubmenuClientes.Name = "pnlSubmenuClientes";
            pnlSubmenuClientes.Size = new Size(191, 148);
            pnlSubmenuClientes.TabIndex = 1;
            // 
            // btnProveedor
            // 
            btnProveedor.BackColor = Color.FromArgb(31, 30, 68);
            btnProveedor.Dock = DockStyle.Top;
            btnProveedor.ForeColor = Color.Gainsboro;
            btnProveedor.IconChar = FontAwesome.Sharp.IconChar.PersonRays;
            btnProveedor.IconColor = Color.Black;
            btnProveedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnProveedor.IconSize = 30;
            btnProveedor.Location = new Point(0, 105);
            btnProveedor.Margin = new Padding(10, 3, 10, 3);
            btnProveedor.Name = "btnProveedor";
            btnProveedor.Size = new Size(191, 35);
            btnProveedor.TabIndex = 7;
            btnProveedor.Text = "Proveedor";
            btnProveedor.TextAlign = ContentAlignment.MiddleRight;
            btnProveedor.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnProveedor.UseMnemonic = false;
            btnProveedor.UseVisualStyleBackColor = false;
            btnProveedor.Click += btnProveedor_Click_1;
            // 
            // iconButton2
            // 
            iconButton2.BackColor = Color.FromArgb(31, 30, 68);
            iconButton2.Dock = DockStyle.Top;
            iconButton2.ForeColor = Color.Gainsboro;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.PersonChalkboard;
            iconButton2.IconColor = Color.Black;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 30;
            iconButton2.Location = new Point(0, 70);
            iconButton2.Margin = new Padding(10, 3, 10, 3);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(191, 35);
            iconButton2.TabIndex = 6;
            iconButton2.Text = "Vendedor";
            iconButton2.TextAlign = ContentAlignment.MiddleRight;
            iconButton2.TextImageRelation = TextImageRelation.TextBeforeImage;
            iconButton2.UseMnemonic = false;
            iconButton2.UseVisualStyleBackColor = false;
            iconButton2.Click += iconButton2_Click;
            // 
            // btnUsuario
            // 
            btnUsuario.BackColor = Color.FromArgb(31, 30, 68);
            btnUsuario.Dock = DockStyle.Top;
            btnUsuario.ForeColor = Color.Gainsboro;
            btnUsuario.IconChar = FontAwesome.Sharp.IconChar.PersonCircleExclamation;
            btnUsuario.IconColor = Color.Black;
            btnUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUsuario.IconSize = 30;
            btnUsuario.Location = new Point(0, 35);
            btnUsuario.Margin = new Padding(10, 3, 10, 3);
            btnUsuario.Name = "btnUsuario";
            btnUsuario.Size = new Size(191, 35);
            btnUsuario.TabIndex = 5;
            btnUsuario.Text = "Usuarios";
            btnUsuario.TextAlign = ContentAlignment.MiddleRight;
            btnUsuario.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnUsuario.UseMnemonic = false;
            btnUsuario.UseVisualStyleBackColor = false;
            btnUsuario.Click += iconButton1_Click;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.FromArgb(31, 30, 68);
            btnClientes.Dock = DockStyle.Top;
            btnClientes.ForeColor = Color.Gainsboro;
            btnClientes.IconChar = FontAwesome.Sharp.IconChar.PersonCirclePlus;
            btnClientes.IconColor = Color.Black;
            btnClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClientes.IconSize = 30;
            btnClientes.Location = new Point(0, 0);
            btnClientes.Margin = new Padding(4, 3, 10, 3);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(191, 35);
            btnClientes.TabIndex = 0;
            btnClientes.Text = "Clientes";
            btnClientes.TextAlign = ContentAlignment.MiddleRight;
            btnClientes.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnClientes.UseMnemonic = false;
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click_1;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Dock = DockStyle.Top;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatAppearance.MouseDownBackColor = Color.FromArgb(37, 37, 37);
            btnUsuarios.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 37, 37);
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.ForeColor = Color.Gainsboro;
            btnUsuarios.Location = new Point(0, 15);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new Padding(10, 0, 0, 0);
            btnUsuarios.Size = new Size(191, 45);
            btnUsuarios.TabIndex = 1;
            btnUsuarios.Text = "Agregar";
            btnUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnClientes_Click;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(191, 15);
            panel2.TabIndex = 2;
            // 
            // pnlNose
            // 
            pnlNose.BackColor = Color.FromArgb(32, 30, 50);
            pnlNose.Dock = DockStyle.Bottom;
            pnlNose.Location = new Point(208, 456);
            pnlNose.Name = "pnlNose";
            pnlNose.Size = new Size(726, 105);
            pnlNose.TabIndex = 1;
            pnlNose.Paint += pnlNose_Paint;
            // 
            // pnlForm
            // 
            pnlForm.BackColor = Color.FromArgb(32, 30, 50);
            pnlForm.Location = new Point(208, 0);
            pnlForm.Name = "pnlForm";
            pnlForm.Size = new Size(726, 459);
            pnlForm.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(iconButton1);
            panel1.Controls.Add(iconButton3);
            panel1.Controls.Add(iconButton4);
            panel1.Controls.Add(iconButton5);
            panel1.Controls.Add(iconButton6);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 575);
            panel1.Name = "panel1";
            panel1.Size = new Size(191, 191);
            panel1.TabIndex = 8;
            // 
            // iconButton1
            // 
            iconButton1.BackColor = Color.FromArgb(31, 30, 68);
            iconButton1.Dock = DockStyle.Top;
            iconButton1.ForeColor = Color.Gainsboro;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.PersonCirclePlus;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 30;
            iconButton1.Location = new Point(0, 140);
            iconButton1.Margin = new Padding(4, 3, 10, 3);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(191, 35);
            iconButton1.TabIndex = 12;
            iconButton1.Text = "Sucursales";
            iconButton1.TextAlign = ContentAlignment.MiddleRight;
            iconButton1.TextImageRelation = TextImageRelation.TextBeforeImage;
            iconButton1.UseMnemonic = false;
            iconButton1.UseVisualStyleBackColor = false;
            // 
            // iconButton3
            // 
            iconButton3.BackColor = Color.FromArgb(31, 30, 68);
            iconButton3.Dock = DockStyle.Top;
            iconButton3.ForeColor = Color.Gainsboro;
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.PersonCirclePlus;
            iconButton3.IconColor = Color.Black;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.IconSize = 30;
            iconButton3.Location = new Point(0, 105);
            iconButton3.Margin = new Padding(4, 3, 10, 3);
            iconButton3.Name = "iconButton3";
            iconButton3.Size = new Size(191, 35);
            iconButton3.TabIndex = 11;
            iconButton3.Text = "Bodegas ";
            iconButton3.TextAlign = ContentAlignment.MiddleRight;
            iconButton3.TextImageRelation = TextImageRelation.TextBeforeImage;
            iconButton3.UseMnemonic = false;
            iconButton3.UseVisualStyleBackColor = false;
            // 
            // iconButton4
            // 
            iconButton4.BackColor = Color.FromArgb(31, 30, 68);
            iconButton4.Dock = DockStyle.Top;
            iconButton4.ForeColor = Color.Gainsboro;
            iconButton4.IconChar = FontAwesome.Sharp.IconChar.PersonCirclePlus;
            iconButton4.IconColor = Color.Black;
            iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton4.IconSize = 30;
            iconButton4.Location = new Point(0, 70);
            iconButton4.Margin = new Padding(4, 3, 10, 3);
            iconButton4.Name = "iconButton4";
            iconButton4.Size = new Size(191, 35);
            iconButton4.TabIndex = 10;
            iconButton4.Text = "Tipos";
            iconButton4.TextAlign = ContentAlignment.MiddleRight;
            iconButton4.TextImageRelation = TextImageRelation.TextBeforeImage;
            iconButton4.UseMnemonic = false;
            iconButton4.UseVisualStyleBackColor = false;
            // 
            // iconButton5
            // 
            iconButton5.BackColor = Color.FromArgb(31, 30, 68);
            iconButton5.Dock = DockStyle.Top;
            iconButton5.ForeColor = Color.Gainsboro;
            iconButton5.IconChar = FontAwesome.Sharp.IconChar.PersonCirclePlus;
            iconButton5.IconColor = Color.Black;
            iconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton5.IconSize = 30;
            iconButton5.Location = new Point(0, 35);
            iconButton5.Margin = new Padding(4, 3, 10, 3);
            iconButton5.Name = "iconButton5";
            iconButton5.Size = new Size(191, 35);
            iconButton5.TabIndex = 9;
            iconButton5.Text = "Servicios";
            iconButton5.TextAlign = ContentAlignment.MiddleRight;
            iconButton5.TextImageRelation = TextImageRelation.TextBeforeImage;
            iconButton5.UseMnemonic = false;
            iconButton5.UseVisualStyleBackColor = false;
            // 
            // iconButton6
            // 
            iconButton6.BackColor = Color.FromArgb(31, 30, 68);
            iconButton6.Dock = DockStyle.Top;
            iconButton6.ForeColor = Color.Gainsboro;
            iconButton6.IconChar = FontAwesome.Sharp.IconChar.PersonCirclePlus;
            iconButton6.IconColor = Color.Black;
            iconButton6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton6.IconSize = 30;
            iconButton6.Location = new Point(0, 0);
            iconButton6.Margin = new Padding(4, 3, 10, 3);
            iconButton6.Name = "iconButton6";
            iconButton6.Size = new Size(191, 35);
            iconButton6.TabIndex = 8;
            iconButton6.Text = "Agregar/Editar";
            iconButton6.TextAlign = ContentAlignment.MiddleRight;
            iconButton6.TextImageRelation = TextImageRelation.TextBeforeImage;
            iconButton6.UseMnemonic = false;
            iconButton6.UseVisualStyleBackColor = false;
            // 
            // frmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(934, 561);
            Controls.Add(pnlForm);
            Controls.Add(pnlNose);
            Controls.Add(pnlPrincipal);
            MinimumSize = new Size(950, 600);
            Name = "frmMenu";
            Text = "frmMenu";
            pnlPrincipal.ResumeLayout(false);
            pnlSubmenuProducto.ResumeLayout(false);
            pnlSubmenuProformas.ResumeLayout(false);
            pnlSubmenuClientes.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlPrincipal;
        private Panel pnlSubmenuClientes;
        private Button btnUsuarios;
        private Panel panel2;
        private Button bntProductos;
        private Panel pnlSubmenuProducto;
        private Button btnProductos;
        private Button btnProformas;
        private Panel pnlSubmenuProformas;
        private Button btnOV;
        private Panel pnlNose;
        private Panel pnlForm;
        private FontAwesome.Sharp.IconButton btnClientes;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton btnUsuario;
        private FontAwesome.Sharp.IconButton btnProveedor;
        private FontAwesome.Sharp.IconButton btnAgregarP;
        private FontAwesome.Sharp.IconButton btnServicio;
        private FontAwesome.Sharp.IconButton btnTipo;
        private FontAwesome.Sharp.IconButton btnBodegas;
        private FontAwesome.Sharp.IconButton btnSucursal;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton4;
        private FontAwesome.Sharp.IconButton iconButton5;
        private FontAwesome.Sharp.IconButton iconButton6;
    }
}