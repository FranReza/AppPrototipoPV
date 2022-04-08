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
            Debug.WriteLine($"{datos_caja_almacen.Almacen_id}, {datos_caja_almacen.Caja_id} , {datos_caja_almacen.Nombre_almacen} {datos_caja_almacen.Nombre_caja}");
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
                    DataGridViewRow row = new DataGridViewRow(); //en esta parte es cuando guardamos el articulo en la tabla 
                    row.CreateCells(dataGridView1);
                    row.Cells[0].Value = art.Clave_articulo;
                    row.Cells[1].Value = art.Nombre_articulo;
                    row.Cells[2].Value = 1;
                    row.Cells[3].Value = art.Precio_impuesto;
                    row.Cells[4].Value = ""+0.00;

                    dataGridView1.Rows.Add(row);
                    lista_articulos.Add(art);
                    List<Tuple<Int32, String>> l = conexionDB.conexionDB.Instance.exis_lista_discretos(art);
                    if (l != null)
                    {
                        Debug.WriteLine($@"se cargo una lista de series/lotes
                                           de este producto. ultimo elemento insert es: 
                                            {lista_articulos.Count - 1}");
                        int indiceProducto = lista_articulos.Count - 1;
                        Capturar_series_lotes hijo = new Capturar_series_lotes(l, indiceProducto);
                        DialogResult res = hijo.ShowDialog();
                        if (res == DialogResult.OK) {
                            List<Tuple<Int32, String>> datos_obtenidos = hijo.enviar_series_lotes;
                            lista_articulos[indiceProducto].Series_lotes = datos_obtenidos;
                            int c = lista_articulos[indiceProducto].Series_lotes.Count;

                            for (int i = 0; i < c; i++) {
                                Debug.WriteLine($"{lista_articulos[indiceProducto].Series_lotes[i].Item1} - {lista_articulos[indiceProducto].Series_lotes[i].Item2}");
                            }
                            
                        }
                    }
                    
                    double total = 0;//en esta parte hacemos el calculo en pantalla cuando guardamos un objeto.
                    total = lista_articulos.Sum(item => item.Precio_impuesto);
                    label_total_venta.Text = $"Total: ${total}";
                }
            }
        }

        private void button_eliminarFila_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count > 0)
                {
                   int filaseleccionada = dataGridView1.CurrentRow.Index;
                   dataGridView1.Rows.RemoveAt(filaseleccionada);
                   lista_articulos.RemoveAt(filaseleccionada);

                double total = 0;
                total = lista_articulos.Sum(item => item.Precio_impuesto);

                label_total_venta.Text = $"Total: ${total}";

                //verificando la lista.
                for (int i = 0; i < lista_articulos.Count; i++) {
                    Debug.WriteLine($"DATO: {lista_articulos[i].Articulo_id} {lista_articulos[i].Nombre_articulo}");
                }
                    
            } else {
                    MessageBox.Show("Selecciona una fila");
            }
        }

        private void button_Venta_Click(object sender, EventArgs e)
        {
            double total_venta = calcular_total_venta(lista_articulos);
            double total_impuestos = calcular_impuestos_totales(lista_articulos);
            double total_venta_neta = calcular_importe_neto_total(lista_articulos);
            double recibido = Convert.ToDouble(textBox_Efectivo.Text);

            label_total_venta.Text = $"Total: ${total_venta}";
            label_cambio.Text = $"Total: ${recibido - total_venta}";

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

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e){}
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e){}
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e){}

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int unidades = 0;
            double precio_venta = 0;
            double total = 0;
            int fila = e.RowIndex;
            int columna = e.ColumnIndex;

            Debug.WriteLine($"celda seleccionada es: {fila} {columna}");
            
            unidades = Convert.ToInt32(dataGridView1.Rows[fila].Cells[columna].Value);
            precio_venta = Convert.ToDouble(dataGridView1.Rows[fila].Cells[3].Value);

            total = Convert.ToDouble((precio_venta*unidades));
            //DataGrid1.Rows[Linea].Cells[Celda].Value =Valor;
            dataGridView1.Rows[fila].Cells[3].Value = total; //añadimos este valor
            lista_articulos[fila].Cantidad = unidades;
            lista_articulos[fila].Precio_impuesto = total;

            double total_pantalla = 0;//en esta parte hacemos el calculo en pantalla cuando guardamos un objeto.
            total_pantalla = lista_articulos.Sum(item => item.Precio_impuesto);
            label_total_venta.Text = $"Total: ${total_pantalla}";
        }
    }
}
