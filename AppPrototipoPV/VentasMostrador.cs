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

        public VentasMostrador(Cliente obj1, Caja obj2, Cajero obj3)
        {
            this.datos_cliente = obj1;
            this.datos_caja_almacen = obj2;
            this.datos_cajero = obj3;
            InitializeComponent();
        }

        private void VentasMostrador_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("D: "+datos_cliente.Clave_cliente);
            label_clave_cliente.Text = datos_cliente.Clave_cliente;
            label_nombre_cliente.Text = datos_cliente.Nombre_cliente;
            label_almacen.Text = datos_caja_almacen.Nombre_almacen;
            label_cajero.Text = datos_cajero.Nombrecajero;
        }

        private void textBox_clave_articulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                string campo_clave_valor = textBox_clave_articulo.Text;
                conexionDB.conexionDB.Instance.Buscar_Articulo_por_clave_con_precio_impuesto(campo_clave_valor, datos_cliente.Cliente_id.ToString());
            }
        }
    }
}
