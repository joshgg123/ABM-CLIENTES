using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABM_CLIENTES.clases
{
    internal class cliente
    {
        int id;
        string nombre;
        string apellido;
        string telefono;
        
        public cliente()
        {
            
        }
        public cliente(int id, string nombre, string apellido, string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
        
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    public override string ToString()
    {
        return this.nombre + " " + this.apellido;
    }
    }


}
