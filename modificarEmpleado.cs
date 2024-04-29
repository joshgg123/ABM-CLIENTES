using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ABM_CLIENTES.clases.persistencia;
using ABM_CLIENTES.clases;
using ABM_CLIENTES.Persistencia;

namespace ABM_CLIENTES
{
    public partial class modificarEmpleado : Form
    {
        public modificarEmpleado(int id_emplo)
        {
            InitializeComponent();
            Conexion.OpenConexion();
            empleado empleadito = pEmpleado.GetById(id_emplo);
            textBoxE.Text = empleadito.Nombre;
            textBox2E.Text = empleadito.Apellido;
            textBox3E.Text = empleadito.Telefono;
            id = id_emplo;
        }
        int id;
        public void altaEmpleado()
        {
            empleado c = new empleado();
            if (textBoxE.Text != "" && textBox2E.Text != "")
            {
                long telefono;
                if (long.TryParse(textBox3E.Text, out telefono))
                {
                    c.Nombre = textBoxE.Text;
                    c.Apellido = textBox2E.Text;
                    c.Telefono = textBox3E.Text;
                    pEmpleado.Update(c, id);
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


        private void button2E_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void button1E_Click(object sender, EventArgs e)
        {
            altaEmpleado();
            this.Close();
        }
    }
}
