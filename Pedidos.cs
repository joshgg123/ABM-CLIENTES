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
    public partial class Pedidos : Form
    {
        public Pedidos()
        {
            Conexion.OpenConexion();
            InitializeComponent();
            CargarPedidos();
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
            dataGridView1.DataSource = pTrabajo.GetAll();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

            
            
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            new altaPedidos().ShowDialog();
            CargarPedidos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el valor de la columna deseada (por ejemplo, la columna 0)
                string valorColumnaSeleccionada = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                // Abrir el otro formulario y pasar el valor a través de un constructor o una propiedad
                new Modificar_Pedido(int.Parse(valorColumnaSeleccionada)).ShowDialog(); // Suponiendo que el constructor del formulario acepta el valor como parámetro
                CargarPedidos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila en la grilla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dataGridView4_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            

            if (dataGridView1.SelectedRows.Count > 0)
            {
                string valorColumnaSeleccionada = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                trabajo t = pTrabajo.GetById(Convert.ToInt32(valorColumnaSeleccionada));
                dataGridView2.DataSource = pTrabajo.empleadosTrabajo(t.Id);
                dataGridView4.DataSource = pTrabajo.clientesTrabajo(t.Id);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el valor de la columna deseada (por ejemplo, la columna 0)
                string valorColumnaSeleccionada = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                pTrabajo.Delete(int.Parse(valorColumnaSeleccionada));
                CargarPedidos();

            }
        }
    }
}
