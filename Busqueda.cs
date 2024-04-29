using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ABM_CLIENTES.clases;
using ABM_CLIENTES.clases.persistencia;
using ABM_CLIENTES.Persistencia;

namespace ABM_CLIENTES
{
    public partial class Busqueda : Form
    {
        public Busqueda()
        {

            Conexion.OpenConexion();
            InitializeComponent();
            
            


        }
        private cliente seleccionComboBox;
        public void autoSize()
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Habilitar el ajuste automático del texto dentro de las celdas.
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Establecer el ancho deseado para la columna que contiene el texto largo.
            int desiredColumnWidth = 400; // Ajusta el valor según tus necesidades.

            // Obtener la referencia a la columna que contiene el texto largo (reemplaza "yourLongTextColumnIndex" con el índice correcto).


            // Establecer el ancho deseado para la columna que contiene el texto largo.
            dataGridView1.Columns[2].Width = desiredColumnWidth;
        }

        public void CargarPedidos()
        {
            
            dataGridView1.SelectionChanged -= dataGridView1_SelectionChanged; // Desasociar el evento temporalmente
            dataGridView1.DataSource = pTrabajo.trabajosCliente(seleccionComboBox.Id);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Habilitar el ajuste automático del texto dentro de las celdas.
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Establecer el ancho deseado para la columna que contiene el texto largo.
            int desiredColumnWidth = 400; // Ajusta el valor según tus necesidades.

            // Obtener la referencia a la columna que contiene el texto largo (reemplaza "yourLongTextColumnIndex" con el índice correcto).


            // Establecer el ancho deseado para la columna que contiene el texto largo.
            dataGridView1.Columns[2].Width = desiredColumnWidth;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // Implementa el código necesario para cargar los pedidos en el dataGridView1
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Implementa cualquier lógica necesaria cuando cambie la selección en dataGridView1
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string valorColumnaSeleccionada = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                trabajo t = pTrabajo.GetById(Convert.ToInt32(valorColumnaSeleccionada));
                dataGridView2.DataSource = pTrabajo.empleadosTrabajo(t.Id);
                
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Implementa cualquier lógica necesaria cuando cambie el texto en textBox1
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text.ToLower().Trim();
            string apellido = textBox2.Text.ToLower().Trim();

            // Verifica si ambos criterios de búsqueda están vacíos
            if (string.IsNullOrEmpty(nombre) && string.IsNullOrEmpty(apellido))
            {
                MessageBox.Show("Por favor, ingresa al menos un criterio de búsqueda.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<cliente> clientesCoincidentes;

            if (!string.IsNullOrEmpty(nombre) && string.IsNullOrEmpty(apellido))
            {
                // Busca por nombre
                clientesCoincidentes = ObtenerClientesPorNombre(nombre);
            }
            else if (string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(apellido))
            {
                // Busca por apellido
                clientesCoincidentes = ObtenerClientesPorApellido(apellido);
            }
            else
            {
                // Busca por nombre y apellido
                clientesCoincidentes = ObtenerClientesPorNombreYApellido(nombre, apellido);
            }


            // Asigna los clientes coincidentes a comboBox1 para mostrarlos
            comboBox1.DataSource = clientesCoincidentes;
            
            
        }

        private List<cliente> ObtenerClientesPorNombre(string nombre)
        {
            Conexion.OpenConexion();
            List<cliente> clientesCoincidentes = new List<cliente>();
            SQLiteCommand cmd = new SQLiteCommand("SELECT id, nombre, apellido, telefono FROM Cliente WHERE LOWER(nombre) LIKE '%' || @nombre || '%' AND avaible = 1");
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    cliente cliente = new cliente();
                    cliente.Id = int.Parse(reader["id"].ToString());
                    cliente.Nombre = reader["nombre"].ToString();
                    cliente.Apellido = reader["apellido"].ToString();
                    cliente.Telefono = reader["telefono"].ToString();
                    clientesCoincidentes.Add(cliente);
                }
            }
            return clientesCoincidentes;
        }

        private List<cliente> ObtenerClientesPorApellido(string apellido)
        {
            Conexion.OpenConexion();
            List<cliente> clientesCoincidentes = new List<cliente>();
            SQLiteCommand cmd = new SQLiteCommand("SELECT id, nombre, apellido, telefono FROM Cliente WHERE LOWER(apellido) LIKE '%' || @apellido || '%' AND avaible = 1");
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    cliente cliente = new cliente();
                    cliente.Id = int.Parse(reader["id"].ToString());
                    cliente.Nombre = reader["nombre"].ToString();
                    cliente.Apellido = reader["apellido"].ToString();
                    cliente.Telefono = reader["telefono"].ToString();
                    clientesCoincidentes.Add(cliente);
                }
            }
            return clientesCoincidentes;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private List<cliente> ObtenerClientesPorNombreYApellido(string nombre, string apellido)
        {
            Conexion.OpenConexion();
            List<cliente> clientesCoincidentes = new List<cliente>();
            SQLiteCommand cmd = new SQLiteCommand("SELECT id, nombre, apellido, telefono FROM Cliente WHERE LOWER(nombre) LIKE '%' || @nombre || '%' AND LOWER(apellido) LIKE '%' || @apellido || '%' AND avaible = 1");
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Connection = Conexion.Connection;
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    cliente cliente = new cliente();
                    cliente.Id = int.Parse(reader["id"].ToString());
                    cliente.Nombre = reader["nombre"].ToString();
                    cliente.Apellido = reader["apellido"].ToString();
                    cliente.Telefono = reader["telefono"].ToString();
                    clientesCoincidentes.Add(cliente);
                }
            }
            return clientesCoincidentes;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex >= 0)
            {
                // Obtener el valor seleccionado y guardarlo en la variable seleccionComboBox
                 seleccionComboBox = comboBox1.SelectedItem as cliente; // Supongo que la clase cliente es el tipo de objeto en el ComboBox
                CargarPedidos();
                // Ahora puedes usar la variable seleccionComboBox para acceder a la selección elegida
                // por ejemplo, puedes acceder a su propiedad cliente.Id si es necesario.
            }

        }
    }
}

