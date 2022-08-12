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
    public partial class Sala1 : Form
    {

        int fila = 7;
        int columna = 10;
        int anchowidth = 60;
       // int anchowidth = 35;
        int altoheight = 35;
        int ejeX = 20;
        int ejeY = 20;


        public Button[,] botones = new Button[7,10];




        public Sala1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
        }


        public void matrizbotones()
        {
           // int contador= 1;          
            Button[,] botones = new Button[7, 10];
            //Font btn = New Font("Arial", 14, FontStyle.Bold);
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    botones[i, j] = new Button();
                    botones[i, j].SetBounds(ejeX, ejeY, anchowidth, altoheight);
                    botones[i, j].BackColor = Color.Gray;
                   
                   // botones[i, j].Text = (""+contador);
                   // AccionBotones accion = new AccionBotones();
                  //  accion.Handler+= (botones[i, j]);
                    panel1.Controls.Add(botones[i, j]);


                    //contador = contador+1;
                    ejeX += 70;


                }
                ejeX = 20;
                ejeY += 50;
            }


        }


        /* public class AccionBotones implements ActionListener
         {

         }*/
      public delegate void EventHandler(object sender, EventArgs e);

        public class AccionBotones{
            Button[,] botones = new Button[7, 10];
            public event EventHandler Handler
            {

              
                add
                {
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {

                            botones[i, j].BackColor = Color.Red;
                        }

                    }

                }
                remove
                {
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {

                            botones[i, j].BackColor = Color.Gray;
                        }

                    }
                }
            }

        }


    private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void button14_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void Sala1_Load(object sender, EventArgs e)
        {
            matrizbotones();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
