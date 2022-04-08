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
    public partial class AperturaCaja : Form
    {

        private Cajero usuario_cajero;
        List<Tuple<Int32, String>> lista_Cajas_abiertas;
        string capturar_fecha;

        public AperturaCaja(Cajero obj)
        {
            object[] fondo_inicial = {"Efectivo", "Pesos", 0.00};
            this.usuario_cajero = obj;
            this.CenterToScreen();
            InitializeComponent();
            textBox_hora.Text = DateTime.Now.ToString("HH:mm:ss");
            textBox_fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            textBox_Cajero.Text = usuario_cajero.Nombrecajero;
            lista_Cajas_abiertas = conexionDB.conexionDB.Instance.obtener_Cajas_por_abrir_cerrar(usuario_cajero.Idcajero, 'A');
            dataGridViewfondo.Rows.Insert(0, fondo_inicial);
            tabla_cajero.Rows.Add(usuario_cajero.Nombrecajero);
        }

        private void AperturaCaja_Load(object sender, EventArgs e) {
            capturar_fecha = DateTime.Now.ToString("dd/MM/yyyy HH:MM:ss");
            if (lista_Cajas_abiertas.Count() > 0) {
                
                combo_caja.DataSource = lista_Cajas_abiertas;
                combo_caja.DisplayMember = "Item2";
                combo_caja.ValueMember = "Item1";
            }
        }

        private void radio_todos_cajeros_CheckedChanged(object sender, EventArgs e)
        {
            tabla_cajero.Enabled = false;
        }

        private void radio_cajeros_indicados_CheckedChanged(object sender, EventArgs e)
        {
            tabla_cajero.Enabled = true;
        }

        private void button_guardar_apertura_caja_Click(object sender, EventArgs e)
        {
            int estado_apertura_caja = 0;

            if (radio_cajeros_indicados.Checked) {
                estado_apertura_caja = conexionDB.conexionDB.Instance.Aperturar_caja(
                    this.usuario_cajero.Idcajero,
                    this.usuario_cajero.Usuariocajero,
                    'L',
                    Convert.ToInt32(combo_caja.SelectedValue.ToString()), 
                    textBox_hora.Text,
                    textBox_fecha.Text,
                    capturar_fecha,
                    "Efectivo",
                    dataGridViewfondo.Rows[0].Cells[2].Value.ToString()
                    );

                
            } else if (radio_todos_cajeros.Checked) {
                estado_apertura_caja = conexionDB.conexionDB.Instance.Aperturar_caja(
                    this.usuario_cajero.Idcajero,
                    this.usuario_cajero.Usuariocajero,
                    'T',
                    Convert.ToInt32(combo_caja.SelectedValue.ToString()),
                    textBox_hora.Text,
                    textBox_fecha.Text,
                    capturar_fecha,
                    "Efectivo",
                    dataGridViewfondo.Rows[0].Cells[2].Value.ToString()
                    );
            }

            if (estado_apertura_caja == 0)
            {
                MessageBox.Show("Apertura de Caja Completada");
                this.Close();
            }
            else {
                MessageBox.Show("Error no se pudo aperturar la caja!");
            }
        }
    }
}
