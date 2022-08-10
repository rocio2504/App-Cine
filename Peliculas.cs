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
    public partial class Pelicula : Form
    {
        SQLControl sqlControl = new SQLControl();

        SqlConnection cnn = new SqlConnection("Data Source =.; Initial Catalog = Cine; Integrated Security = True");
        public Pelicula()
        {
            InitializeComponent();
            this.ttmensaje3.SetToolTip(this.button1, "CERRAR");
            this.ttmensaje3.SetToolTip(this.button2, "AGREGAR");
            this.ttmensaje3.SetToolTip(this.button3, "MODIFICAR");
            this.ttmensaje3.SetToolTip(this.button4, "ELIMINAR");
            this.ttmensaje3.SetToolTip(this.button5, "REPORTES");
            this.ttmensaje3.SetToolTip(this.button7, "BUSCAR");
            this.ttmensaje3.SetToolTip(this.button8, "GUARDAR");
            this.ttmensaje3.SetToolTip(this.button9, "NUEVO");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* this.Hide();
             Ventana2 VentanaMenu = new Ventana2();
             VentanaMenu.Show();*/
            this.Close();
        }
        
        public void mostrarPelicula()
        {
            DataTable tabla = new DataTable();
            tabla = sqlControl.mostrarPeli();
            dataGridView1.DataSource = tabla;
        }


        private void button6_Click(object sender, EventArgs e)
        {
            //boton para cargar la imagen
            OpenFileDialog getImage = new OpenFileDialog();
            getImage.InitialDirectory = "C:\\";
            getImage.Filter = "Archivos de Imagen(*.jpg)(*.jpeg)|*.jpg;*.jpeg|PNG(*.png)|*.png|GIF(*.GIF)|* .gif ";
            if (getImage.ShowDialog() == DialogResult.OK)
            {
                picPelicula.ImageLocation = getImage.FileName;
                
            }
            else
            {
                MessageBox.Show("No se selecciono imagen", "Sin seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void Pelicula_Load(object sender, EventArgs e)
        {
            mostrarPelicula();
           // button9.Visible = false;
        }





        private void button8_Click(object sender, EventArgs e)
        {
            //BOTON PARA GUARDAR REGISTRO
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            picPelicula.Image.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);

            string resultado = sqlControl.IngresarPelicula(textBox2.Text, textBox3.Text, textBox4.Text, ms.GetBuffer(),
                textBox5.Text,comboBox1.Text, comboBox2.Text, comboBox3.Text,dateTimePicker1.Text);

            MessageBox.Show(resultado);
            //metodo para q actualize despues de guardar
            mostrarPelicula();
        }
              
        public string buscarPeliculas()
        {
            try
            {
                //metodo para buscar pelicula y que se muestre en los textbox
                DataTable dt = new DataTable();
                dt = sqlControl.buscarPelicula(textBox1.Text);
                textBox2.Text = dt.Rows[0][0].ToString();
                textBox3.Text = dt.Rows[0][1].ToString();
                textBox4.Text = dt.Rows[0][2].ToString();
                byte[] img = (byte[])dt.Rows[0][3];
                textBox5.Text = dt.Rows[0][4].ToString();
                comboBox1.Text = dt.Rows[0][5].ToString();
                comboBox2.Text = dt.Rows[0][6].ToString();
                comboBox3.Text = dt.Rows[0][7].ToString();
                dateTimePicker1.Text = dt.Rows[0][8].ToString();
                System.IO.MemoryStream ms = new System.IO.MemoryStream(img);
                picPelicula.Image = Image.FromStream(ms);
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            finally
            {
                cnn.Close();
            }
            return null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //BOTON BUSCAR
           buscarPeliculas();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[n].Cells[0].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reporte_Pelicula report = new Reporte_Pelicula();
            report.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //boton editar

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //BOTON AGREGAR 
            //nuevo boton nuevo
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "Seleccione:";
            comboBox2.Text = "Seleccione:";
            comboBox3.Text = "Seleccione:";
            dateTimePicker1.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
            textBox2.Focus();
            picPelicula.Image = Login_cine.Properties.Resources.vacio;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //boton eliminar
            if (MessageBox.Show("¿Esta seguro que desea eliminar este registro?", "El Sistema dice:",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string delete = sqlControl.eliminarPelicula(textBox1.Text);
                MessageBox.Show(delete);
                mostrarPelicula();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox1.Text = "Seleccione:";
                comboBox2.Text = "Seleccione:";
                comboBox3.Text = "Seleccione:";
                dateTimePicker1.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
                textBox2.Focus();
                picPelicula.Image = Login_cine.Properties.Resources.vacio;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //BOTON NUEVO
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "Seleccione:";
            comboBox2.Text = "Seleccione:";
            comboBox3.Text = "Seleccione:";
            dateTimePicker1.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
            textBox2.Focus();
            picPelicula.Image = Login_cine.Properties.Resources.vacio;

        }
    }
}
