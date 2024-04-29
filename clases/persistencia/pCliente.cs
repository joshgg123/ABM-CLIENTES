using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABM_CLIENTES.clases;
using ABM_CLIENTES.clases.persistencia;
using System.Data.SQLite;
using ABM_CLIENTES.Persistencia;

namespace ABM_CLIENTES.clases.persistencia
{
    internal class pCliente
    {
        public static void Save(cliente e)
        {

            //Creo script SQL a utilizar
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Cliente (nombre, apellido, telefono) VALUES (@nombre, @apellido, @telefono)");
            //Cargo parametros
            cmd.Parameters.Add(new SQLiteParameter("@nombre", e.Nombre));
            cmd.Parameters.Add(new SQLiteParameter("@apellido", e.Apellido));
            cmd.Parameters.Add(new SQLiteParameter("@telefono", e.Telefono));

            //asigno conexion
            cmd.Connection = Conexion.Connection;
            cmd.ExecuteNonQuery();
        }
        public static void Update(cliente e, int id)
        {
            //Creo script SQL a utilizar
            SQLiteCommand cmd = new SQLiteCommand("UPDATE Cliente SET nombre = @nombre, apellido = @apellido, telefono = @telefono WHERE id = @id");
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
            SQLiteCommand cmd = new SQLiteCommand("UPDATE Cliente SET avaible=@avaible WHERE id = @idCliente");
            //Cargo parametros
            cmd.Parameters.Add(new SQLiteParameter("@avaible", 0));
            cmd.Parameters.Add(new SQLiteParameter("@idCliente", id));
            //asigno conexion
            cmd.Connection = Conexion.Connection;
            cmd.ExecuteNonQuery();
        }
        public static List<string> GetIdNomApe()
        {

            List<string> lista = new List<string>();
            SQLiteCommand cmd = new SQLiteCommand("SELECT id, nombre, apellido FROM Cliente WHERE avaible = 1");
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();
            while (obdr.Read())
            {
                lista.Add(obdr.GetInt32(0).ToString() + " - " + obdr.GetString(1) + " " + obdr.GetString(2));
            }
            return lista;
        }
        public static cliente GetById(int id)
        {
            cliente e = new cliente();
            //Creo script SQL a utilizar
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Cliente WHERE id = @idCliente");
            //Cargo parametros
            cmd.Parameters.Add(new SQLiteParameter("@idCliente", id));
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
        public static List<cliente> GetAll()
        {
            Conexion.OpenConexion();
            List<cliente> ls = new List<cliente>();
            //Creo script SQL a utilizar
            SQLiteCommand cmd = new SQLiteCommand("SELECT id, nombre, apellido, telefono FROM Cliente WHERE avaible = 1");
            //asigno conexion
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();
            if (obdr != null)
            {
                while (obdr.Read())
                {
                    cliente e = new cliente();
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
