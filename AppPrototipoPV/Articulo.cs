using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPrototipoPV
{
    public class Articulo
    {
        private int articulo_id;
        private string clave_articulo;
        private string nombre_articulo;
        private double precio_unitario;
        private double precio_impuesto;
        private int cantidad;
        private List <Tuple<Int32, String>> series_lotes;

        public Articulo(int articulo_id, string clave_articulo, string nombre_articulo, double precio_unitario, double precio_impuesto, int cantidad, List<Tuple<int, string>> series_lotes)
        {
            this.articulo_id = articulo_id;
            this.clave_articulo = clave_articulo;
            this.nombre_articulo = nombre_articulo;
            this.precio_unitario = precio_unitario;
            this.precio_impuesto = precio_impuesto;
            this.cantidad = cantidad;
            this.Series_lotes = series_lotes;
        }

        public int Articulo_id { get => articulo_id; set => articulo_id = value; }
        public string Clave_articulo { get => clave_articulo; set => clave_articulo = value; }
        public string Nombre_articulo { get => nombre_articulo; set => nombre_articulo = value; }
        public double Precio_unitario { get => precio_unitario; set => precio_unitario = value; }
        public double Precio_impuesto { get => precio_impuesto; set => precio_impuesto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public List<Tuple<int, string>> Series_lotes { get => series_lotes; set => series_lotes = value; }
    }
}
