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
    public partial class Cartelera : Form
    {
        SQLControl sqlControl = new SQLControl();

        SqlConnection cnn = new SqlConnection("Data Source =.; Initial Catalog = Cine; Integrated Security = True");
        public Cartelera()
        {
            InitializeComponent();
            this.ttmensaje.SetToolTip(this.button3, "AGREGAR");
            this.ttmensaje.SetToolTip(this.button4, "MODIFICAR");
            this.ttmensaje.SetToolTip(this.button5, "ELIMINAR");
            this.ttmensaje.SetToolTip(this.button6, "REPORTES");
            this.ttmensaje.SetToolTip(this.button9, "BUSCAR");
            this.ttmensaje.SetToolTip(this.button10, "NUEVO");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.Equals("Mientras estes conmigo"))
            {

                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;



            }
            else
            {
                if (comboBox1.SelectedItem.Equals("Los Nuevos Mutantes"))
                {
                    pictureBox2.Visible = true;
                    pictureBox1.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                    pictureBox5.Visible = false;
                    pictureBox6.Visible = false;
                    pictureBox7.Visible = false;




                }
                else
                {

                    if (comboBox1.SelectedItem.Equals("Mulan"))
                    {
                        pictureBox3.Visible = true;
                        pictureBox1.Visible = false;
                        pictureBox2.Visible = false;
                        pictureBox4.Visible = false;
                        pictureBox5.Visible = false;
                        pictureBox6.Visible = false;
                        pictureBox7.Visible = false;



                    }
                    else
                    {

                        if (comboBox1.SelectedItem.Equals("Wonder Woman 1984"))
                        {
                            pictureBox4.Visible = true;
                            pictureBox1.Visible = false;
                            pictureBox2.Visible = false;
                            pictureBox3.Visible = false;
                            pictureBox5.Visible = false;
                            pictureBox6.Visible = false;
                            pictureBox7.Visible = false;



                        }
                        else
                        {

                            if (comboBox1.SelectedItem.Equals("Soul"))
                            {
                                pictureBox5.Visible = true;
                                pictureBox1.Visible = false;
                                pictureBox2.Visible = false;
                                pictureBox3.Visible = false;
                                pictureBox4.Visible = false;
                                pictureBox6.Visible = false;
                                pictureBox7.Visible = false;



                            }
                            else
                            {

                                if (comboBox1.SelectedItem.Equals("Monster Hunter"))
                                {
                                    pictureBox6.Visible = true;
                                    pictureBox1.Visible = false;
                                    pictureBox2.Visible = false;
                                    pictureBox3.Visible = false;
                                    pictureBox4.Visible = false;
                                    pictureBox5.Visible = false;
                                    pictureBox7.Visible = false;



                                }
                                else
                                {

                                   if (comboBox1.SelectedItem.Equals("Minions: Nace un Villano"))
                                        {
                                            pictureBox7.Visible = true;
                                            pictureBox1.Visible = false;
                                            pictureBox2.Visible = false;
                                            pictureBox3.Visible = false;
                                            pictureBox4.Visible = false;
                                            pictureBox5.Visible = false;
                                            pictureBox6.Visible = false;



                                        }

                                    }

                                }

                            }

                        }

                }

            }

        }

        public string codPeli()
        {
            //METODO PARA TRAER EL CODIGO PELICULA
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("select PeliculaID from Pelicula where Titulo ='" + comboBox1.Text + "'", cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                textBox5.Text = dt.Rows[0][0].ToString();

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

        public string codSala()
        {
            //METODO PARA TRAER EL CODIGO DE SALA
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("select SalaID from Sala where Nombre_sala='" + comboBox2.Text + "'", cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                textBox3.Text = dt.Rows[0][0].ToString();

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

        public void verCartelera()
        {
            DataTable tabla = new DataTable();
            tabla = sqlControl.mostrarCartelera();
            dataGridView1.DataSource = tabla;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cartelera_Load(object sender, EventArgs e)
        {
            verCartelera();
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //BOTON PARA AGREGAR CARTELERA
            try
            {
                string cartelera = sqlControl.IngresarCartelera(textBox5.Text, textBox3.Text,
                    dateTimePicker1.Text, textBox1.Text, textBox2.Text);
                MessageBox.Show(cartelera);
                verCartelera();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //para obtener el codigo de la pelicula
            codPeli();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //codigo de sala
            codSala();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //BOTON NUEVO
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "Seleccione:";
            dateTimePicker1.Text= DateTime.Today.Date.ToString("dd/MM/yyyy");
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;

        }
    }
}
