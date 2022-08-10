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
    public partial class Reporte_Cliente : Form
    {
        SQLControl sqlControl = new SQLControl();

        public Reporte_Cliente()
        {
            InitializeComponent();
        }

        public void filtroCliente()
        {
            DataTable tabla = new DataTable();
            tabla = sqlControl.filtrarCliente(comboBox1.Text);
            dataGridView1.DataSource = tabla;
        }

        public void verCliente()
        {
            DataTable tabla = new DataTable();
            tabla = sqlControl.vertodoClient();
            dataGridView1.DataSource = tabla;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //filtrar x distrito
            filtroCliente();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            verCliente();
        }

        private void Reporte_Cliente_Load(object sender, EventArgs e)
        {
            verCliente();
        }
    }
}
