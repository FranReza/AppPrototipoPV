
namespace AppPrototipoPV
{
    partial class Capturar_series_lotes
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
            this.comboBox_series_lotes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_info = new System.Windows.Forms.ListBox();
            this.button_guardar = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.label_unidades = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_series_lotes
            // 
            this.comboBox_series_lotes.FormattingEnabled = true;
            this.comboBox_series_lotes.Location = new System.Drawing.Point(21, 49);
            this.comboBox_series_lotes.Name = "comboBox_series_lotes";
            this.comboBox_series_lotes.Size = new System.Drawing.Size(177, 23);
            this.comboBox_series_lotes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Series / Lotes Disponibles";
            // 
            // listBox_info
            // 
            this.listBox_info.FormattingEnabled = true;
            this.listBox_info.ItemHeight = 15;
            this.listBox_info.Location = new System.Drawing.Point(21, 93);
            this.listBox_info.Name = "listBox_info";
            this.listBox_info.Size = new System.Drawing.Size(261, 94);
            this.listBox_info.TabIndex = 2;
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(21, 193);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 23);
            this.button_guardar.TabIndex = 3;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(207, 49);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 23);
            this.button_add.TabIndex = 4;
            this.button_add.Text = "Agregar";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // label_unidades
            // 
            this.label_unidades.AutoSize = true;
            this.label_unidades.Location = new System.Drawing.Point(21, 75);
            this.label_unidades.Name = "label_unidades";
            this.label_unidades.Size = new System.Drawing.Size(68, 15);
            this.label_unidades.TabIndex = 6;
            this.label_unidades.Text = "Unidades: 0";
            // 
            // Capturar_series_lotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 223);
            this.Controls.Add(this.label_unidades);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.listBox_info);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_series_lotes);
            this.Name = "Capturar_series_lotes";
            this.Text = "Capturar series/lotes";
            this.Load += new System.EventHandler(this.Capturar_series_lotes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_series_lotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_info;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Label label_unidades;
    }
}