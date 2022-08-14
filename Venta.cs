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
using System.Drawing.Printing;
using System.Globalization;

namespace Login_cine
{
    public partial class Venta : Form
    {
        SqlConnection cnn= new SqlConnection("Data Source =.; Initial Catalog = Cine; Integrated Security = True");

        /* public void  conexion()
         {
             try
             {
                // cnn = new SqlConnection("Data Source =.; Initial Catalog = Cine; Integrated Security = True");
                 // cnn.Open();
                 //MessageBox.Show("Conectado");

             }
             catch (Exception ex)
             {
                 MessageBox.Show("No se conecto a la base de datos: " + ex.ToString());
             }
         }*/

        SQLControl sqlControl = new SQLControl();
        public Venta()
        {
            InitializeComponent();
        }

        private void Venta_Load(object sender, EventArgs e)
        {
            button18.Visible = false;
            mostrarNumTicket();
           // label18.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;

        }


        //este metodo trae el select a una dataTable de un solo Row(0) y las columnas lo paso a los textbox
        public string nomCliente()
        {
            //METODO PARA TRAER EL CODIGO Y NOMBRE COMPLETO CLIENTE
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Select ClientID,Nombre+' '+Apellido as 'Nombre completo'  FROM Cliente where DNI='" + textBox9.Text + "'", cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                textBox10.Text = dt.Rows[0][0].ToString();
                textBox11.Text = dt.Rows[0][1].ToString();

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

        public string nomUser()
        {
            //METODO PARA TRAER EL NOMBRE COMPLETO USUARIO
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Select Nombre+' '+Apellido as 'Nombre completo'  FROM Usuario where ID='" + comboBox4.Text + "'", cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                textBox16.Text = dt.Rows[0][0].ToString();

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
                textBox20.Text = dt.Rows[0][0].ToString();

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
                textBox12.Text = dt.Rows[0][0].ToString();

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





        private void button9_Click(object sender, EventArgs e)
        {
            /* try
             {
                 textBox10.Text = nomCliente();

                 //textBox10.Text= dataGridView1.Rows[1].Cells[0].Value.ToString();
             }
             catch(Exception xx)
             {
                 MessageBox.Show(xx);
             }*/

            //este BOTON ES PARA EL CODIGO Y NOMBRE COMPLETO DEL CLIENTE
            nomCliente();


        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
           //este boton es para poner la fecha y hora actual
           label18.Text= DateTime.Today.Date.ToString("dd/MM/yyyy");
           label19.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string numero = textBox1.Text;
            string pelicula = comboBox1.Text;
            string fecha = dateTimePicker1.Text;
            string hora = textBox14.Text;
            string cant = textBox2.Text;
            string precio = textBox4.Text;
            string asiento = textBox15.Text;
            dataGridView1.Rows.Add(new object[]{
                numero,pelicula,fecha,hora,cant,precio,asiento,"Eliminar"
                 //numero,pelicula,hora,cant,precio,asiento,"Eliminar"

            });

            textBox1.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
            textBox14.Text = "";
            textBox2.Text="";
            textBox4.Text = "";
            textBox15.Text="";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            /*  BOTON REGISTRAR VENTA
             try
             {
                 List<Concepto> lst = new List<Concepto>();//llenado de elemtos detalle               
                 foreach(DataGridViewRow dr in dataGridView1.Rows)
                 {
                     Concepto oConcepto = new Concepto();
                    // oConcepto.num_ticket = dr.Cells[0].Value.ToString();
                     oConcepto.pelicula = dr.Cells[1].Value.ToString();
                     oConcepto.fecha = dr.Cells[2].Value.ToString();
                     oConcepto.hora = dr.Cells[3].Value.ToString();
                     oConcepto.cantidad = int.Parse(dr.Cells[4].Value.ToString());
                     oConcepto.precio = dr.Cells[5].Value.ToString();
                     oConcepto.fila_asiento = dr.Cells[6].Value.ToString();
                     lst.Add(oConcepto);
                 }
                  SQLControl sqlControl = new SQLControl();
                 sqlControl.Add(textBox1.Text,textBox12.Text,textBox13.Text,textBox10.Text,comboBox4.Text, lst);
                 MessageBox.Show("Venta registrada correctamente");
                }
             catch (Exception ec)
             {
                 MessageBox.Show(ec.Message);
             }*/

            if (label18.Text=="00/00/00" || label19.Text == "00:00:00")
            {
                MessageBox.Show("Ingresar Fecha y Hora", "El Sistema dice: ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else
            {
                if (textBox8.Text == "")
                {
                    MessageBox.Show("Ingresar Importe Total", "El Sistema dice: ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Venta registrada correctamente", "El Sistema dice: ");
                }                               
            }                    
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex <0 || e.ColumnIndex!= dataGridView1.Columns["Operacion"].Index)
            {
                return;
            }
            dataGridView1.Rows.RemoveAt(e.RowIndex);
        }

        
        private void button8_Click(object sender, EventArgs e)
        {
            //proceso de impresion
            printDocument1 = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrintPage += Imprimir;
            printDocument1.Print();
        }

        private void Imprimir(object sender, PrintPageEventArgs e)
        {

            if (textBox3.Text != "")
            {                         
            Font font = new Font("Arial", 14, FontStyle.Regular, GraphicsUnit.Point);
            int width = 600;
            int y = 20; 
            e.Graphics.DrawString("***************************************************************************", font, Brushes.Black,
                new RectangleF(37, y += 30, width, 20));
            e.Graphics.DrawString("                      R.U.C.: 20108730294",font,Brushes.Black,new RectangleF(37,y+=20,width,20));
            e.Graphics.DrawString("                        Ticket de Venta", font, Brushes.Black, new RectangleF(37, y += 20 ,width, 20));
            e.Graphics.DrawString("                           Nº : " +textBox1.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString("           ", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString("                       STAR CINES S.A.C." , font, Brushes.Black, new RectangleF(37, y += 20, width,20));
            e.Graphics.DrawString("             Av. Dos de Mayo 391, San Isidro", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString("Fecha de Emisión: " + label18.Text + "               Hora:" + label19.Text, 
                font, Brushes.Black, new RectangleF(37, y+=40, width,20));
            e.Graphics.DrawString("Serie: TC6F118052", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString("Cliente: "+textBox11.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 25));
            e.Graphics.DrawString("***************************************************************************", font, Brushes.Black, 
                new RectangleF(37, y += 30, width, 20));
            e.Graphics.DrawString("Película: " + comboBox1.Text,font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString("Función: " + dateTimePicker1.Text+"               HORA:"+textBox14.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString(comboBox2.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString("***************************************************************************", font, Brushes.Black,
                new RectangleF(37, y += 30, width, 20));
            e.Graphics.DrawString("                                                                 IMPORTE" , font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString(textBox2.Text + " BOLETO ADULTO  (s./" + textBox4.Text+")                   s./"+textBox6.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString("  ASIENTO FILA:  " + textBox15.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString(textBox3.Text + " BOLETO NIÑO    (s./" + textBox5.Text+")                      s./" + textBox7.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString("  ASIENTO FILA:  " + textBox19.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString("           ", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            
           // e.Graphics.DrawString("IGV:.......................... s/."+textBox17.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString("TOTAL:......................................................s/."+textBox8.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString("           ", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString("PAGO EFECTIVO:................. s/."+textBox18.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString("CAMBIO:............................... s/." + textBox17.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString("           ", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString("Atendido por: "+textBox16.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString("                 ", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString("***************************************************************************", font, Brushes.Black,
               new RectangleF(37, y += 30, width, 20));
            e.Graphics.DrawString("                 ¡GRACIAS POR SU PREFERENCIA!", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            e.Graphics.DrawString("                     WWW.STARCINES.COM.PE", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
            } else
            {
                //imprime solo el de BOLETO ADULTO
                Font font = new Font("Arial", 14, FontStyle.Regular, GraphicsUnit.Point);
                int width = 600;
                int y = 20;
                e.Graphics.DrawString("***************************************************************************", font, Brushes.Black,
                new RectangleF(37, y += 30, width, 20));
                e.Graphics.DrawString("                      R.U.C.: 20108730294", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString("                        Ticket de Venta", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString("                           Nº : " + textBox1.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString("           ", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString("                       STAR CINES S.A.C.", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString("             Av. Dos de Mayo 391, San Isidro", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString("Fecha de Emisión: " + label18.Text + "               Hora:" + label19.Text,
                   font, Brushes.Black, new RectangleF(37, y += 40, width, 20));
                e.Graphics.DrawString("Serie: TC6F118052", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString("Cliente: " + textBox11.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 25));
                e.Graphics.DrawString("***************************************************************************", font, Brushes.Black,
                    new RectangleF(37, y += 30, width, 20));
                e.Graphics.DrawString("Película: " + comboBox1.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString("Función: " + dateTimePicker1.Text + "               HORA:" + textBox14.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString(comboBox2.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString("***************************************************************************", font, Brushes.Black,
                    new RectangleF(37, y += 30, width, 20));
                e.Graphics.DrawString("                                                                 IMPORTE", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString(textBox2.Text + " BOLETO ADULTO  (s./" + textBox4.Text + ")                   s./" + textBox6.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString("  ASIENTO FILA:  " + textBox15.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString("TOTAL:......................................................s/." + textBox8.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString("           ", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString("PAGO EFECTIVO:................. s/." + textBox18.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString("CAMBIO:............................... s/." + textBox17.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString("           ", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString("Atendido por: " + textBox16.Text, font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString("                 ", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString("***************************************************************************", font, Brushes.Black,
                   new RectangleF(37, y += 30, width, 20));
                e.Graphics.DrawString("                 ¡GRACIAS POR SU PREFERENCIA!", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));
                e.Graphics.DrawString("                     WWW.STARCINES.COM.PE", font, Brushes.Black, new RectangleF(37, y += 20, width, 20));

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //BOTON PARA ELEGIR ASIENTO ADULTO
            Sala2 PanelSala2 = new Sala2();
            PanelSala2.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //BOTON PARA ELEGIR ASIENTO NIÑO
            Sala2 PanelSala2 = new Sala2();
            PanelSala2.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //BOTON PARA EL NOMBRE DEL VENDEDOR
            nomUser();

        }

        private void button16_Click(object sender, EventArgs e)
        {
            //BOTON PARA EL CODIGO PELICULA
            codPeli();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //BOTON PARA EL CODIGO SALA
            codSala();
            if(textBox20.Text=="P0046")
            {
                textBox14.Text = "20:00";
            }
            else
            {
                if (textBox20.Text == "P0047")
                  {
                textBox14.Text = "17:30";
                  } else
                     {
                     if (textBox20.Text == "P0048")
                     {
                        textBox14.Text = "19:00";
                     }else
                    {
                        textBox14.Text = "17:00";
                    }

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlControl.insertarVenta(textBox1.Text, textBox10.Text, comboBox4.Text);

            textBox4.Text = " 16.50";
            if (textBox3.Text != "")
                {
                textBox5.Text = " 11.50";
            }
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //SUMA PARA HALLAR EL SUBTOTAL
            /* if (textBox3.Text != "")
             {
                 textBox8.Text = (Convert.ToDouble(textBox6.Text) + Convert.ToDouble(textBox7.Text)).ToString();
             } else
             {
                 textBox8.Text = textBox6.Text;
             }*/

            try
            {
                if (textBox3.Text != "")
                {
                    decimal n1 = decimal.Parse(textBox6.Text);
                    decimal n2 = decimal.Parse(textBox7.Text);
                    decimal r2 = n1 + n2;
                    textBox8.Text = r2.ToString();
                    sqlControl.insertarDventa(textBox1.Text, textBox20.Text, dateTimePicker1.Text,
                    textBox14.Text, textBox3.Text, textBox5.Text, textBox19.Text);
                }
                else
                {
                    string n3 = textBox6.Text;

                    textBox8.Text = n3;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void button18_Click(object sender, EventArgs e)
        {
            //boton para hallar el subtotal (cant*precio)
            /* try
             {
                 decimal num1 = decimal.Parse(textBox2.Text);
                 decimal num2 = Convert.ToDecimal(textBox4.Text, CultureInfo.CreateSpecificCulture("en-US"));
                 decimal r = num1 * num2;
                 textBox6.Text = r.ToString();
                 sqlControl.insertarDventa(textBox1.Text, textBox20.Text, dateTimePicker1.Text,
              textBox14.Text, textBox2.Text, textBox4.Text, textBox15.Text);

                 if (textBox3.Text != "")
                 {
                     decimal a = decimal.Parse(textBox3.Text);
                     decimal b = Convert.ToDecimal(textBox5.Text, CultureInfo.CreateSpecificCulture("en-US"));
                     decimal r1 = a * b;
                     textBox7.Text = r1.ToString();
                 }
                  }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message.ToString());
             }*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //BOTON NUEVO
            label19.Text= "00/00/00";
            // label20.Text = "00:00:00";
            mostrarNumTicket();
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox16.Text = "";
            textBox20.Text = "";
            textBox12.Text = "";
            textBox14.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text="Seleccione:";
            comboBox2.Text ="Seleccione:";
            comboBox4.Text ="Seleccione:";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            dateTimePicker1.Text= DateTime.Today.Date.ToString("dd/MM/yyyy");
            textBox15.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox9.Focus();
        }

        private void textBox18_Leave(object sender, EventArgs e)
        {
            
            decimal x1= decimal.Parse(textBox8.Text);
            decimal x2 = decimal.Parse(textBox18.Text);
            decimal res = x2 - x1;
            textBox17.Text = res.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //BOTON REPORTES
            Reporte_Ventas report = new Reporte_Ventas();
            report.ShowDialog();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //registrar Detale Venta 1
            try
            {
                decimal num1 = decimal.Parse(textBox2.Text);
                decimal num2 = Convert.ToDecimal(textBox4.Text, CultureInfo.CreateSpecificCulture("en-US"));
                decimal r = num1 * num2;
                textBox6.Text = r.ToString();
                sqlControl.insertarDventa(textBox1.Text, textBox20.Text, dateTimePicker1.Text,
                 textBox14.Text, textBox2.Text, textBox4.Text, textBox15.Text);

            }                 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }  
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //registrar Detale Venta 2
            try
            {
                decimal a = decimal.Parse(textBox3.Text);
                decimal b = Convert.ToDecimal(textBox5.Text, CultureInfo.CreateSpecificCulture("en-US"));
                decimal r1 = a * b;
                textBox7.Text = r1.ToString();
                sqlControl.insertarDventa(textBox1.Text, textBox20.Text, dateTimePicker1.Text,
                textBox14.Text, textBox3.Text, textBox5.Text, textBox19.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }


        public void mostrarNumTicket()
        {
            //METODO PARA MOSTRAR EL CODIGO DEL TICKET 
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("select * from Ticket_Venta", cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                var resultado = dt.Rows.Count;
                if (resultado > 0)
                {
                    var num = resultado + 1;
                    textBox1.Text = "00" + num ;
                }
                else
                {
                    textBox1.Text = "00001";
                }
            }
            catch (Exception ec)

            {
                MessageBox.Show(ec.Message);
            }
            finally
            {
                cnn.Close();
            }                       
        }

    }
}
