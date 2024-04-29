using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABM_CLIENTES.Persistencia;

namespace ABM_CLIENTES.clases.persistencia
{
    internal class pEmpleado
    {
        public static void Save(empleado e)
        {

            //Creo script SQL a utilizar
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Empleado (nombre, apellido, telefono) VALUES (@nombre, @apellido, @telefono)");
            //Cargo parametros
            cmd.Parameters.Add(new SQLiteParameter("@nombre", e.Nombre));
            cmd.Parameters.Add(new SQLiteParameter("@apellido", e.Apellido));
            cmd.Parameters.Add(new SQLiteParameter("@telefono", e.Telefono));

            //asigno conexion
            cmd.Connection = Conexion.Connection;
            cmd.ExecuteNonQuery();
        }
        public static void Update(empleado e, int id)
        {
            //Creo script SQL a utilizar
            SQLiteCommand cmd = new SQLiteCommand("UPDATE Empleado SET nombre = @nombre, apellido = @apellido, telefono = @telefono WHERE id = @id");
            //Cargo parametros
            cmd.Parameters.Add(new SQLiteParameter("@nombre", e.Nombre));
            cmd.Parameters.Add(new SQLiteParameter("@apellido", e.Apellido));
            cmd.Parameters.Add(new SQLiteParameter("@telefono", e.Telefono));
            cmd.Parameters.Add(new SQLiteParameter("@id", id));
            //asigno conexion
            cmd.Connection = Conexion.Connection;
            cmd.ExecuteNonQuery();
        }
        public static void Delete(int id)
        {
            //Creo script SQL a utilizar
            SQLiteCommand cmd = new SQLiteCommand("UPDATE Empleado SET avaible=@avaible WHERE id = @id");
            //Cargo parametros
            cmd.Parameters.Add(new SQLiteParameter("@avaible", 0));
            cmd.Parameters.Add(new SQLiteParameter("@id", id));
            //asigno conexion
            cmd.Connection = Conexion.Connection;
            cmd.ExecuteNonQuery();
        }
        public static empleado GetById(int id)
        {
            empleado e = new empleado();
            //Creo script SQL a utilizar
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Empleado WHERE id = @id");
            //Cargo parametros
            cmd.Parameters.Add(new SQLiteParameter("@id", id));
            //asigno conexion
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();
            if (obdr != null)
            {
                while (obdr.Read())
                {
                    e.Id = int.Parse(obdr["id"].ToString());
                    e.Nombre = obdr["nombre"].ToString();
                    e.Apellido = obdr["apellido"].ToString();
                    e.Telefono = obdr["telefono"].ToString();
                }
            }
            return e;
        }
        public static List<empleado> GetAll()
        {
            List<empleado> ls = new List<empleado>();
            //Creo script SQL a utilizar
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Empleado WHERE avaible = 1");
            //asigno conexion
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();
            if (obdr != null)
            {
                while (obdr.Read())
                {
                    empleado e = new empleado();
                    e.Id = int.Parse(obdr["id"].ToString());
                    e.Nombre = obdr["nombre"].ToString();
                    e.Apellido = obdr["apellido"].ToString();
                    e.Telefono = obdr["telefono"].ToString();
                    ls.Add(e);
                }
            }
            return ls;
        }




    }
}
