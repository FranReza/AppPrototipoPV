
namespace AppPrototipoPV
{
    partial class VentasMostrador
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_total = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_nombre_cliente = new System.Windows.Forms.Label();
            this.label_clave_cliente = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_cajero = new System.Windows.Forms.Label();
            this.label_almacen = new System.Windows.Forms.Label();
            this.textBox_clave_articulo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Articulo,
            this.Nombre,
            this.Unidades,
            this.Precio,
            this.Descuento});
            this.dataGridView1.Location = new System.Drawing.Point(14, 220);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(689, 136);
            this.dataGridView1.TabIndex = 0;
            // 
            // Articulo
            // 
            this.Articulo.HeaderText = "Articulo";
            this.Articulo.Name = "Articulo";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Unidades
            // 
            this.Unidades.HeaderText = "Unidades";
            this.Unidades.Name = "Unidades";
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            // 
            // Descuento
            // 
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.Name = "Descuento";
            // 
            // label_total
            // 
            this.label_total.AutoSize = true;
            this.label_total.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_total.Location = new System.Drawing.Point(277, 373);
            this.label_total.Name = "label_total";
            this.label_total.Size = new System.Drawing.Size(184, 45);
            this.label_total.TabIndex = 1;
            this.label_total.Text = "Total $0.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(14, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Efectivo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(92, 390);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(149, 23);
            this.textBox1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label_nombre_cliente);
            this.panel1.Controls.Add(this.label_clave_cliente);
            this.panel1.Location = new System.Drawing.Point(14, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 100);
            this.panel1.TabIndex = 4;
            // 
            // label_nombre_cliente
            // 
            this.label_nombre_cliente.AutoSize = true;
            this.label_nombre_cliente.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_nombre_cliente.Location = new System.Drawing.Point(12, 53);
            this.label_nombre_cliente.Name = "label_nombre_cliente";
            this.label_nombre_cliente.Size = new System.Drawing.Size(236, 25);
            this.label_nombre_cliente.TabIndex = 1;
            this.label_nombre_cliente.Text = "Venta al Publico en Gneral";
            // 
            // label_clave_cliente
            // 
            this.label_clave_cliente.AutoSize = true;
            this.label_clave_cliente.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_clave_cliente.Location = new System.Drawing.Point(12, 10);
            this.label_clave_cliente.Name = "label_clave_cliente";
            this.label_clave_cliente.Size = new System.Drawing.Size(54, 25);
            this.label_clave_cliente.TabIndex = 0;
            this.label_clave_cliente.Text = "C025";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label_cajero);
            this.panel2.Controls.Add(this.label_almacen);
            this.panel2.Location = new System.Drawing.Point(396, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(307, 100);
            this.panel2.TabIndex = 5;
            // 
            // label_cajero
            // 
            this.label_cajero.AutoSize = true;
            this.label_cajero.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_cajero.Location = new System.Drawing.Point(14, 63);
            this.label_cajero.Name = "label_cajero";
            this.label_cajero.Size = new System.Drawing.Size(172, 25);
            this.label_cajero.TabIndex = 1;
            this.label_cajero.Text = "Nombre del Cajero";
            // 
            // label_almacen
            // 
            this.label_almacen.AutoSize = true;
            this.label_almacen.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_almacen.Location = new System.Drawing.Point(14, 10);
            this.label_almacen.Name = "label_almacen";
            this.label_almacen.Size = new System.Drawing.Size(146, 25);
            this.label_almacen.TabIndex = 0;
            this.label_almacen.Text = "Almacen Gneral";
            // 
            // textBox_clave_articulo
            // 
            this.textBox_clave_articulo.Location = new System.Drawing.Point(12, 191);
            this.textBox_clave_articulo.Name = "textBox_clave_articulo";
            this.textBox_clave_articulo.Size = new System.Drawing.Size(194, 23);
            this.textBox_clave_articulo.TabIndex = 6;
            this.textBox_clave_articulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_clave_articulo_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Buscar por clave del articulo";
            // 
            // VentasMostrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_clave_articulo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_total);
            this.Controls.Add(this.dataGridView1);
            this.Name = "VentasMostrador";
            this.Text = "VentasMostrador";
            this.Load += new System.EventHandler(this.VentasMostrador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.Label label_total;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_nombre_cliente;
        private System.Windows.Forms.Label label_clave_cliente;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_cajero;
        private System.Windows.Forms.Label label_almacen;
        private System.Windows.Forms.TextBox textBox_clave_articulo;
        private System.Windows.Forms.Label label5;
    }
}