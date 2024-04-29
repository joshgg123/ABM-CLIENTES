using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
    public partial class altaPedidos : Form
    {
        public altaPedidos()
        {
            InitializeComponent();
            comboBox1.DataSource = pCliente.GetAll();
            comboBox1.DisplayMember = "Nombre"; // Cambia según la propiedad de tu objeto 'cliente'
            comboBox1.ValueMember = "Id";
            listBox1.DataSource = pEmpleado.GetAll();
            //mensegge box
            
        }
       
        public void altaTrabajo()
        {
            trabajo t = new trabajo();
            if (comboBox1.Text != "" && listBox1.Text != "" && comboBox1.Text != "Nombre" && listBox1.Text != "Apellido")
            {
                DateTime fechaSeleccionada = dateTimePicker1.Value;
                string fechaFormateada = fechaSeleccionada.ToString("dd/MM/yyyy");
                cliente Cliente = (cliente)comboBox1.SelectedItem;
                t.Fecha = fechaFormateada;
                t.Observacion = richTextBox1.Text;
                t.Total = decimal.Parse( textBoxAmount.Text);
                t.Direccion = textBox1.Text;
                t.Tiempo = int.Parse(numericUpDown1.Value.ToString());
                t.Estado = "Pendiente";
                pTrabajo.Save(t,Cliente);
                int id_trabajo = pTrabajo.GetUltimoId();
                foreach (empleado emp in listBox1.SelectedItems)
                {
                    pTrabajo.SaveTrabajoEmpleado(id_trabajo,emp);
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void MoneyTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProfesor_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void altaPedidos_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
      

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            altaTrabajo();
            this.Close();

        }
    }
}
