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
        public Cajero usuario_cajero;
        List<Tuple<Int32, String>> lista_Cajas_operar;
        string[] clienteinfo;
        string[] cajainfo;
        private Caja obj_caja_almacen;
        private Cliente obj_cliente;
        public EscogerCaja(Cajero obj)
        {
            this.usuario_cajero = obj;
            lista_Cajas_operar = conexionDB.conexionDB.Instance.obtener_cajas_por_operar(usuario_cajero.Idcajero, 'O');
            InitializeComponent();
            this.CenterToScreen();

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
                clienteinfo = conexionDB.conexionDB.Instance.Obtener_cliente();
                cajainfo = conexionDB.conexionDB.Instance.Obtener_almacen_caja(Convert.ToInt32(comboBox_cajas.SelectedValue.ToString()));

                this.obj_cliente = new Cliente(clienteinfo[2], Convert.ToInt32(clienteinfo[0]), clienteinfo[1]);
                this.obj_caja_almacen = new Caja(Convert.ToInt32(cajainfo[0]), cajainfo[1], Convert.ToInt32(cajainfo[2]), cajainfo[3]);
                
             
                VentasMostrador form = new VentasMostrador(this.obj_cliente, this.obj_caja_almacen, this.usuario_cajero);
                form.MdiParent = this.MdiParent;
                form.Show();
                this.Close();//cerramos esta ventana...


            }
        }
    }
}
