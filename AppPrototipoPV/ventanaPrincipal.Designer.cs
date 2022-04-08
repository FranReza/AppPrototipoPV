
namespace AppPrototipoPV
{
    partial class ventanaPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_desconectarDB = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_cierreC = new System.Windows.Forms.Button();
            this.button_ventaM = new System.Windows.Forms.Button();
            this.button_apertura = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_desconectarDB
            // 
            this.button_desconectarDB.Location = new System.Drawing.Point(-1, 419);
            this.button_desconectarDB.Name = "button_desconectarDB";
            this.button_desconectarDB.Size = new System.Drawing.Size(179, 58);
            this.button_desconectarDB.TabIndex = 5;
            this.button_desconectarDB.Text = "Cerrar Sesion";
            this.button_desconectarDB.UseVisualStyleBackColor = true;
            this.button_desconectarDB.Click += new System.EventHandler(this.button_desconectarDB_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_cierreC);
            this.panel1.Controls.Add(this.button_desconectarDB);
            this.panel1.Controls.Add(this.button_ventaM);
            this.panel1.Controls.Add(this.button_apertura);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 528);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button_cierreC
            // 
            this.button_cierreC.Enabled = false;
            this.button_cierreC.Location = new System.Drawing.Point(-1, 297);
            this.button_cierreC.Name = "button_cierreC";
            this.button_cierreC.Size = new System.Drawing.Size(179, 63);
            this.button_cierreC.TabIndex = 9;
            this.button_cierreC.Text = "Cierre de Caja";
            this.button_cierreC.UseVisualStyleBackColor = true;
            this.button_cierreC.Click += new System.EventHandler(this.button_cierreC_Click);
            // 
            // button_ventaM
            // 
            this.button_ventaM.Enabled = false;
            this.button_ventaM.Location = new System.Drawing.Point(-1, 71);
            this.button_ventaM.Name = "button_ventaM";
            this.button_ventaM.Size = new System.Drawing.Size(179, 62);
            this.button_ventaM.TabIndex = 7;
            this.button_ventaM.Text = "Venta de Mostrador";
            this.button_ventaM.UseVisualStyleBackColor = true;
            this.button_ventaM.Click += new System.EventHandler(this.button_ventaM_Click);
            // 
            // button_apertura
            // 
            this.button_apertura.Enabled = false;
            this.button_apertura.Location = new System.Drawing.Point(-1, 186);
            this.button_apertura.Name = "button_apertura";
            this.button_apertura.Size = new System.Drawing.Size(179, 67);
            this.button_apertura.TabIndex = 8;
            this.button_apertura.Text = "Apertura de Caja";
            this.button_apertura.UseVisualStyleBackColor = true;
            this.button_apertura.Click += new System.EventHandler(this.button_apertura_Click);
            // 
            // ventanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AppPrototipoPV.Properties.Resources.images;
            this.ClientSize = new System.Drawing.Size(957, 530);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "ventanaPrincipal";
            this.Text = "Punto de venta Microsip [Prototipo]";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_desconectarDB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_cierreC;
        private System.Windows.Forms.Button button_ventaM;
        private System.Windows.Forms.Button button_apertura;
    }
}

