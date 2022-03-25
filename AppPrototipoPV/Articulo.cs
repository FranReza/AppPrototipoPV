using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPrototipoPV
{
    class Articulo
    {
        private int articulo_id;
        private int clave_articulo;
        private string nombre_articulo;
        private int precio_unitario;
        private int precio_impuesto;

        public Articulo(int articulo_id, int clave_articulo, string nombre_articulo, int precio_unitario, int precio_impuesto)
        {
            this.Articulo_id = articulo_id;
            this.Clave_articulo = clave_articulo;
            this.Nombre_articulo = nombre_articulo;
            this.Precio_unitario = precio_unitario;
            this.Precio_impuesto = precio_impuesto;
        }

        public int Articulo_id { get => articulo_id; set => articulo_id = value; }
        public int Clave_articulo { get => clave_articulo; set => clave_articulo = value; }
        public string Nombre_articulo { get => nombre_articulo; set => nombre_articulo = value; }
        public int Precio_unitario { get => precio_unitario; set => precio_unitario = value; }
        public int Precio_impuesto { get => precio_impuesto; set => precio_impuesto = value; }
    }
}
