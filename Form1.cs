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
    public partial class Form1 : Form
    {
        SQLControl sqlControl = new SQLControl();
        public Form1()
        {
            InitializeComponent();
        }

       

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Properties.Resources.descarga;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.descarga;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.cerrar_borrar_boton_eliminar_318_9073;
        }

        private void OcultarMensaje()
        {
            panel1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OcultarMensaje();

           // SQLControl c = new SQLControl();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        //private void button3_Click(object sender, EventArgs e)
        //{
          
             
                
             

        //}

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           //MOSTRAR-OCULTAR CONTRASEÑA
            if(checkBox1.Checked==true)
            {
                if (textBox2.PasswordChar == '*')
                {
                    textBox2.PasswordChar = '\0';
                }
            }else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.Size = new Size(173, 57);
            button1.BackgroundImage = Properties.Resources.login_hover;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Size = new Size(170, 55);
            button1.BackgroundImage = Properties.Resources.boton_login2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //BOTÓN LOGIN
           int result = sqlControl.Login(textBox1.Text,textBox2.Text);
            if (result == 1)
            {
                this.Hide(); 
                Ventana2 NuevaVentana = new Ventana2();
                NuevaVentana.ShowDialog();
            }else if (result == 0)
            {
                MessageBox.Show("Error en el Usuario y/o contraseña... Intente denuevo!.....",
                   "El sistema dice:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }

        }
    }
}
