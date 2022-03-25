using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPrototipoPV
{
    public partial class cierreCaja : Form
    {

        private Cajero usuario_cajero;
        List<Tuple<Int32, String>> lista_Cajas_cerradas;
        string capturar_fecha;
        public cierreCaja(Cajero obj)
        {
            
            InitializeComponent();
            this.usuario_cajero = obj;
            textBox_hora.Text = DateTime.Now.ToString("HH:mm:ss");
            textBox_fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            
            lista_Cajas_cerradas = conexionDB.conexionDB.Instance.obtener_Cajas_por_abrir_cerrar(usuario_cajero.Idcajero, 'C');
        }

        private void cierreCaja_Load(object sender, EventArgs e)
        {
            
            if (lista_Cajas_cerradas.Count() > 0)
            {
                comboBox_cajas.DataSource = lista_Cajas_cerradas;
                comboBox_cajas.DisplayMember = "Item2";
                comboBox_cajas.ValueMember = "Item1";
                capturar_fecha = DateTime.Now.ToString("dd/MM/yyyy HH:MM:ss");
                MessageBox.Show(capturar_fecha);
            }
        }

        private void button_guardar_cierre_Click(object sender, EventArgs e)
        {
            int estado_cierre_caja = 0;

                estado_cierre_caja = conexionDB.conexionDB.Instance.Cierre_caja(
                    this.usuario_cajero.Idcajero,
                    this.usuario_cajero.Usuariocajero,
                    'T',
                    Convert.ToInt32(comboBox_cajas.SelectedValue.ToString()),
                    textBox_hora.Text,
                    textBox_fecha.Text,
                    capturar_fecha,
                    "Efectivo",
                    textBox_fondoFinal.Text
                    );

            if (estado_cierre_caja == 0)
            {
                MessageBox.Show("Cierre de caja exitoso");
                this.Close();
            }
            else {
                MessageBox.Show("Ocurrio un error de cierre de caja");
            }
        }
    }
}
