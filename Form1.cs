using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABM_CLIENTES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
       
               
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void metroUserControl1_Load_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new Clientes());
            
        }

        

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        

       
        

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new Empleados());
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChild.Controls.Add(childForm);
            panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildForm(new Pedidos());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openChildForm(new Pagados());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new Busqueda());
        }
    }
}
