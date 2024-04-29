using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ABM_CLIENTES.clases;
using ABM_CLIENTES.clases.persistencia;
using System.Data.SQLite;
using ABM_CLIENTES.Persistencia;

namespace ABM_CLIENTES.clases.persistencia
{
    internal class pTrabajo
    {
        public static void Save(trabajo e, cliente c)
        {
            if (c == null)
            {
                throw new ArgumentNullException(nameof(c));
            }
            //Creo script SQL a utilizar
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Trabajo (id_cliente, direccion, observacion, total, estado, fecha, tiempo ) VALUES (@id_cliente, @direccion, @observacion, @total, @estado, @fecha, @tiempo)");
            //Cargo parametros
            cmd.Parameters.Add(new SQLiteParameter("@id_cliente", c.Id));
            cmd.Parameters.Add(new SQLiteParameter("@direccion", e.Direccion));
            cmd.Parameters.Add(new SQLiteParameter("@observacion", e.Observacion));
            cmd.Parameters.Add(new SQLiteParameter("@total", e.Total));
            cmd.Parameters.Add(new SQLiteParameter("@estado", e.Estado));
            cmd.Parameters.Add(new SQLiteParameter("@fecha", e.Fecha));
            cmd.Parameters.Add(new SQLiteParameter("@tiempo", e.Tiempo));
            
            //asigno conexion
            cmd.Connection = Conexion.Connection;
            cmd.ExecuteNonQuery();
        }
        public static List<int> idsE(int id)
        {
            List<int> ids = new List<int>();
            SQLiteCommand cmd = new SQLiteCommand("SELECT id_empleado FROM Empleado_Trabajo WHERE id_trabajo=@idT", Conexion.Connection);
            cmd.Parameters.AddWithValue("@idT", id);
            SQLiteDataReader obdr = cmd.ExecuteReader();

            while (obdr.Read())
            {
                ids.Add(obdr.GetInt32(0));
            }
            return ids;


        }
        public static List<empleado> empleadosTrabajo(int id)
        {

            List<empleado> empleados = new List<empleado>();
            SQLiteCommand cmd = new SQLiteCommand("SELECT e.id, e.nombre as nombre_empleado, e.apellido as apellido_empleado, e.telefono FROM Empleado_Trabajo et JOIN Empleado e ON et.id_empleado = e.id JOIN Trabajo t ON t.id = et.id_trabajo WHERE et.id_trabajo = @idT ", Conexion.Connection);
            cmd.Parameters.AddWithValue("@idT", id);
            SQLiteDataReader obdr = cmd.ExecuteReader();

            while (obdr.Read())
            {
                empleado e = new empleado();
                e.Id = obdr.GetInt32(0);
                e.Nombre = obdr.GetString(1);
                e.Apellido = obdr.GetString(2);
                e.Telefono = obdr.GetValue(3).ToString();
                empleados.Add(e);
            }
            return empleados;

        }
        public static List<trabajo> trabajosCliente(int id)
        {

            List<trabajo> trabajos = new List<trabajo>();
            SQLiteCommand cmd = new SQLiteCommand("SELECT t.id, t.direccion, t.observacion, t.total, t.estado, t.fecha, t.tiempo FROM Trabajo t JOIN Cliente c ON t.id_cliente = c.id WHERE t.id_cliente = @idC ", Conexion.Connection);
            cmd.Parameters.AddWithValue("@idC", id);
            SQLiteDataReader obdr = cmd.ExecuteReader();

            while (obdr.Read())
            {
                trabajo e = new trabajo();
                e.Id = int.Parse(obdr["id"].ToString());
                e.Direccion = obdr["direccion"].ToString();
                e.Observacion = obdr["observacion"].ToString();
                e.Total = decimal.Parse(obdr["total"].ToString());
                e.Estado = obdr["estado"].ToString();
                e.Fecha = obdr["fecha"].ToString();
                e.Tiempo = int.Parse(obdr["tiempo"].ToString());
                trabajos.Add(e);
            }
            return trabajos;
        }
        public static List<cliente> GetClientesByNameorLastName(string name, string lastName)
        {
            List<cliente> clientes = new List<cliente>();
            SQLiteCommand cmd = new SQLiteCommand("SELECT id, nombre, apellido, telefono FROM Cliente WHERE nombre LIKE @name OR apellido LIKE @lastName", Conexion.Connection);
            cmd.Parameters.AddWithValue("@name", "%" + name + "%");
            cmd.Parameters.AddWithValue("@lastName", "%" + lastName + "%");
            SQLiteDataReader obdr = cmd.ExecuteReader();

            while (obdr.Read())
            {
                cliente e = new cliente();
                e.Id = obdr.GetInt32(0);
                e.Nombre = obdr.GetString(1);
                e.Apellido = obdr.GetString(2);
                e.Telefono = obdr.GetValue(3).ToString();
                clientes.Add(e);
            }
            return clientes;

        }
        public static List<empleado> empleadosTrabajoID(int id)
        {

            List<empleado> empleados = new List<empleado>();
            SQLiteCommand cmd = new SQLiteCommand("SELECT e.id, e.nombre as nombre_empleado, e.apellido as apellido_empleado, e.telefono FROM Empleado_Trabajo et JOIN Empleado e ON et.id_empleado = e.id JOIN Trabajo t ON t.id = et.id_trabajo WHERE et.id_trabajo = @idT ", Conexion.Connection);
            cmd.Parameters.AddWithValue("@idT", id);
            SQLiteDataReader obdr = cmd.ExecuteReader();

            while (obdr.Read())
            {
                empleado e = new empleado();
                e.Id = obdr.GetInt32(0);
                e.Nombre = obdr.GetString(1);
                e.Apellido = obdr.GetString(2);
                e.Telefono = obdr.GetValue(3).ToString();
                empleados.Add(e);
            }
            return empleados;

        }
        public static List<cliente> clientesTrabajo(int id)
        {

            List<cliente> clientes = new List<cliente>();

            SQLiteCommand cmd = new SQLiteCommand("SELECT c.id, c.nombre as nombre_cliente, c.apellido as apellido_cliente, c.telefono FROM Trabajo t JOIN Cliente c ON c.id=t.id_cliente WHERE t.id = @idT", Conexion.Connection);
            cmd.Parameters.AddWithValue("@idT", id);
            SQLiteDataReader obdr = cmd.ExecuteReader();

            while (obdr.Read())
            {
                cliente c = new cliente();
                c.Id = obdr.GetInt32(0);
                c.Nombre = obdr.GetString(1);
                c.Apellido = obdr.GetString(2);
                c.Telefono = obdr.GetValue(3).ToString();

                clientes.Add(c);
            }
            return clientes;

        }



        public static int GetUltimoId()
        {
            int id = 0;
            SQLiteCommand cmd = new SQLiteCommand("SELECT MAX(id) FROM Trabajo", Conexion.Connection);
            SQLiteDataReader obdr = cmd.ExecuteReader();
            while (obdr.Read())
            {
                id = obdr.GetInt32(0);
            }
            return id;
        }
        public static void SaveTrabajoEmpleado(int id, empleado c) 
        {
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Empleado_Trabajo (id_empleado, id_trabajo) VALUES (@id_empleado, @id_trabajo)");
            //Cargo parametros
            cmd.Parameters.Add(new SQLiteParameter("@id_empleado", c.Id));
            cmd.Parameters.Add(new SQLiteParameter("@id_trabajo", id));
            //asigno conexion
            cmd.Connection = Conexion.Connection;
            cmd.ExecuteNonQuery();
            


        }
        public static void UpdateTrabajoEmpleado(int id, empleado c)
        {
            SQLiteCommand cmd = new SQLiteCommand("UPDATE Empleado_Trabajo SET id_empleado=@id_empleado WHERE id_trabajo=@id_trabajo");
            //Cargo parametros
            cmd.Parameters.Add(new SQLiteParameter("@id_empleado", c.Id));
            cmd.Parameters.Add(new SQLiteParameter("@id_trabajo", id));
            //asigno conexion
            cmd.Connection = Conexion.Connection;
            cmd.ExecuteNonQuery();

        }




        public static void Update(trabajo e, int id)
        {
            //Creo script SQL a utilizar
            SQLiteCommand cmd = new SQLiteCommand("UPDATE Trabajo SET direccion = @direccion, observacion = @observacion, total = @total, estado = @estado, fecha = @fecha, tiempo = @tiempo WHERE id = @id");
            //Cargo parametros
            cmd.Parameters.Add(new SQLiteParameter("@direccion", e.Direccion));
            cmd.Parameters.Add(new SQLiteParameter("@observacion", e.Observacion));
            cmd.Parameters.Add(new SQLiteParameter("@total", e.Total));
            cmd.Parameters.Add(new SQLiteParameter("@estado", e.Estado));
            cmd.Parameters.Add(new SQLiteParameter("@fecha", e.Fecha));
            cmd.Parameters.Add(new SQLiteParameter("@tiempo", e.Tiempo));
            cmd.Parameters.Add(new SQLiteParameter("@id", id));
            //asigno conexion
            cmd.Connection = Conexion.Connection;
            cmd.ExecuteNonQuery();
        }
        public static void Delete(int id)
        {
            //Creo script SQL a utilizar
            SQLiteCommand cmd = new SQLiteCommand("UPDATE Trabajo SET avaible=@avaible WHERE id = @idTrabajo");
            //Cargo parametros
            cmd.Parameters.Add(new SQLiteParameter("@avaible", 0));
            cmd.Parameters.Add(new SQLiteParameter("@idTrabajo", id));
            //asigno conexion
            cmd.Connection = Conexion.Connection;
            cmd.ExecuteNonQuery();
        }
        
       
        public static trabajo GetById(int id)
        {
            trabajo e = new trabajo();
            //Creo script SQL a utilizar
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Trabajo WHERE id = @idTrabajo");
            //Cargo parametros
            cmd.Parameters.Add(new SQLiteParameter("@idTrabajo", id));
            //asigno conexion
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();
            if (obdr != null)
            {
                while (obdr.Read())
                {
                    e.Id = int.Parse(obdr["id"].ToString());
                    e.Direccion = obdr["direccion"].ToString();
                    e.Observacion = obdr["observacion"].ToString();
                    e.Total = decimal.Parse(obdr["total"].ToString());
                    e.Estado = obdr["estado"].ToString();
                    e.Fecha = obdr["fecha"].ToString();
                    e.Tiempo = int.Parse(obdr["tiempo"].ToString());
                    e.Cliente = pCliente.GetById(int.Parse(obdr["id_cliente"].ToString()));
                }
            }
            return e;
        }
        public static List<trabajo> GetAll()
        {
            List<trabajo> ls = new List<trabajo>();
            //Creo script SQL a utilizar
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Trabajo WHERE avaible = 1 AND estado = 'Pendiente'");
            //asigno conexion
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();
            if (obdr != null)
            {
                while (obdr.Read())
                {
                    trabajo e = new trabajo();
                    e.Id = int.Parse(obdr["id"].ToString());
                    e.Direccion = obdr["direccion"].ToString();
                    e.Observacion = obdr["observacion"].ToString();
                    e.Total = decimal.Parse(obdr["total"].ToString());
                    e.Estado = obdr["estado"].ToString();
                    e.Fecha = obdr["fecha"].ToString();
                    e.Tiempo = int.Parse(obdr["tiempo"].ToString());
                    e.Cliente = pCliente.GetById( int.Parse(obdr["id_cliente"].ToString()));
                    ls.Add(e);
                }
            }
            return ls;
        }
        public static List<trabajo> GetAllPagado()
        {
            List<trabajo> ls = new List<trabajo>();
            //Creo script SQL a utilizar
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Trabajo WHERE avaible = 1 AND estado = 'Pagado'");
            //asigno conexion
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();
            if (obdr != null)
            {
                while (obdr.Read())
                {
                    trabajo e = new trabajo();
                    e.Id = int.Parse(obdr["id"].ToString());
                    e.Direccion = obdr["direccion"].ToString();
                    e.Observacion = obdr["observacion"].ToString();
                    e.Total = decimal.Parse(obdr["total"].ToString());
                    e.Estado = obdr["estado"].ToString();
                    e.Fecha = obdr["fecha"].ToString();
                    e.Tiempo = int.Parse(obdr["tiempo"].ToString());
                    e.Cliente = pCliente.GetById(int.Parse(obdr["id_cliente"].ToString()));
                    ls.Add(e);
                }
            }
            return ls;
        }



    }
}
