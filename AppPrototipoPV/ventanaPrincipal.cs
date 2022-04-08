using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace AppPrototipoPV
{
    public partial class ventanaPrincipal : Form
    {

        private Cajero objeto_cajero;
        private string[] usuariocajero;
        public ventanaPrincipal()
        {
            InitializeComponent();
            this.CenterToScreen();
            button_desconectarDB.Enabled = true;
            button_ventaM.Enabled = true;
            button_apertura.Enabled = true;
            button_cierreC.Enabled = true;
            objetoCajero();
            conexionDB.conexionDB.Instance.CrearUsuarioCajero();
        }

        private void button_desconectarDB_Click(object sender, EventArgs e)
        {
            int res = conexionDB.conexionDB.Instance.desconectarDB();
            if (res == 0)
            {
                Application.Exit();
            }
        }

        private void button_apertura_Click(object sender, EventArgs e)
        {
            if (objeto_cajero.Idcajero == 0)
            {
                MessageBox.Show("Solo pueden aperturar cajas los cajeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                AperturaCaja form = new AperturaCaja(objeto_cajero);
                form.MdiParent = this;
                form.Show();
            }
            
        }

        public void objetoCajero() {
            usuariocajero = conexionDB.conexionDB.Instance.CrearUsuarioCajero();
            
            if (usuariocajero[0] != null)
            {
                
                int id = Int32.Parse(usuariocajero[0]);
                string nombre = usuariocajero[1];
                string usuario = usuariocajero[2];
                char operar = char.Parse(usuariocajero[3]);
                char abrir_cerrar = char.Parse(usuariocajero[4]);

                objeto_cajero = new Cajero(id, nombre, usuario, operar, abrir_cerrar);
            }

            else {
                objeto_cajero = new Cajero(0, "xxx", "xxx", 'x', 'x');    
            }
        }

        private void button_cierreC_Click(object sender, EventArgs e)
        {
            if (objeto_cajero.Idcajero == 0)
            {
                MessageBox.Show("Solo pueden cerrar cajas los cajeros autorizados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cierreCaja form = new cierreCaja(objeto_cajero);
                form.MdiParent = this;
                form.Show();
            }
        }

        private void button_ventaM_Click(object sender, EventArgs e)
        {
            if (objeto_cajero.Operarcaja == 'T' || objeto_cajero.Operarcaja == 'L')
            {
                EscogerCaja form = new EscogerCaja(objeto_cajero);
                form.MdiParent = this;
                form.Show();
            }
            else { 
                MessageBox.Show("Solo pueden operar cajas los cajeros autorizados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
