
namespace AppPrototipoPV
{
    partial class AperturaCaja
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.combo_caja = new System.Windows.Forms.ComboBox();
            this.dataGridViewfondo = new System.Windows.Forms.DataGridView();
            this.forma_cobro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox_Cajero = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_hora = new System.Windows.Forms.TextBox();
            this.textBox_fecha = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabla_cajero = new System.Windows.Forms.DataGridView();
            this.cajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radio_cajeros_indicados = new System.Windows.Forms.RadioButton();
            this.radio_todos_cajeros = new System.Windows.Forms.RadioButton();
            this.button_guardar_apertura_caja = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewfondo)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_cajero)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(389, 281);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.combo_caja);
            this.tabPage1.Controls.Add(this.dataGridViewfondo);
            this.tabPage1.Controls.Add(this.textBox_Cajero);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox_hora);
            this.tabPage1.Controls.Add(this.textBox_fecha);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(381, 253);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // combo_caja
            // 
            this.combo_caja.FormattingEnabled = true;
            this.combo_caja.Location = new System.Drawing.Point(50, 60);
            this.combo_caja.Name = "combo_caja";
            this.combo_caja.Size = new System.Drawing.Size(323, 23);
            this.combo_caja.TabIndex = 10;
            // 
            // dataGridViewfondo
            // 
            this.dataGridViewfondo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewfondo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.forma_cobro,
            this.moneda,
            this.importe});
            this.dataGridViewfondo.Location = new System.Drawing.Point(0, 157);
            this.dataGridViewfondo.Name = "dataGridViewfondo";
            this.dataGridViewfondo.RowTemplate.Height = 25;
            this.dataGridViewfondo.Size = new System.Drawing.Size(378, 90);
            this.dataGridViewfondo.TabIndex = 9;
            // 
            // forma_cobro
            // 
            this.forma_cobro.Frozen = true;
            this.forma_cobro.HeaderText = "forma de cobro";
            this.forma_cobro.Name = "forma_cobro";
            this.forma_cobro.ReadOnly = true;
            // 
            // moneda
            // 
            this.moneda.Frozen = true;
            this.moneda.HeaderText = "Moneda";
            this.moneda.Name = "moneda";
            this.moneda.ReadOnly = true;
            // 
            // importe
            // 
            this.importe.HeaderText = "Importe";
            this.importe.Name = "importe";
            // 
            // textBox_Cajero
            // 
            this.textBox_Cajero.Location = new System.Drawing.Point(50, 101);
            this.textBox_Cajero.Name = "textBox_Cajero";
            this.textBox_Cajero.Size = new System.Drawing.Size(325, 23);
            this.textBox_Cajero.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "fondo inicial";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "caja";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "cajero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "hora";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "fecha";
            // 
            // textBox_hora
            // 
            this.textBox_hora.Enabled = false;
            this.textBox_hora.Location = new System.Drawing.Point(255, 16);
            this.textBox_hora.Name = "textBox_hora";
            this.textBox_hora.Size = new System.Drawing.Size(118, 23);
            this.textBox_hora.TabIndex = 1;
            // 
            // textBox_fecha
            // 
            this.textBox_fecha.Enabled = false;
            this.textBox_fecha.Location = new System.Drawing.Point(50, 16);
            this.textBox_fecha.Name = "textBox_fecha";
            this.textBox_fecha.Size = new System.Drawing.Size(162, 23);
            this.textBox_fecha.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabla_cajero);
            this.tabPage2.Controls.Add(this.radio_cajeros_indicados);
            this.tabPage2.Controls.Add(this.radio_todos_cajeros);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(381, 253);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cajeros Habilitados";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabla_cajero
            // 
            this.tabla_cajero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_cajero.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cajero});
            this.tabla_cajero.Location = new System.Drawing.Point(18, 106);
            this.tabla_cajero.Name = "tabla_cajero";
            this.tabla_cajero.RowHeadersWidth = 150;
            this.tabla_cajero.RowTemplate.Height = 25;
            this.tabla_cajero.Size = new System.Drawing.Size(334, 121);
            this.tabla_cajero.TabIndex = 2;
            // 
            // cajero
            // 
            this.cajero.HeaderText = "cajero";
            this.cajero.Name = "cajero";
            // 
            // radio_cajeros_indicados
            // 
            this.radio_cajeros_indicados.AutoSize = true;
            this.radio_cajeros_indicados.Location = new System.Drawing.Point(18, 61);
            this.radio_cajeros_indicados.Name = "radio_cajeros_indicados";
            this.radio_cajeros_indicados.Size = new System.Drawing.Size(186, 19);
            this.radio_cajeros_indicados.TabIndex = 1;
            this.radio_cajeros_indicados.Text = "los cajeros indicados en la lista";
            this.radio_cajeros_indicados.UseVisualStyleBackColor = true;
            this.radio_cajeros_indicados.CheckedChanged += new System.EventHandler(this.radio_cajeros_indicados_CheckedChanged);
            // 
            // radio_todos_cajeros
            // 
            this.radio_todos_cajeros.AutoSize = true;
            this.radio_todos_cajeros.Checked = true;
            this.radio_todos_cajeros.Location = new System.Drawing.Point(18, 22);
            this.radio_todos_cajeros.Name = "radio_todos_cajeros";
            this.radio_todos_cajeros.Size = new System.Drawing.Size(271, 19);
            this.radio_todos_cajeros.TabIndex = 0;
            this.radio_todos_cajeros.TabStop = true;
            this.radio_todos_cajeros.Text = "todos los cajeros con derecho de operar la caja";
            this.radio_todos_cajeros.UseVisualStyleBackColor = true;
            this.radio_todos_cajeros.CheckedChanged += new System.EventHandler(this.radio_todos_cajeros_CheckedChanged);
            // 
            // button_guardar_apertura_caja
            // 
            this.button_guardar_apertura_caja.Location = new System.Drawing.Point(10, 287);
            this.button_guardar_apertura_caja.Name = "button_guardar_apertura_caja";
            this.button_guardar_apertura_caja.Size = new System.Drawing.Size(75, 23);
            this.button_guardar_apertura_caja.TabIndex = 1;
            this.button_guardar_apertura_caja.Text = "Guardar";
            this.button_guardar_apertura_caja.UseVisualStyleBackColor = true;
            this.button_guardar_apertura_caja.Click += new System.EventHandler(this.button_guardar_apertura_caja_Click);
            // 
            // AperturaCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 317);
            this.Controls.Add(this.button_guardar_apertura_caja);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(400, 100);
            this.Name = "AperturaCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AperturaCaja";
            this.Load += new System.EventHandler(this.AperturaCaja_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewfondo)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_cajero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox_hora;
        private System.Windows.Forms.TextBox textBox_fecha;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewfondo;
        private System.Windows.Forms.TextBox textBox_Cajero;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_guardar_apertura_caja;
        private System.Windows.Forms.DataGridView tabla_cajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn cajero;
        private System.Windows.Forms.RadioButton radio_cajeros_indicados;
        private System.Windows.Forms.RadioButton radio_todos_cajeros;
        private System.Windows.Forms.ComboBox combo_caja;
        private System.Windows.Forms.DataGridViewTextBoxColumn forma_cobro;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
    }
}