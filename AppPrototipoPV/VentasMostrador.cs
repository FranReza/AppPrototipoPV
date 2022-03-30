using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPrototipoPV
{
    public partial class VentasMostrador : Form
    {
        Cliente datos_cliente;
        Caja datos_caja_almacen;
        Cajero datos_cajero;
        List<Articulo> lista_articulos = new List<Articulo>();
        double total_venta = 0;
        List<Tuple<Articulo, Int32>> lista_de_articulos = new List<Tuple<Articulo, Int32>>();

        public VentasMostrador(Cliente obj1, Caja obj2, Cajero obj3)
        {
            this.datos_cliente = obj1;
            this.datos_caja_almacen = obj2;
            this.datos_cajero = obj3;
            InitializeComponent();
        }

        private void VentasMostrador_Load(object sender, EventArgs e)
        {
            label_clave_cliente.Text = datos_cliente.Clave_cliente;
            label_nombre_cliente.Text = datos_cliente.Nombre_cliente;
            label_almacen.Text = datos_caja_almacen.Nombre_almacen;
            label_cajero.Text = datos_cajero.Nombrecajero;
        }

        public double calcular_total_venta(List<Articulo> art) {
            double total_impuestos = 0;

            for (int i = 0; i < art.Count; i++)
            {
                total_impuestos += art[i].Precio_impuesto;
            }
            return total_impuestos;

        }

        public double calcular_impuestos_totales(List<Articulo> art) {
            double total_impuestos = 0;

            for (int i = 0; i < art.Count; i++) {
               total_impuestos += art[i].Precio_impuesto - art[i].Precio_unitario;
            }
            return total_impuestos;
        }

        public double calcular_importe_neto_total(List<Articulo> art) {
            double total_neto = 0;

            for (int i = 0; i < art.Count; i++)
            {
                total_neto += art[i].Precio_unitario;
            }
            return total_neto;
        }

        private void textBox_clave_articulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                string campo_clave_valor = textBox_clave_articulo.Text;
                Articulo art = conexionDB.conexionDB.Instance.Buscar_Articulo_por_clave_con_precio_impuesto(campo_clave_valor, datos_cliente.Cliente_id.ToString());

                if (art is null)
                {
                    MessageBox.Show("No existe el articulo indicado.");

                }
                else {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridView1);
                    row.Cells[0].Value = art.Clave_articulo;
                    row.Cells[1].Value = art.Nombre_articulo;
                    row.Cells[2].Value = 1;
                    row.Cells[3].Value = art.Precio_impuesto;
                    row.Cells[4].Value = ""+0.00;

                    dataGridView1.Rows.Add(row);
                    lista_articulos.Add(art);
                }
            }
        }

        private void button_eliminarFila_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }

        private void button_Venta_Click(object sender, EventArgs e)
        {
            double total_venta = calcular_total_venta(lista_articulos);
            double total_impuestos = calcular_impuestos_totales(lista_articulos);
            double total_venta_neta = calcular_importe_neto_total(lista_articulos);
            double recibido = Convert.ToDouble(textBox_Efectivo.Text);

            int res = conexionDB.conexionDB.Instance.Realizar_Venta_Mostrador(
                    lista_articulos,
                    datos_cliente,
                    datos_caja_almacen,
                    datos_cajero,
                    total_venta,
                    recibido,
                    total_venta_neta,
                    total_impuestos
                );

            if (res == 0)
            {
                MessageBox.Show("venta compeltada");
            }
            else {
                MessageBox.Show("ya la cagaste mi rey");
            }
        }
    }
}
