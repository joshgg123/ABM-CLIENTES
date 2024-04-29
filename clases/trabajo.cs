using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
namespace ABM_CLIENTES.clases
{
    internal class trabajo
    {
        int id;
        string direccion;
        string observacion;
        Decimal total;
        string estado;
        string fecha;
        int tiempo;
        cliente cliente;
        List<empleado> empleados = new List<empleado>();

        public trabajo()
        {
            
        }



        public trabajo(int id, string direccion, string observacion, Decimal total, string estado, string fecha, int tiempo, cliente cliente)
        {
            this.id = id;
            this.direccion = direccion;
            this.observacion = observacion;
            this.total = total;
            this.estado = estado;
            this.fecha = fecha;
            this.tiempo = tiempo;
            this.cliente = cliente;
        }

        public int Id { get => id; set => id = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public decimal Total { get => total; set => total = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public int Tiempo { get => tiempo; set => tiempo = value; }
        internal cliente Cliente { get => cliente; set => cliente = value; }
        internal List<empleado> Empleados { get => empleados; set => empleados = value; }
    }
}
    
    
