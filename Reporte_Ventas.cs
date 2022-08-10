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
    public partial class Reporte_Ventas : Form
    {
        SQLControl sqlControl = new SQLControl();

        public Reporte_Ventas()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        //metodos para el reportes ventas

        public void filtroFechas()
        {
            //este metodo es para filtrar tickets x 2 fechas
            DataTable tabla = new DataTable();
            tabla = sqlControl.verFTodoVenta(dateTimePicker1.Text, dateTimePicker2.Text);
            dataGridView1.DataSource = tabla;
        }
        
        public void filtroMesVenta()
        {
            //este metodo esta para filtrar ventas mensuales x cualquier año
            DataTable tabla = new DataTable();
            tabla = sqlControl.ventasMes(comboBox1.Text);
            dataGridView3.DataSource = tabla;
        }
        public void filtroDiaVenta()
        {
            //este metodo esta para filtrar ventas diarias x cualquier año
            DataTable tabla = new DataTable();
            tabla = sqlControl.ventasDia(comboBox2.Text);
            dataGridView3.DataSource = tabla;
        }
        public void filtroMesTicket()
        {
            //este metodo para contar los tickets x Mes
            DataTable tabla = new DataTable();
            tabla = sqlControl.contarTMes(comboBox3.Text);
            dataGridView3.DataSource = tabla;
        }

        public void filtroDiaTicket()
        {
            //este metodo para contar los tickets x dia 
            DataTable tabla = new DataTable();
            tabla = sqlControl.contarTDia(comboBox4.Text);
            dataGridView3.DataSource = tabla;
        }

        public void contarTxC()
        {
            // Cuántos tickets tiene cada cliente
            DataTable tabla = new DataTable();
            tabla = sqlControl.contarxClient();
            dataGridView2.DataSource = tabla;
        }
        public void contarTxV()
        {
            // Cuántos tickets GENERA CADA VENDEDOR
            DataTable tabla = new DataTable();
            tabla = sqlControl.contarxVend();
            dataGridView2.DataSource = tabla;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //VENTAS MENSUALES
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = true;
            filtroMesVenta();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //VER DETALLE TICKETS
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            filtroFechas();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //VENTAS DIARIAS
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = true;
            filtroDiaVenta();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //CANTIDAD DE TICKETS MENSUALES
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = true;
            filtroMesTicket();
         }

        private void button4_Click(object sender, EventArgs e)
        {
            //CANTIDAD DE TICKETS DIARIOS
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = true;
            filtroDiaTicket();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //CANTIDAD DE TICKETS POR CLIENTE
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
            contarTxC();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //CANTIDAD DE TICKETS POR VENDEDOR
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
            contarTxV();
        }

        private void Reporte_Ventas_Load(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
        }
    }
}
