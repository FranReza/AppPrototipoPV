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
    public partial class sesion : Form
    {
        public sesion()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button_conectar_Click(object sender, EventArgs e)
        {
            string user = textBox_user.Text;
            string pass = textBox_pass.Text;
            string con = textBox_conexion.Text;
            int res = conexionDB.conexionDB.Instance.enlazar_conexion(user, pass, con);

            if (res == 0)
            {

                ventanaPrincipal vp = new ventanaPrincipal();
                vp.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error en los parametros de la conexion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
