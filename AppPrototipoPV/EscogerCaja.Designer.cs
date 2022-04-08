
namespace AppPrototipoPV
{
    partial class EscogerCaja
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_cajas = new System.Windows.Forms.ComboBox();
            this.button_aceptar_caja = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Caja que desea operar:";
            // 
            // comboBox_cajas
            // 
            this.comboBox_cajas.FormattingEnabled = true;
            this.comboBox_cajas.Location = new System.Drawing.Point(12, 37);
            this.comboBox_cajas.Name = "comboBox_cajas";
            this.comboBox_cajas.Size = new System.Drawing.Size(286, 23);
            this.comboBox_cajas.TabIndex = 1;
            // 
            // button_aceptar_caja
            // 
            this.button_aceptar_caja.Location = new System.Drawing.Point(102, 73);
            this.button_aceptar_caja.Name = "button_aceptar_caja";
            this.button_aceptar_caja.Size = new System.Drawing.Size(75, 23);
            this.button_aceptar_caja.TabIndex = 2;
            this.button_aceptar_caja.Text = "Aceptar";
            this.button_aceptar_caja.UseVisualStyleBackColor = true;
            this.button_aceptar_caja.Click += new System.EventHandler(this.button_aceptar_caja_Click);
            // 
            // EscogerCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 108);
            this.Controls.Add(this.button_aceptar_caja);
            this.Controls.Add(this.comboBox_cajas);
            this.Controls.Add(this.label1);
            this.Name = "EscogerCaja";
            this.Text = "EscogerCaja";
            this.Load += new System.EventHandler(this.EscogerCaja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_cajas;
        private System.Windows.Forms.Button button_aceptar_caja;
    }
}