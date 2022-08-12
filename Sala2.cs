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
    public partial class Sala2 : Form
    {

        SqlConnection cnn = new SqlConnection("Data Source =.; Initial Catalog = Cine; Integrated Security = True");

        SQLControl sqlControl = new SQLControl();
        public Sala2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //asiento A1
            if (button2.BackColor == Color.Gray)
            {
                button2.BackColor = Color.Red;

            }
            else
            {
                button2.BackColor = Color.Gray;
            }


        }

        public void buscarAsiento()
        {
            //asiento B4
            int a=376;
            DataTable tabla = new DataTable();
            tabla = sqlControl.buscarAsiento(a);
            string estado =tabla.Rows[0][0].ToString();
            if(estado=="Ocupado")
            {
                button19.BackColor = Color.Red;
            }else
            {
                button19.BackColor = Color.Gray;
            }
         }

        public void buscarAsientoo()
        {
            //asiento C7
            int a = 354;
            DataTable tabla = new DataTable();
            tabla = sqlControl.buscarAsiento(a);
            string estado = tabla.Rows[0][0].ToString();
            if (estado == "Ocupado")
            {
                button46.BackColor = Color.Red;
            }
            else
            {
                button46.BackColor = Color.Gray;
            }
        }

        public void buscarAsient()
        {
            //asiento C8
            int a = 354;
            DataTable tabla = new DataTable();
            tabla = sqlControl.buscarAsiento(a);
            string estado = tabla.Rows[0][0].ToString();
            if (estado == "Ocupado")
            {
                button45.BackColor = Color.Red;
            }
            else
            {
                button45.BackColor = Color.Gray;
            }
        }

        public void buscarAsientedos()
        {
            //asiento E2
            int a = 365;
            DataTable tabla = new DataTable();
            tabla = sqlControl.buscarAsiento(a);
            string estado = tabla.Rows[0][0].ToString();
            if (estado == "Ocupado")
            {
                button13.BackColor = Color.Red;
            }
            else
            {
                button13.BackColor = Color.Gray;
            }
        }

        public void buscarAsientetres()
        {
            //asiento E3
            int a = 372;
            DataTable tabla = new DataTable();
            tabla = sqlControl.buscarAsiento(a);
            string estado = tabla.Rows[0][0].ToString();
            if (estado == "Ocupado")
            {
                button27.BackColor = Color.Red;
            }
            else
            {
                button27.BackColor = Color.Gray;
            }
        }

        public void buscarAsientEcuatro()
        {
            //asiento E4
            int a = 379;
            DataTable tabla = new DataTable();
            tabla = sqlControl.buscarAsiento(a);
            string estado = tabla.Rows[0][0].ToString();
            if (estado == "Ocupado")
            {
                button22.BackColor = Color.Red;
            }
            else
            {
                button22.BackColor = Color.Gray;
            }
        }

        public void buscarAsientfcinco()
        {
            //asiento F5
            int a = 387;
            DataTable tabla = new DataTable();
            tabla = sqlControl.buscarAsiento(a);
            string estado = tabla.Rows[0][0].ToString();
            if (estado == "Ocupado")
            {
                button35.BackColor = Color.Red;
            }
            else
            {
                button35.BackColor = Color.Gray;
            }
        }

        public void buscarAsientfseis()
        {
            //asiento F6
            int a = 394;
            DataTable tabla = new DataTable();
            tabla = sqlControl.buscarAsiento(a);
            string estado = tabla.Rows[0][0].ToString();
            if (estado == "Ocupado")
            {
                button50.BackColor = Color.Red;
            }
            else
            {
                button50.BackColor = Color.Gray;
            }
        }


        private void Sala2_Load(object sender, EventArgs e)
        {
            buscarAsiento(); //asiento B4
            buscarAsientoo(); //asiento C7
            buscarAsient();  //asiento C8
            buscarAsientedos(); //asiento E2 ejemplo
            buscarAsientetres();//asiento E3 ejemplo
            buscarAsientEcuatro();//asiento E4 ejemplo
            buscarAsientfcinco(); //asiento F5 ejemplo
            buscarAsientfseis(); //asiento F6 ejemplo
        }

        private void button68_Click(object sender, EventArgs e)
        {
            //boton D10
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //asiento E2
            if (button13.BackColor == Color.Gray)
            {
                button13.BackColor = Color.Red;
                sqlControl.seleccionarAsiento(365);
            }
            else
            {
                button13.BackColor = Color.Gray;
                sqlControl.quitarAsiento(365);
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            //asiento E3
            if (button27.BackColor == Color.Gray)
            {
                button27.BackColor = Color.Red;
                sqlControl.seleccionarAsiento(372);
            }
            else
            {
                button27.BackColor = Color.Gray;
                sqlControl.quitarAsiento(372);
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            //asiento F5
            if (button35.BackColor == Color.Gray)
            {
                button35.BackColor = Color.Red;
                sqlControl.seleccionarAsiento(387);

            }
            else
            {
                button35.BackColor = Color.Gray;
                sqlControl.quitarAsiento(387);
            }
        }

        private void button50_Click(object sender, EventArgs e)
        {
            //asiento F6
            if (button50.BackColor == Color.Gray)
            {
                button50.BackColor = Color.Red;
                sqlControl.seleccionarAsiento(394);

            }
            else
            {
                button50.BackColor = Color.Gray;
                sqlControl.quitarAsiento(394);
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            //asiento B5
            if (button30.BackColor == Color.Gray)
            {
                button30.BackColor = Color.Red;

            }
            else
            {
                button30.BackColor = Color.Gray;
            }
        }

        private void button72_Click(object sender, EventArgs e)
        {

        }

        private void button40_Click(object sender, EventArgs e)
        {
            //asiento D6
            if (button40.BackColor == Color.Gray)
            {
                button40.BackColor = Color.Red;

            }
            else
            {
                button40.BackColor = Color.Gray;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //boton E4
            if (button22.BackColor == Color.Gray)
            {
                button22.BackColor = Color.Red;
                sqlControl.seleccionarAsiento(379);

            }
            else
            {
                button22.BackColor = Color.Gray;
                sqlControl.quitarAsiento(379);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //asiento F1
            if (button7.BackColor == Color.Gray)
            {
                button7.BackColor = Color.Red;          
            }
            else
            {
               button7.BackColor = Color.Gray;
           
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //asiento F2
            if (button14.BackColor == Color.Gray)
            {
                button14.BackColor = Color.Red;
            }
            else
            {
                button14.BackColor = Color.Gray;

            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //B4
            if (button19.BackColor == Color.Gray)
            {
                button19.BackColor = Color.Red;
            }
            else
            {
                button19.BackColor = Color.Gray;

            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //asiento A2
            if (button9.BackColor == Color.Gray)
            {
                button9.BackColor = Color.Red;
            }
            else
            {
                button9.BackColor = Color.Gray;

            }
        }
    }
}
