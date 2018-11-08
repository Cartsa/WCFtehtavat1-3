using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCFServiceReference
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            laskuPalvelu.Service1Client client = new laskuPalvelu.Service1Client();
            string returnstring;
            returnstring = client.GetData(textBox1.Text);
            label1.Text = returnstring;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            laskuPalvelu.Service1Client client = new laskuPalvelu.Service1Client();
            int returnint;
            returnint = client.Plussaa(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
            label2.Text = Convert.ToString(returnint);
        }
    }
}
