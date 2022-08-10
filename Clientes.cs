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
    public partial class Clientes : Form
    {

        SQLControl sqlControl = new SQLControl();
        public Clientes()
        {
            InitializeComponent();
            this.ttmensaje2.SetToolTip(this.button2, "AGREGAR");
            this.ttmensaje2.SetToolTip(this.button3, "MODIFICAR");
            this.ttmensaje2.SetToolTip(this.button4, "ELIMINAR");
            this.ttmensaje2.SetToolTip(this.button5, "REPORTES");
            this.ttmensaje2.SetToolTip(this.button6, "NUEVO");
            this.ttmensaje2.SetToolTip(this.button7, "ACTUALIZAR");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // this.Hide();
            //Ventana2 VentanaMenu = new Ventana2();
            //VentanaMenu.Show();
            this.Close();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            mostrarCliente();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //boton NUEVO
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "Seleccione:";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            dateTimePicker1.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
            //textBox8.Text = "";
            comboBox2.Text = "Seleccione:";
            textBox2.Focus();
        }

        public void mostrarCliente()
        {
            DataTable tabla = new DataTable();
            tabla = sqlControl.mostrarCliente();
            dataGridView1.DataSource = tabla;
        }

        public void buscarClient()
        {
            //este metodo para buscar clientes x código,nombre o apellido
            DataTable tabla = new DataTable();
            tabla = sqlControl.buscarCs(textBox1.Text.Trim());
            dataGridView1.DataSource = tabla;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = e.RowIndex;
            textBox2.Text = dataGridView1.Rows[n].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[n].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[n].Cells[2].Value.ToString();
            comboBox1.Text=dataGridView1.Rows[n].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[n].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[n].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[n].Cells[6].Value.ToString();
            dateTimePicker1.Text= dataGridView1.Rows[n].Cells[7].Value.ToString();
            //textBox8.Text = dataGridView1.Rows[n].Cells[8].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[n].Cells[8].Value.ToString();
        }

        private bool verificarCampos()
        {
            bool ok = true;
            if (textBox2.Text == "")
            {
                ok = false;
                erMessage.SetError(textBox2, "Ingresar Código");
            }
            if (textBox3.Text == "")
            {
                ok = false;
                erMessage.SetError(textBox3, "Ingresar Nombre");

            }

            if (textBox4.Text == "")
            {
                ok = false;
                erMessage.SetError(textBox4, "Ingresar Apellido");

            }

            if (textBox5.Text == "")
            {
                ok = false;
                erMessage.SetError(textBox5, "Ingresar DNI");
            }

            if (textBox6.Text == "")
            {
                ok = false;
                erMessage.SetError(textBox6, "Ingresar Email");
            }

            if (textBox7.Text == "")
            {
                ok = false;
                erMessage.SetError(textBox7, "Ingresar Teléfono");
            }

            return ok;

        }

        private void borrarMensajeError()
        {
            erMessage.SetError(textBox2, "");
            erMessage.SetError(textBox3, "");
            erMessage.SetError(textBox4, "");
            erMessage.SetError(textBox5, "");
            erMessage.SetError(textBox6, "");
            erMessage.SetError(textBox7, "");
            //erMessage.SetError(textBox8, "");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //BOTON AGREGAR CLIENTE
            borrarMensajeError();
             if(verificarCampos())
            {
              string r = sqlControl.grabarCliente(textBox2.Text, textBox3.Text,  textBox4.Text, comboBox1.Text,
              textBox5.Text, textBox6.Text, textBox7.Text, dateTimePicker1.Text, comboBox2.Text);
              MessageBox.Show(r);
              mostrarCliente();
             }
        }

        private void button4_Click(object sender, EventArgs e)
        {            
           if (MessageBox.Show("¿Esta seguro que desea eliminar este registro?", "El Sistema dice:",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                string delete = sqlControl.eliminarRegistro(textBox2.Text);
                MessageBox.Show(delete);
                mostrarCliente();
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox1.Text = "Seleccione:";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                dateTimePicker1.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
                //textBox8.Text = "";
                comboBox2.Text = "Seleccione:";
                textBox2.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string editar = sqlControl.editarCliente(textBox2.Text, textBox3.Text, textBox4.Text, comboBox1.Text,
            textBox5.Text, textBox6.Text, textBox7.Text, dateTimePicker1.Text, comboBox2.Text);
            MessageBox.Show(editar);
            mostrarCliente();

        }



        private void button7_Click(object sender, EventArgs e)
        {
            //BOTON BUSCAR

            /*string delete = sqlControl.eliminarRegistro(textBox2.Text);
            MessageBox.Show(delete);
            mostrarCliente();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text ="Seleccione:";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            dateTimePicker1.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
            textBox8.Text = "";*/

            mostrarCliente();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reporte_Cliente report = new Reporte_Cliente();
            report.ShowDialog();

        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            int num;
            if (!int.TryParse(textBox5.Text, out num))
            {
                erMessage.SetError(textBox5, "Ingrese un valor en números");
            }
            else
            {
                erMessage.SetError(textBox5, "");

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.BackColor == Color.Gray)
            {
                textBox8.Enabled = true;
                button9.Enabled = true;
                button8.BackColor = Color.Red;
            }
            else
            {
                button8.BackColor = Color.Gray;
                textBox8.Enabled = false;
                button9.Enabled = false;                             
            }
            
        }



        private void button9_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Add(textBox8.Text);
            textBox8.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            buscarClient();
        }
    }
}
