using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPZ
{
    public partial class Form1 : Form
    {
        MyOPZ OPZ = new MyOPZ();
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            label3.Visible = false;
            label4.Visible = false;
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                label3.Visible = true;
                label3.Text = "";
                string first_string = textBox1.Text;
                label3.Text = OPZ.ToOPZ(first_string);
                button2.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            label4.Text = "";
            string str_res = label3.Text;
            label4.Text = Convert.ToString(OPZ.ToCalc(str_res));
        }
    }
    
}