using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_cine
{
    public partial class Reporte_Pelicula : Form
    {

        SQLControl sqlControl = new SQLControl();
        public Reporte_Pelicula()
        {
            InitializeComponent();
        }

        public void filtroGenero()
        {
            DataTable tabla = new DataTable();
            tabla = sqlControl.filtraGenero(comboBox1.Text);
            dataGridView1.DataSource = tabla;
        }

        public void filtroClasific()
        {
            DataTable tabla = new DataTable();
            tabla = sqlControl.filtraClasific(comboBox2.Text);
            dataGridView1.DataSource = tabla;
        }
        public void filtroFormat()
        {
            DataTable tabla = new DataTable();
            tabla = sqlControl.filtraFormat(comboBox3.Text);
            dataGridView1.DataSource = tabla;
        }
        public void filtroEstreno()
        {
            DataTable tabla = new DataTable();
            tabla = sqlControl.filtraEstreno(comboBox4.Text);
            dataGridView1.DataSource = tabla;
        }
        
        public void verPeli()
        {
            DataTable tabla = new DataTable();
            tabla = sqlControl.vertodoPeli();
            dataGridView1.DataSource = tabla;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            filtroGenero();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //filtrar formato
            filtroFormat();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //filtrar clasificacion
            filtroClasific();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //filtrar año de estreno
            filtroEstreno();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            verPeli();
        }

        private void Reporte_Pelicula_Load(object sender, EventArgs e)
        {
            verPeli();
        }
    }
}
