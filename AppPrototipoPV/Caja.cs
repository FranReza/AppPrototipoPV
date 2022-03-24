using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPrototipoPV
{
    class Caja
    {

        private int caja_id;
        private string nombre_caja;
        private int almacen_id;
        private string nombre_almacen;

        public Caja(int caja_id, string nombre_caja, int almacen_id, string nombre_almacen)
        {
            this.Caja_id = caja_id;
            this.Nombre_caja = nombre_caja;
            this.Almacen_id = almacen_id;
            this.Nombre_almacen = nombre_almacen;
        }

        public int Caja_id { get => caja_id; set => caja_id = value; }
        public string Nombre_caja { get => nombre_caja; set => nombre_caja = value; }
        public int Almacen_id { get => almacen_id; set => almacen_id = value; }
        public string Nombre_almacen { get => nombre_almacen; set => nombre_almacen = value; }
    }
}
