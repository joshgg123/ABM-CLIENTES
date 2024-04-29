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
    public partial class Empleados : Form
    {
        public Empleados()
        {
            InitializeComponent();
            Conexion.OpenConexion();
            CargarClientes();
        }
        private void CargarClientes()
        {
            dataGridViewE.DataSource = pEmpleado.GetAll();
        }
        public void altaEmpleado()
        {
            empleado c = new empleado();
            if (nomEmpleado.Text != "" && apeEmpleado.Text != "" && nomEmpleado.Text != "Nombre" && apeEmpleado.Text != "Apellido")
            {
                long telefono;
                if (long.TryParse(telEmpleado.Text, out telefono))
                {
                    c.Nombre = nomEmpleado.Text;
                    c.Apellido = apeEmpleado.Text;
                    c.Telefono = telEmpleado.Text;
                    pEmpleado.Save(c);
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


        private void nomEmpleado_Enter(object sender, EventArgs e)
        {
            if (nomEmpleado.Text == "Nombre")
            {
                nomEmpleado.Text = "";
                nomEmpleado.ForeColor = Color.Silver;
            }
        }

        private void nomEmpleado_Leave(object sender, EventArgs e)
        {
            if (nomEmpleado.Text == "")
            {
                nomEmpleado.Text = "Nombre";
                nomEmpleado.ForeColor = Color.Silver;
            }
        }
        private void apeEmpleado_Enter(object sender, EventArgs e)
        {
            if (apeEmpleado.Text == "Apellido")
            {
                apeEmpleado.Text = "";
                apeEmpleado.ForeColor = Color.Silver;
            }
        }

        private void apeEmpleado_Leave(object sender, EventArgs e)
        {
            if (apeEmpleado.Text == "")
            {
                apeEmpleado.Text = "Apellido";
                apeEmpleado.ForeColor = Color.Silver;
            }
        }
        private void telEmpleado_Enter(object sender, EventArgs e)
        {

            
            if (telEmpleado.Text == "Telefono")
            {
                telEmpleado.Text = "";
                telEmpleado.ForeColor = Color.Silver;
            }
        }

        private void telEmpleado_Leave(object sender, EventArgs e)
        {
            if (telEmpleado.Text == "")
            {
                telEmpleado.Text = "Telefono";
                telEmpleado.ForeColor = Color.Silver;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dataGridViewE.SelectedRows.Count > 0)
            {
                // Obtener el valor de la columna deseada (por ejemplo, la columna 0)
                string valorColumnaSeleccionada = dataGridViewE.SelectedRows[0].Cells[0].Value.ToString();

                // Abrir el otro formulario y pasar el valor a través de un constructor o una propiedad
                new modificarEmpleado(int.Parse(valorColumnaSeleccionada)).ShowDialog(); // Suponiendo que el constructor del formulario acepta el valor como parámetro
                CargarClientes();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila en la grilla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void LimpiarTextBox()
        {
            nomEmpleado.Text = "Nombre";
            nomEmpleado.ForeColor = Color.Silver;
            apeEmpleado.Text = "Apellido";
            apeEmpleado.ForeColor = Color.Silver;
            telEmpleado.Text = "Telefono";
            telEmpleado.ForeColor = Color.Silver;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            altaEmpleado();
            CargarClientes();
            LimpiarTextBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewE.SelectedRows.Count > 0)
            {
                // Obtener el valor de la columna deseada (por ejemplo, la columna 0)
                string valorColumnaSeleccionada = dataGridViewE.SelectedRows[0].Cells[0].Value.ToString();
                pEmpleado.Delete(int.Parse(valorColumnaSeleccionada));
                CargarClientes();

            }
        }

        private void Empleados_Load(object sender, EventArgs e)
        {

        }
    }
}
