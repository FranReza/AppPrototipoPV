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
    public partial class Capturar_series_lotes : Form
    {
        private List<Tuple<Int32, String>> datos_series_lotes;
        public List<Tuple<Int32, String>> enviar_series_lotes = new List<Tuple<int, string>>();
        public int cantidad;
        private int indice_obtenido;
        public Capturar_series_lotes(List<Tuple<Int32, String>> obj, int indice)
        {
            datos_series_lotes = obj; //añadirmos esto
            indice_obtenido = indice;
            this.CenterToScreen();
            InitializeComponent();
            this.button_guardar.DialogResult = DialogResult.OK;
        }

        private void Capturar_series_lotes_Load(object sender, EventArgs e)
        {
            if (datos_series_lotes.Count() > 0)
            {
                Debug.WriteLine($"{datos_series_lotes.Count}");
                for (int i = 0; i < datos_series_lotes.Count; i++) {
                    Debug.WriteLine($"{datos_series_lotes[i].Item1} * {datos_series_lotes[i].Item2}");
                }
                comboBox_series_lotes.DataSource = datos_series_lotes;
                comboBox_series_lotes.DisplayMember = "Item2";
                comboBox_series_lotes.ValueMember = "Item1";
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            int indice = comboBox_series_lotes.SelectedIndex;
            string clave = comboBox_series_lotes.SelectedItem.ToString();
            int valor = Convert.ToInt32(comboBox_series_lotes.SelectedValue);
            enviar_series_lotes.Add(Tuple.Create(valor, clave));

            Debug.WriteLine(enviar_series_lotes.Count+"x");
            cantidad++;
            listBox_info.Items.Add(clave);
            
            comboBox_series_lotes.DataSource = null;
            datos_series_lotes.RemoveAt(indice);
            comboBox_series_lotes.DataSource = datos_series_lotes;
            comboBox_series_lotes.DisplayMember = "Item2";
            comboBox_series_lotes.ValueMember = "Item1";
            label_unidades.Text = $"Unidades: {enviar_series_lotes.Count}";
            
        }

    }
}
