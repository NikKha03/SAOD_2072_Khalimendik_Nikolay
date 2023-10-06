using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAOD_Stack
{
    public partial class Form1 : Form
    {
        private Stack<String> stack;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (stack == null)
            {
                try { stack = new Stack<String>(Int32.Parse(textBox2.Text)); }
                catch { stack = new Stack<String>(10); }
            }

            try
            {
                stack.push(textBox1.Text);
                label1.Text = "Элемент добавлен!";
                printListBox();
            }
            catch
            {
                label1.Text = "Стек переполнен!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                label2.Text = stack.pop().ToString();
                printListBox();
            }
            catch
            {
                label2.Text = "Стек пуст!";
            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                label3.Text = stack.top().ToString();
                printListBox();
            }
            catch
            {
                label3.Text = "Стек пуст!";
            };
        }

        private void printListBox()
        {

            listBox1.Items.Clear();

            for (int i = 0; i < stack.getCurrent(); i++)
            {
                String[] array = stack.toArray();
                listBox1.Items.Add(array[i]);
            }
        }
    }
}
