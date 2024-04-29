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


namespace ABM_CLIENTES
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            
            Conexion.OpenConexion();
            InitializeComponent();
            CargarClientes();
        }

        public void altaCliente()
        {
            
            cliente c = new cliente();
            if (nomCliente.Text != "" && apeCliente.Text != "" && nomCliente.Text != "Nombre" && apeCliente.Text != "Apellido")
            {
                long telefono;
                if (long.TryParse(telCliente.Text, out telefono))
                {
                    c.Nombre = nomCliente.Text;
                    c.Apellido = apeCliente.Text;
                    c.Telefono = telCliente.Text;
                    pCliente.Save(c);
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
        public void CargarClientes()
        {
            gridClientes.DataSource = pCliente.GetAll();
        }

        private void nomCliente_Enter(object sender, EventArgs e)
        {
            if (nomCliente.Text == "Nombre")
            {
                nomCliente.Text = "";
                nomCliente.ForeColor = Color.Silver;
            }
        }

        private void nomCliente_Leave(object sender, EventArgs e)
        {
            if (nomCliente.Text == "")
            {
                nomCliente.Text = "Nombre";
                nomCliente.ForeColor = Color.Silver;
            }
        }
        private void apeCliente_Enter(object sender, EventArgs e)
        {
            if (apeCliente.Text == "Apellido")
            {
                apeCliente.Text = "";
                apeCliente.ForeColor = Color.Silver;
            }
        }

        private void apeCliente_Leave(object sender, EventArgs e)
        {
            if (apeCliente.Text == "")
            {
                apeCliente.Text = "Apellido";
                apeCliente.ForeColor = Color.Silver;
            }
        }
        private void telCliente_Enter(object sender, EventArgs e)
        {
            if (telCliente.Text == "Telefono")
            {
                telCliente.Text = "";
                telCliente.ForeColor = Color.Silver;
            }
        }

        private void telCliente_Leave(object sender, EventArgs e)
        {
            if (telCliente.Text == "")
            {
                telCliente.Text = "Telefono";
                telCliente.ForeColor = Color.Silver;
            }
        }


        public void button2_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (gridClientes.SelectedRows.Count > 0)
            {
                // Obtener el valor de la columna deseada (por ejemplo, la columna 0)
                string valorColumnaSeleccionada = gridClientes.SelectedRows[0].Cells[0].Value.ToString();
                
                // Abrir el otro formulario y pasar el valor a través de un constructor o una propiedad
                new modificarCliente(int.Parse( valorColumnaSeleccionada)).ShowDialog(); // Suponiendo que el constructor del formulario acepta el valor como parámetro
                CargarClientes();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila en la grilla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }
        private void LimpiarTextBox()
        {
            nomCliente.Text = "Nombre";
            nomCliente.ForeColor = Color.Silver;
            apeCliente.Text = "Apellido";
            apeCliente.ForeColor = Color.Silver;
            telCliente.Text = "Telefono";
            telCliente.ForeColor = Color.Silver;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nomCliente_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            altaCliente();
            CargarClientes();
            LimpiarTextBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (gridClientes.SelectedRows.Count > 0)
            {
                // Obtener el valor de la columna deseada (por ejemplo, la columna 0)
                string valorColumnaSeleccionada = gridClientes.SelectedRows[0].Cells[0].Value.ToString();
                pCliente.Delete(int.Parse(valorColumnaSeleccionada));
                CargarClientes();

            }
        }

        
    }
}
