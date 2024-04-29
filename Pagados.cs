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
    public partial class Pagados : Form
    {
        public Pagados()
        {
            InitializeComponent();
            Conexion.OpenConexion();
            CargarClientes();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Habilitar el ajuste automático del texto dentro de las celdas.
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Establecer el ancho deseado para la columna que contiene el texto largo.
            int desiredColumnWidth = 400; // Ajusta el valor según tus necesidades.

            // Obtener la referencia a la columna que contiene el texto largo (reemplaza "yourLongTextColumnIndex" con el índice correcto).


            // Establecer el ancho deseado para la columna que contiene el texto largo.
            dataGridView1.Columns[2].Width = desiredColumnWidth;
        }
        public void CargarClientes()
        {
            
            dataGridView1.SelectionChanged -= dataGridView1_SelectionChanged; // Desasociar el evento temporalmente
            dataGridView1.DataSource = pTrabajo.GetAllPagado();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
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
    }
}
