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
    public partial class Ventana2 : Form
    {
        public Ventana2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
           // Form1 VentanaLogin = new Form1();
           // VentanaLogin.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == true)
            {
                panel3.Visible = false;
            }
            else
            {
                panel3.Visible = true;
            }


            button2.Location = new Point(3, 83);
            panel3.Location = new Point(3, 148);
            button3.Location = new Point(3, 265);
            button4.Location = new Point(3, 332);
            button5.Location = new Point(3, 399);
            button6.Location = new Point(3, 466);
            

            if (panel3.Visible == false)
            {
                button2.Location = new Point(3, 83);
                button3.Location = new Point(3, 150);
                button4.Location = new Point(3, 217);
                button5.Location = new Point(3, 284);
                button6.Location = new Point(3, 351);
                
            }

        }

        private void Ventana2_Load(object sender, EventArgs e)
        {
            button2.Location = new Point(3, 83);
            button3.Location = new Point(3, 150);
            button4.Location = new Point(3, 217);
            button5.Location = new Point(3, 284);
            button6.Location = new Point(3, 351);
           
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
           //BOTÓN SALIR            
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //BOTON CERRAR SESIÓN
            this.Hide();
            Form1 VentanaLogin = new Form1();
            VentanaLogin.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panel4.Visible == true)
            {
                panel4.Visible = false;
            }
            else
            {
                panel4.Visible = true;
            }
            panel4.Location = new Point(3, 218);
            button2.Location = new Point(3, 83);
            button3.Location = new Point(3, 150);
            button4.Location = new Point(3, 475);
            button5.Location = new Point(3, 542);
            button6.Location = new Point(3, 609);
            



            if (panel4.Visible == false)
            {
                button2.Location = new Point(3, 83);
                button3.Location = new Point(3, 150);
                button4.Location = new Point(3, 217);
                button5.Location = new Point(3, 284);
                button6.Location = new Point(3, 351);
                
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (panel5.Visible == true)
            {
                panel5.Visible = false;
            }
            else
            {
                panel5.Visible = true;
            }
            panel5.Location = new Point(3, 284);
            button2.Location = new Point(3, 83);
            button3.Location = new Point(3, 150);
            button4.Location = new Point(3, 217);
            button5.Location = new Point(3, 351);
            button6.Location = new Point(3, 418);

            if (panel5.Visible == false)
            {
                button2.Location = new Point(3, 83);
                button3.Location = new Point(3, 150);
                button4.Location = new Point(3, 217);
                button5.Location = new Point(3, 284);
                button6.Location = new Point(3, 351);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Usuario PanelUsuario = new Usuario();
            PanelUsuario.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        { 
            //this.Hide();
            Clientes PanelCliente = new Clientes();
            PanelCliente.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Pelicula PanelPelicula = new Pelicula();
            PanelPelicula.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Cartelera PanelCartelera = new Cartelera();
            PanelCartelera.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Sala PanelSala = new Sala();
            PanelSala.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Venta PanelVenta = new Venta();
            PanelVenta.ShowDialog();
        }
    }
}
