namespace Proformas.Formularios
{
    partial class GestiónProformas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestiónProformas));
            pnlPrincipal = new Panel();
            btnConfiguracioon = new Button();
            pnlconfiguracion = new Panel();
            btncfnSucursales = new FontAwesome.Sharp.IconButton();
            btnCFnBodegas = new FontAwesome.Sharp.IconButton();
            btnOrdenVenta = new Button();
            btnReportes = new Button();
            pnlSubmenuProducto = new Panel();
            btnTipo = new FontAwesome.Sharp.IconButton();
            btnServicio = new FontAwesome.Sharp.IconButton();
            btnAgregarP = new FontAwesome.Sharp.IconButton();
            btnProductos = new Button();
            btnProformas = new Button();
            pnlSubmenuClientes = new Panel();
            btnProveedor = new FontAwesome.Sharp.IconButton();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            btnUsuario = new FontAwesome.Sharp.IconButton();
            btnClientes = new FontAwesome.Sharp.IconButton();
            btnUsuarios = new Button();
            panel2 = new Panel();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pnlForm = new Panel();
            pictureBox1 = new PictureBox();
            pnlPrincipal.SuspendLayout();
            pnlconfiguracion.SuspendLayout();
            pnlSubmenuProducto.SuspendLayout();
            pnlSubmenuClientes.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlPrincipal
            // 
            pnlPrincipal.AutoScroll = true;
            pnlPrincipal.BackColor = Color.FromArgb(49, 64, 95);
            pnlPrincipal.Controls.Add(btnConfiguracioon);
            pnlPrincipal.Controls.Add(pnlconfiguracion);
            pnlPrincipal.Controls.Add(btnOrdenVenta);
            pnlPrincipal.Controls.Add(btnReportes);
            pnlPrincipal.Controls.Add(pnlSubmenuProducto);
            pnlPrincipal.Controls.Add(btnProductos);
            pnlPrincipal.Controls.Add(btnProformas);
            pnlPrincipal.Controls.Add(pnlSubmenuClientes);
            pnlPrincipal.Controls.Add(btnUsuarios);
            pnlPrincipal.Controls.Add(panel2);
            pnlPrincipal.Dock = DockStyle.Left;
            pnlPrincipal.ForeColor = Color.FromArgb(11, 7, 17);
            pnlPrincipal.Location = new Point(0, 0);
            pnlPrincipal.Name = "pnlPrincipal";
            pnlPrincipal.Size = new Size(213, 600);
            pnlPrincipal.TabIndex = 0;
            pnlPrincipal.Paint += panel1_Paint;
            // 
            // btnConfiguracioon
            // 
            btnConfiguracioon.BackColor = Color.FromArgb(49, 64, 95);
            btnConfiguracioon.Dock = DockStyle.Top;
            btnConfiguracioon.FlatAppearance.BorderSize = 0;
            btnConfiguracioon.FlatAppearance.MouseDownBackColor = Color.FromArgb(37, 37, 37);
            btnConfiguracioon.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 37, 37);
            btnConfiguracioon.FlatStyle = FlatStyle.Flat;
            btnConfiguracioon.Font = new Font("Mongolian Baiti", 9F, FontStyle.Bold);
            btnConfiguracioon.ForeColor = Color.Gainsboro;
            btnConfiguracioon.Location = new Point(0, 523);
            btnConfiguracioon.Name = "btnConfiguracioon";
            btnConfiguracioon.Padding = new Padding(10, 0, 0, 0);
            btnConfiguracioon.Size = new Size(196, 40);
            btnConfiguracioon.TabIndex = 4;
            btnConfiguracioon.Text = "Configuración";
            btnConfiguracioon.TextAlign = ContentAlignment.MiddleLeft;
            btnConfiguracioon.UseVisualStyleBackColor = false;
            btnConfiguracioon.Click += btnConfiguracioon_Click;
            // 
            // pnlconfiguracion
            // 
            pnlconfiguracion.BackColor = Color.FromArgb(49, 64, 95);
            pnlconfiguracion.Controls.Add(btncfnSucursales);
            pnlconfiguracion.Controls.Add(btnCFnBodegas);
            pnlconfiguracion.Dock = DockStyle.Bottom;
            pnlconfiguracion.Location = new Point(0, 563);
            pnlconfiguracion.Name = "pnlconfiguracion";
            pnlconfiguracion.Size = new Size(196, 76);
            pnlconfiguracion.TabIndex = 8;
            // 
            // btncfnSucursales
            // 
            btncfnSucursales.BackColor = Color.FromArgb(20, 64, 120);
            btncfnSucursales.Dock = DockStyle.Top;
            btncfnSucursales.Font = new Font("Mongolian Baiti", 9F, FontStyle.Bold);
            btncfnSucursales.ForeColor = Color.Gainsboro;
            btncfnSucursales.IconChar = FontAwesome.Sharp.IconChar.PersonCirclePlus;
            btncfnSucursales.IconColor = Color.White;
            btncfnSucursales.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btncfnSucursales.IconSize = 30;
            btncfnSucursales.Location = new Point(0, 35);
            btncfnSucursales.Margin = new Padding(4, 3, 10, 3);
            btncfnSucursales.Name = "btncfnSucursales";
            btncfnSucursales.Size = new Size(196, 35);
            btncfnSucursales.TabIndex = 9;
            btncfnSucursales.Text = "Servicios";
            btncfnSucursales.TextAlign = ContentAlignment.MiddleRight;
            btncfnSucursales.TextImageRelation = TextImageRelation.TextBeforeImage;
            btncfnSucursales.UseMnemonic = false;
            btncfnSucursales.UseVisualStyleBackColor = false;
            btncfnSucursales.Click += btncfn2_Click;
            // 
            // btnCFnBodegas
            // 
            btnCFnBodegas.BackColor = Color.FromArgb(20, 64, 120);
            btnCFnBodegas.Dock = DockStyle.Top;
            btnCFnBodegas.Font = new Font("Mongolian Baiti", 9F, FontStyle.Bold);
            btnCFnBodegas.ForeColor = Color.Gainsboro;
            btnCFnBodegas.IconChar = FontAwesome.Sharp.IconChar.PersonCirclePlus;
            btnCFnBodegas.IconColor = Color.White;
            btnCFnBodegas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCFnBodegas.IconSize = 30;
            btnCFnBodegas.Location = new Point(0, 0);
            btnCFnBodegas.Margin = new Padding(4, 3, 10, 3);
            btnCFnBodegas.Name = "btnCFnBodegas";
            btnCFnBodegas.Size = new Size(196, 35);
            btnCFnBodegas.TabIndex = 8;
            btnCFnBodegas.Text = "Bodegas";
            btnCFnBodegas.TextAlign = ContentAlignment.MiddleRight;
            btnCFnBodegas.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnCFnBodegas.UseMnemonic = false;
            btnCFnBodegas.UseVisualStyleBackColor = false;
            btnCFnBodegas.Click += btnCFn_Click;
            // 
            // btnOrdenVenta
            // 
            btnOrdenVenta.BackColor = Color.FromArgb(49, 64, 95);
            btnOrdenVenta.Dock = DockStyle.Top;
            btnOrdenVenta.FlatAppearance.BorderSize = 0;
            btnOrdenVenta.FlatAppearance.MouseDownBackColor = Color.FromArgb(37, 37, 37);
            btnOrdenVenta.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 37, 37);
            btnOrdenVenta.FlatStyle = FlatStyle.Flat;
            btnOrdenVenta.Font = new Font("Mongolian Baiti", 9F, FontStyle.Bold);
            btnOrdenVenta.ForeColor = Color.Gainsboro;
            btnOrdenVenta.Location = new Point(0, 483);
            btnOrdenVenta.Name = "btnOrdenVenta";
            btnOrdenVenta.Padding = new Padding(10, 0, 0, 0);
            btnOrdenVenta.Size = new Size(196, 40);
            btnOrdenVenta.TabIndex = 8;
            btnOrdenVenta.Text = "Orden de Venta";
            btnOrdenVenta.TextAlign = ContentAlignment.MiddleLeft;
            btnOrdenVenta.UseVisualStyleBackColor = false;
            btnOrdenVenta.Click += btnConfiguracion_Click;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.FromArgb(49, 64, 95);
            btnReportes.Dock = DockStyle.Top;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatAppearance.MouseDownBackColor = Color.FromArgb(37, 37, 37);
            btnReportes.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 37, 37);
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Mongolian Baiti", 9F, FontStyle.Bold);
            btnReportes.ForeColor = Color.Gainsboro;
            btnReportes.Location = new Point(0, 443);
            btnReportes.Name = "btnReportes";
            btnReportes.Padding = new Padding(10, 0, 0, 0);
            btnReportes.Size = new Size(196, 40);
            btnReportes.TabIndex = 7;
            btnReportes.Text = "Reportes";
            btnReportes.TextAlign = ContentAlignment.MiddleLeft;
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += bntProductos_Click;
            // 
            // pnlSubmenuProducto
            // 
            pnlSubmenuProducto.BackColor = Color.FromArgb(49, 64, 95);
            pnlSubmenuProducto.Controls.Add(btnTipo);
            pnlSubmenuProducto.Controls.Add(btnServicio);
            pnlSubmenuProducto.Controls.Add(btnAgregarP);
            pnlSubmenuProducto.Dock = DockStyle.Top;
            pnlSubmenuProducto.Location = new Point(0, 332);
            pnlSubmenuProducto.Name = "pnlSubmenuProducto";
            pnlSubmenuProducto.Size = new Size(196, 111);
            pnlSubmenuProducto.TabIndex = 6;
            // 
            // btnTipo
            // 
            btnTipo.BackColor = Color.FromArgb(20, 64, 120);
            btnTipo.Dock = DockStyle.Top;
            btnTipo.Font = new Font("Mongolian Baiti", 9F, FontStyle.Bold);
            btnTipo.ForeColor = Color.Gainsboro;
            btnTipo.IconChar = FontAwesome.Sharp.IconChar.PersonCirclePlus;
            btnTipo.IconColor = Color.WhiteSmoke;
            btnTipo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTipo.IconSize = 30;
            btnTipo.Location = new Point(0, 70);
            btnTipo.Margin = new Padding(4, 3, 10, 3);
            btnTipo.Name = "btnTipo";
            btnTipo.Size = new Size(196, 35);
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
            btnServicio.BackColor = Color.FromArgb(20, 64, 120);
            btnServicio.Dock = DockStyle.Top;
            btnServicio.Font = new Font("Mongolian Baiti", 9F, FontStyle.Bold);
            btnServicio.ForeColor = Color.Gainsboro;
            btnServicio.IconChar = FontAwesome.Sharp.IconChar.PersonCirclePlus;
            btnServicio.IconColor = Color.WhiteSmoke;
            btnServicio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnServicio.IconSize = 30;
            btnServicio.Location = new Point(0, 35);
            btnServicio.Margin = new Padding(4, 3, 10, 3);
            btnServicio.Name = "btnServicio";
            btnServicio.Size = new Size(196, 35);
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
            btnAgregarP.BackColor = Color.FromArgb(20, 64, 120);
            btnAgregarP.Dock = DockStyle.Top;
            btnAgregarP.Font = new Font("Mongolian Baiti", 9F, FontStyle.Bold);
            btnAgregarP.ForeColor = Color.Gainsboro;
            btnAgregarP.IconChar = FontAwesome.Sharp.IconChar.ObjectGroup;
            btnAgregarP.IconColor = Color.WhiteSmoke;
            btnAgregarP.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAgregarP.IconSize = 30;
            btnAgregarP.Location = new Point(0, 0);
            btnAgregarP.Margin = new Padding(4, 3, 10, 3);
            btnAgregarP.Name = "btnAgregarP";
            btnAgregarP.Size = new Size(196, 35);
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
            btnProductos.BackColor = Color.FromArgb(49, 64, 95);
            btnProductos.Dock = DockStyle.Top;
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.FlatAppearance.MouseDownBackColor = Color.FromArgb(37, 37, 37);
            btnProductos.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 37, 37);
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Mongolian Baiti", 9F, FontStyle.Bold);
            btnProductos.ForeColor = Color.Gainsboro;
            btnProductos.Location = new Point(0, 292);
            btnProductos.Name = "btnProductos";
            btnProductos.Padding = new Padding(10, 0, 0, 0);
            btnProductos.Size = new Size(196, 40);
            btnProductos.TabIndex = 5;
            btnProductos.Text = "Productos";
            btnProductos.TextAlign = ContentAlignment.MiddleLeft;
            btnProductos.UseVisualStyleBackColor = false;
            btnProductos.Click += btnProductos_Click;
            // 
            // btnProformas
            // 
            btnProformas.BackColor = Color.FromArgb(49, 64, 95);
            btnProformas.Dock = DockStyle.Top;
            btnProformas.FlatAppearance.BorderSize = 0;
            btnProformas.FlatAppearance.MouseDownBackColor = Color.FromArgb(37, 37, 37);
            btnProformas.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 37, 37);
            btnProformas.FlatStyle = FlatStyle.Flat;
            btnProformas.Font = new Font("Mongolian Baiti", 9F, FontStyle.Bold);
            btnProformas.ForeColor = Color.Gainsboro;
            btnProformas.Location = new Point(0, 252);
            btnProformas.Name = "btnProformas";
            btnProformas.Padding = new Padding(10, 0, 0, 0);
            btnProformas.Size = new Size(196, 40);
            btnProformas.TabIndex = 3;
            btnProformas.Text = "Proformas";
            btnProformas.TextAlign = ContentAlignment.MiddleLeft;
            btnProformas.UseVisualStyleBackColor = false;
            btnProformas.Click += btnProformas_Click;
            // 
            // pnlSubmenuClientes
            // 
            pnlSubmenuClientes.BackColor = Color.FromArgb(49, 64, 95);
            pnlSubmenuClientes.Controls.Add(btnProveedor);
            pnlSubmenuClientes.Controls.Add(iconButton2);
            pnlSubmenuClientes.Controls.Add(btnUsuario);
            pnlSubmenuClientes.Controls.Add(btnClientes);
            pnlSubmenuClientes.Dock = DockStyle.Top;
            pnlSubmenuClientes.Location = new Point(0, 104);
            pnlSubmenuClientes.Name = "pnlSubmenuClientes";
            pnlSubmenuClientes.Size = new Size(196, 148);
            pnlSubmenuClientes.TabIndex = 1;
            // 
            // btnProveedor
            // 
            btnProveedor.BackColor = Color.FromArgb(20, 64, 120);
            btnProveedor.Dock = DockStyle.Top;
            btnProveedor.Font = new Font("Mongolian Baiti", 9F, FontStyle.Bold);
            btnProveedor.ForeColor = Color.Gainsboro;
            btnProveedor.IconChar = FontAwesome.Sharp.IconChar.PersonRays;
            btnProveedor.IconColor = Color.WhiteSmoke;
            btnProveedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnProveedor.IconSize = 30;
            btnProveedor.Location = new Point(0, 105);
            btnProveedor.Margin = new Padding(10, 3, 10, 3);
            btnProveedor.Name = "btnProveedor";
            btnProveedor.Size = new Size(196, 35);
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
            iconButton2.BackColor = Color.FromArgb(20, 64, 120);
            iconButton2.Dock = DockStyle.Top;
            iconButton2.Font = new Font("Mongolian Baiti", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconButton2.ForeColor = Color.Gainsboro;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.PersonChalkboard;
            iconButton2.IconColor = Color.WhiteSmoke;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 30;
            iconButton2.Location = new Point(0, 70);
            iconButton2.Margin = new Padding(10, 3, 10, 3);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(196, 35);
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
            btnUsuario.BackColor = Color.FromArgb(20, 64, 120);
            btnUsuario.Dock = DockStyle.Top;
            btnUsuario.Font = new Font("Mongolian Baiti", 9F, FontStyle.Bold);
            btnUsuario.ForeColor = Color.Gainsboro;
            btnUsuario.IconChar = FontAwesome.Sharp.IconChar.PersonCircleExclamation;
            btnUsuario.IconColor = Color.WhiteSmoke;
            btnUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUsuario.IconSize = 30;
            btnUsuario.Location = new Point(0, 35);
            btnUsuario.Margin = new Padding(10, 3, 10, 3);
            btnUsuario.Name = "btnUsuario";
            btnUsuario.Size = new Size(196, 35);
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
            btnClientes.BackColor = Color.FromArgb(20, 64, 120);
            btnClientes.Dock = DockStyle.Top;
            btnClientes.Font = new Font("Mongolian Baiti", 9F, FontStyle.Bold);
            btnClientes.ForeColor = Color.Gainsboro;
            btnClientes.IconChar = FontAwesome.Sharp.IconChar.PersonCirclePlus;
            btnClientes.IconColor = Color.White;
            btnClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClientes.IconSize = 30;
            btnClientes.Location = new Point(0, 0);
            btnClientes.Margin = new Padding(4, 3, 10, 3);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(196, 35);
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
            btnUsuarios.BackColor = Color.FromArgb(49, 64, 95);
            btnUsuarios.Dock = DockStyle.Top;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatAppearance.MouseDownBackColor = Color.FromArgb(37, 37, 37);
            btnUsuarios.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 37, 37);
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Mongolian Baiti", 9F, FontStyle.Bold);
            btnUsuarios.ForeColor = Color.Gainsboro;
            btnUsuarios.Location = new Point(0, 64);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new Padding(10, 0, 0, 0);
            btnUsuarios.Size = new Size(196, 40);
            btnUsuarios.TabIndex = 1;
            btnUsuarios.Text = "Agregar";
            btnUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.UseVisualStyleBackColor = false;
            btnUsuarios.Click += btnClientes_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(49, 64, 95);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(196, 64);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Perpetua", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(49, 18);
            label1.Name = "label1";
            label1.Size = new Size(142, 34);
            label1.TabIndex = 2;
            label1.Text = "Gestión de Proformas\r\nChatGPT";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(3, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(43, 63);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pnlForm
            // 
            pnlForm.BackColor = Color.FromArgb(20, 64, 120);
            pnlForm.Controls.Add(pictureBox1);
            pnlForm.Dock = DockStyle.Fill;
            pnlForm.Location = new Point(213, 0);
            pnlForm.Name = "pnlForm";
            pnlForm.Size = new Size(737, 600);
            pnlForm.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(283, 64);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(178, 244);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // GestiónProformas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(950, 600);
            Controls.Add(pnlForm);
            Controls.Add(pnlPrincipal);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(950, 600);
            Name = "GestiónProformas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmMenu";
            pnlPrincipal.ResumeLayout(false);
            pnlconfiguracion.ResumeLayout(false);
            pnlSubmenuProducto.ResumeLayout(false);
            pnlSubmenuClientes.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pnlForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlPrincipal;
        private Panel pnlSubmenuClientes;
        private Button btnUsuarios;
        private Button btnReportes;
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
        private Panel pnlconfiguracion;
        private FontAwesome.Sharp.IconButton btncfnSucursales;
        private FontAwesome.Sharp.IconButton btnCFnBodegas;
        private Button btnOrdenVenta;
        private PictureBox pictureBox1;
        private Panel panel2;
        private PictureBox pictureBox2;
        private Label label1;
        private Button btnConfiguracioon;
    }
}