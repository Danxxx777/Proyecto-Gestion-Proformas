﻿namespace Proformas.Formularios
{
    partial class frmInterfazPrincipal
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInterfazPrincipal));
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            pbxCerrar = new PictureBox();
            guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxCerrar).BeginInit();
            SuspendLayout();
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.Controls.Add(pbxCerrar);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges1;
            guna2CustomGradientPanel1.FillColor = Color.Indigo;
            guna2CustomGradientPanel1.FillColor2 = Color.FromArgb(64, 0, 64);
            guna2CustomGradientPanel1.FillColor3 = Color.DarkViolet;
            guna2CustomGradientPanel1.FillColor4 = Color.DeepSkyBlue;
            guna2CustomGradientPanel1.Location = new Point(0, 0);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2CustomGradientPanel1.Size = new Size(802, 45);
            guna2CustomGradientPanel1.TabIndex = 4;
            guna2CustomGradientPanel1.Paint += this.guna2CustomGradientPanel1_Paint;
            // 
            // pbxCerrar
            // 
            pbxCerrar.BackColor = Color.Transparent;
            pbxCerrar.Image = (Image)resources.GetObject("pbxCerrar.Image");
            pbxCerrar.Location = new Point(748, 3);
            pbxCerrar.Name = "pbxCerrar";
            pbxCerrar.Size = new Size(40, 36);
            pbxCerrar.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCerrar.TabIndex = 0;
            pbxCerrar.TabStop = false;
            pbxCerrar.Click += this.pbxCerrar_Click;
            // 
            // frmInterfazPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(guna2CustomGradientPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmInterfazPrincipal";
            Text = "InterfazPrincipal";
            Load += this.frmInterfazPrincipal_Load;
            guna2CustomGradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxCerrar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private PictureBox pbxCerrar;
    }
}