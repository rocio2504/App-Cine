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
    
   
    public partial class AgregarUsuario : Form
    {

        SQLControl sqlControl = new SQLControl();
        Usuario user = new Usuario();

        //DataTable  ta= new DataTable();
        
        public AgregarUsuario()
        {
            
            InitializeComponent();
            this.ttmensaje11.SetToolTip(this.button2, "GUARDAR");
            this.ttmensaje11.SetToolTip(this.button3, "NUEVO");

        }

         private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgregarUsuario_Load(object sender, EventArgs e)
        {

            //cnn.open();
            // mostrarUsuario1();

           // borrarMensajeError();
        }



       public void mostrarUsuario1()
        {
            DataTable tabla = new DataTable();
            tabla = sqlControl.mostrarUsuarios();
            dataGridView1.DataSource = tabla;
        }


        //este metodo textBox3_Validating es para validar q el dni sea un numero, pero no funciona
        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            int num;
            if (!int.TryParse(textBox3.Text, out num))
            {
                erMessage.SetError(textBox3, "Ingrese un valor en número");
            }
            else
            {
                erMessage.SetError(textBox3, "");

            }
        }


        //este metodo es para validar q los campos se envien vacios, usando errorProvider
        private bool verificarCampos()
        {
            bool ok = true;
            if (textBox1.Text == "")
            {
                ok = false;
                erMessage.SetError(textBox1, "Ingresar Nombre");
            }
            if (textBox2.Text == "")
            {
                ok = false;
                erMessage.SetError(textBox2, "Ingresar Apellido");
            }
            if (textBox3.Text == "")
            {
                ok = false;
                erMessage.SetError(textBox3, "Ingresar DNI");
            }

            if (textBox4.Text == "")
            {
                ok = false;
                erMessage.SetError(textBox4, "Ingresar Email");
            }

            if (textBox10.Text == "")
            {
                ok = false;
                erMessage.SetError(textBox10, "Ingresar Teléfono");
            }

            if (textBox6.Text == "")
            {
                ok = false;
                erMessage.SetError(textBox6, "Ingresar Dirección");
            }

            if (textBox7.Text == "")
            {
                ok = false;
                erMessage.SetError(textBox7, "Ingresar Usuario");
            }

            if (textBox8.Text == "")
            {
                ok = false;
                erMessage.SetError(textBox8, "Ingresar Contraseña");
            }

            if (textBox9.Text == "")
            {
                ok = false;
                erMessage.SetError(textBox9, "Ingresar Estado");
            }
            return ok;
                     
        }


        //el metodo borrar mensaje es para setear el erMenssage (errorProvider)
        private void borrarMensajeError()
        {
            erMessage.SetError(textBox1, "");
            erMessage.SetError(textBox2, "");
            erMessage.SetError(textBox3, "");
            erMessage.SetError(textBox4, "");
            erMessage.SetError(textBox10, "");
            erMessage.SetError(textBox6, "");
            erMessage.SetError(textBox7, "");
            erMessage.SetError(textBox8, "");
            erMessage.SetError(textBox9, "");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //BOTON GUARDAR USUARIO
            borrarMensajeError();

            if(verificarCampos())
            {
              
            string r = sqlControl.grabarUsuario(textBox1.Text, textBox2.Text, comboBox1.Text, textBox3.Text,
             textBox4.Text, textBox10.Text, dateTimePicker1.Text, textBox6.Text, textBox7.Text, textBox8.Text,
             dateTimePicker2.Text, textBox9.Text, comboBox2.Text);
              MessageBox.Show(r);
            }

           /* textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox10.Text = "";
            dateTimePicker1.Text= DateTime.Today.Date.ToString("dd/MM/yyyy");
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            dateTimePicker2.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
            textBox9.Text = "";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            textBox1.Focus();
           */
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //boton nuevo
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox10.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            dateTimePicker1.Text= DateTime.Today.Date.ToString("dd/MM/yyyy");
            dateTimePicker2.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
            comboBox1.Text = "Seleccione:";
            comboBox2.Text = "Seleccione:" ;
            textBox1.Focus();
        }

        //este metodo textBox10_Validating es para validar q el TELEFONO sea un numero, pero no funciona
        private void textBox10_Validating(object sender, CancelEventArgs e)
        {
            int num;
            if (!int.TryParse(textBox10.Text, out num))
            {
                erMessage.SetError(textBox10, "Ingrese un valor en número");
            }
            else
            {
                erMessage.SetError(textBox10, "");

            }

          }
    }
}
