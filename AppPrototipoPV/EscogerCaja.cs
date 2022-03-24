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
    public partial class EscogerCaja : Form
    {
        private Cajero usuario_cajero;
        List<Tuple<Int32, String>> lista_Cajas_operar;
        public EscogerCaja(Cajero obj)
        {
            this.usuario_cajero = obj;
            lista_Cajas_operar = conexionDB.conexionDB.Instance.obtener_cajas_por_operar(usuario_cajero.Idcajero, 'O');
            InitializeComponent();
        }

        private void EscogerCaja_Load(object sender, EventArgs e)
        {
            if (lista_Cajas_operar.Count() > 0)
            {

                comboBox_cajas.DataSource = lista_Cajas_operar;
                comboBox_cajas.DisplayMember = "Item2";
                comboBox_cajas.ValueMember = "Item1";
            }
        }

        private void button_aceptar_caja_Click(object sender, EventArgs e)
        {
            string? estatus_caja = conexionDB.conexionDB.Instance.estatus_caja(Convert.ToInt32(comboBox_cajas.SelectedValue.ToString()));

            if (estatus_caja == "Cerrada") {
                MessageBox.Show("Esta caja no se encuentra aperturada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } else if (estatus_caja == "") {
                MessageBox.Show("Esta caja no permite cobros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } else if (estatus_caja == "Abierta") {
            
            } 
        }
    }
}
