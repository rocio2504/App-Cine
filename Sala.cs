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
    public partial class Sala : Form
    {
        public Sala()
        {
            InitializeComponent();
        }

        private void Sala_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sala1 PanelSala1 = new Sala1();
            PanelSala1.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sala2 PanelSala2 = new Sala2();
            PanelSala2.ShowDialog();
        }
       
}
}
