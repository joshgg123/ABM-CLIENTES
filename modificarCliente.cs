using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ABM_CLIENTES.Persistencia;
using ABM_CLIENTES.clases;
using ABM_CLIENTES.clases.persistencia;
using System.Data.SQLite;

namespace ABM_CLIENTES
{
    public partial class modificarCliente : Form
    {

        
        public modificarCliente(int id_client)
        {
            InitializeComponent();
            Conexion.OpenConexion();
            
            

            cliente client = pCliente.GetById(id_client);
            textBox1.Text = client.Nombre;
            textBox2.Text = client.Apellido;
            textBox3.Text = client.Telefono;
            id_clientito = id_client;

            
        }

    
        int id_clientito;
        public void altaCliente()
        {
            cliente c = new cliente();
            if (textBox1.Text != "" && textBox2.Text != "" )
            {
                long telefono;
                if (long.TryParse(textBox3.Text, out telefono))
                {
                    c.Nombre = textBox1.Text;
                    c.Apellido = textBox2.Text;
                    c.Telefono = textBox3.Text;
                    pCliente.Update(c, id_clientito);
                }
                else
                {
                    MessageBox.Show("El Teléfono debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        


        private void modificarCliente_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            altaCliente();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
