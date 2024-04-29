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
using System.Globalization;
using System.Security.Cryptography;

namespace ABM_CLIENTES
{
    public partial class Modificar_Pedido : Form
    {
        public Modificar_Pedido(int id_Pedido)
        {
            InitializeComponent();
            Conexion.OpenConexion();
            comboBox1.DataSource = pCliente.GetAll();
            comboBox1.DisplayMember = "Nombre"; // Cambia según la propiedad de tu objeto 'cliente'
            comboBox1.ValueMember = "Id";
            listBox1.DataSource = pEmpleado.GetAll();
            trabajo laburo = pTrabajo.GetById(id_Pedido);
            cliente client = pCliente.GetById(laburo.Cliente.Id);
            
            objetoBuscado =client;
            seleccion();
            textBox1.Text = laburo.Direccion;
            richTextBox1.Text = laburo.Observacion;
            textBoxAmount.Text = laburo.Total.ToString();
            fechaStr = laburo.Fecha;
            seleccionFecha();
            numericUpDown1.Value = laburo.Tiempo;
            id_laburo = laburo.Id;
            Ids_empleados = pTrabajo.empleadosTrabajo(laburo.Id);
            Listar();
            seleccionE = laburo.Estado;
            seleccionEstado();
            id_pedidito = id_Pedido;


        }
        //variables globales
        
        cliente objetoBuscado ;
        String fechaStr;
        int id_laburo;
        List<empleado> Ids_empleados;
        string seleccionE;
        int id_pedidito;
        //----------------------------------------

        public void Listar()
        {
            trabajo t = pTrabajo.GetById(Convert.ToInt32(id_laburo));
            List<empleado> empleadosva = pTrabajo.empleadosTrabajoID(t.Id);

            // Crear una nueva lista con los elementos de listBox1.Items
            List<empleado> listBoxEmpleados = new List<empleado>();
            foreach (var item in listBox1.Items)
            {
                if (item is empleado empleadoItem)
                {
                    listBoxEmpleados.Add(empleadoItem);
                }
            }

            foreach (empleado item in listBoxEmpleados)
            {
                foreach (empleado vari in empleadosva)
                {
                   
                    if (item.Id == vari.Id)
                    {
                        
                        listBox1.SetSelected(listBox1.Items.IndexOf(item), true);
                       
                    }
                }
            }
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
                t.Total = decimal.Parse(textBoxAmount.Text);
                t.Direccion = textBox1.Text;
                t.Tiempo = int.Parse(numericUpDown1.Value.ToString());
                t.Estado = comboBox2.Text;
                pTrabajo.Update(t, id_pedidito);
                
                foreach (empleado emp in listBox1.SelectedItems)
                {
                    pTrabajo.UpdateTrabajoEmpleado(id_pedidito, emp);
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private const int MaxSelectedEmployees = 5; // Número máximo de empleados seleccionables

        
        
        public void seleccionEmpleados()
        {
            foreach (empleado item in listBox1.Items)
            {
                foreach (empleado vari in Ids_empleados)
                {
                    if (item.Id == vari.Id)
                    {
                        listBox1.SetSelected(listBox1.Items.IndexOf(vari), true);
                    }
                }

    
            }
        }
        public void seleccionFecha()
        {
            DateTime fecha;
            if (DateTime.TryParseExact(fechaStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha))
            {
                // Establecer el valor del DateTimePicker con la fecha creada.
                dateTimePicker1.Value = fecha;
            }
            else
            {
                // Si no se puede convertir la cadena, muestra un mensaje de error o realiza alguna otra acción.
                MessageBox.Show("Fecha no válida. Verifica el formato.");
            }
        }
        public void seleccionEstado()
        {
            int index = comboBox2.FindStringExact(seleccionE);
            if (index != ListBox.NoMatches)
            {
                comboBox2.SelectedItem = seleccionE;
            }
        } 
        
        public void seleccion()
        {
            
        
        foreach (cliente item in comboBox1.Items)
        {
            if (item.Id == objetoBuscado.Id)
            {
            objetoBuscado = item;
            break;
            }
        }

            // Si se encontró el objeto, establecemos el SelectedItem del ComboBox.
        if (objetoBuscado != null)
          {
             comboBox1.SelectedItem = objetoBuscado;
          }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MoneyTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            altaTrabajo();
            this.Close();   
        }
    }
}
