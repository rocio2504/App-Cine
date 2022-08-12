using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace Login_cine
{
    public partial class Usuario : Form
    {
       
        SQLControl sqlControl = new SQLControl();
        public Usuario()
        {
            InitializeComponent();

            this.ttmensaje1.SetToolTip(this.button2, "AGREGAR");
            this.ttmensaje1.SetToolTip(this.button3, "MODIFICAR");
            this.ttmensaje1.SetToolTip(this.button4, "ELIMINAR");
            this.ttmensaje1.SetToolTip(this.button5, "REPORTES");
            this.ttmensaje1.SetToolTip(this.button6, "ACTUALIZAR TABLA");
            this.ttmensaje1.SetToolTip(this.button7, "BUSCAR");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // this.Hide();
            //Ventana2 VentanaMenu = new Ventana2();
            //VentanaMenu.Show();
            //este boton es para cerrar
            this.Close();
        }

        SqlConnection cnn = new SqlConnection("Data Source =.; Initial Catalog = Cine; Integrated Security = True");

        public void llenar_tabla()
        {
            DataTable tabla = new DataTable();
            tabla = sqlControl.mostrarUsuarios();
            dataGridView1.DataSource = tabla;
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            /*  try
              {
                  string consulta = "select* from Usuario";
                  SqlDataAdapter adaptador = new SqlDataAdapter(consulta,cnn);
                  DataTable dt = new DataTable();
                  adaptador.Fill(dt);
                  dataGridView1.DataSource = dt;
              }
              catch (Exception exc)
              {
                  MessageBox.Show(exc.Message);
              }*/
            textBox2.Visible = false;
            mostrarUsuario();
            dataGridView2.Visible = false;
            
        }

        public void mostrarUsuario()
        {
            DataTable tabla = new DataTable();
            tabla = sqlControl.mostrarUsuarios();
            dataGridView1.DataSource = tabla;
        }

        public void buscarUsuario()
        {
            DataTable tabla = new DataTable();
            tabla = sqlControl.buscarUser(textBox1.Text);
            dataGridView2.DataSource = tabla;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
        }


        private void button2_Click(object sender, EventArgs e)
        {
           //este boton es para agregar Usuario
            AgregarUsuario agregar = new AgregarUsuario();
            agregar.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //este boton es para ACTUALIZAR TABLA
            textBox1.Text = "";
            dataGridView2.Visible = false;
            dataGridView1.Visible = true;
            llenar_tabla();

        }
                               
    private void button3_Click(object sender, EventArgs e)
        {
            
            //BOTON PARA EDITAR

            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           int n = e.RowIndex;
           if(n!=-1)
            {
               textBox2.Text= dataGridView1.Rows[n].Cells[0].Value.ToString();                             
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          //string a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
           //string b = dataGridView1.CurrentRow.Cells[1].Value.ToString();
          
         }

        private void button4_Click(object sender, EventArgs e)
        {
            //boton eliminar
            // string a = textBox2.Text;
            if (MessageBox.Show("¿Esta seguro que desea eliminar este registro?", "El Sistema dice:",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string a = sqlControl.eliminarUsuario(textBox2.Text);
                MessageBox.Show(a);
                mostrarUsuario();
            }
        }



        private void button7_Click(object sender, EventArgs e)
        {
            //BOTON BUSCAR
            buscarUsuario();

        }
    }
}
