using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPrototipoPV
{
    public class Cliente
    {
        private string clave_cliente;
        private int cliente_id;
        private string nombre_cliente;

        public Cliente(string clave_cliente, int cliente_id, string nombre_cliente)
        {
            this.Clave_cliente = clave_cliente;
            this.Cliente_id = cliente_id;
            this.Nombre_cliente = nombre_cliente;
        }

        public string Clave_cliente { get => clave_cliente; set => clave_cliente = value; }
        public int Cliente_id { get => cliente_id; set => cliente_id = value; }
        public string Nombre_cliente { get => nombre_cliente; set => nombre_cliente = value; }
    }
}
