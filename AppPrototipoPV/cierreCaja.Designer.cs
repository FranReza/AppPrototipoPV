
namespace AppPrototipoPV
{
    partial class cierreCaja
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_fecha = new System.Windows.Forms.TextBox();
            this.textBox_hora = new System.Windows.Forms.TextBox();
            this.comboBox_cajas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_fondoFinal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_guardar_cierre = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hora";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Caja";
            // 
            // textBox_fecha
            // 
            this.textBox_fecha.Location = new System.Drawing.Point(56, 27);
            this.textBox_fecha.Name = "textBox_fecha";
            this.textBox_fecha.Size = new System.Drawing.Size(167, 23);
            this.textBox_fecha.TabIndex = 3;
            // 
            // textBox_hora
            // 
            this.textBox_hora.Location = new System.Drawing.Point(265, 27);
            this.textBox_hora.Name = "textBox_hora";
            this.textBox_hora.Size = new System.Drawing.Size(193, 23);
            this.textBox_hora.TabIndex = 4;
            // 
            // comboBox_cajas
            // 
            this.comboBox_cajas.FormattingEnabled = true;
            this.comboBox_cajas.Location = new System.Drawing.Point(56, 71);
            this.comboBox_cajas.Name = "comboBox_cajas";
            this.comboBox_cajas.Size = new System.Drawing.Size(402, 23);
            this.comboBox_cajas.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fondo Final";
            // 
            // textBox_fondoFinal
            // 
            this.textBox_fondoFinal.Location = new System.Drawing.Point(87, 126);
            this.textBox_fondoFinal.Name = "textBox_fondoFinal";
            this.textBox_fondoFinal.Size = new System.Drawing.Size(184, 23);
            this.textBox_fondoFinal.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Efectivo";
            // 
            // button_guardar_cierre
            // 
            this.button_guardar_cierre.Location = new System.Drawing.Point(12, 161);
            this.button_guardar_cierre.Name = "button_guardar_cierre";
            this.button_guardar_cierre.Size = new System.Drawing.Size(198, 23);
            this.button_guardar_cierre.TabIndex = 9;
            this.button_guardar_cierre.Text = "Guardar y Cerrar";
            this.button_guardar_cierre.UseVisualStyleBackColor = true;
            this.button_guardar_cierre.Click += new System.EventHandler(this.button_guardar_cierre_Click);
            // 
            // cierreCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 196);
            this.Controls.Add(this.button_guardar_cierre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_fondoFinal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_cajas);
            this.Controls.Add(this.textBox_hora);
            this.Controls.Add(this.textBox_fecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(400, 100);
            this.Name = "cierreCaja";
            this.Text = "cierreCaja";
            this.Load += new System.EventHandler(this.cierreCaja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_fecha;
        private System.Windows.Forms.TextBox textBox_hora;
        private System.Windows.Forms.ComboBox comboBox_cajas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_fondoFinal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_guardar_cierre;
    }
}