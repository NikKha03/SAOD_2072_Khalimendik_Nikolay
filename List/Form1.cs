using List;
using System;
using System.Reflection;
using System.Windows.Forms;


namespace List {
    public partial class Form1 : Form {

        private ListPrototype<int> list;

        public Form1() {
            InitializeComponent();
            list = new ListPrototype<int>();
        }
        private void button1_Click(object sender, EventArgs e) {
            try {
                list.prepend(Int32.Parse(textBox1.Text));
                label1.Text = "Success";
                printListBox();
            } catch {
                label1.Text = "Error";
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            try {
                list.append(Int32.Parse(textBox2.Text));
                label2.Text = "Success";
                printListBox();
            } catch {
                label2.Text = "Error";
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            try {
                list.insert(Int32.Parse(textBox3.Text), Int32.Parse(textBox8.Text));
                label3.Text = "Success";
            } catch {
                label3.Text = "Error";
            }

            printListBox();
        }

        private void button4_Click(object sender, EventArgs e) {
            try {
                int index = list.find(Int32.Parse(textBox4.Text));
                if(index == -1)
                    label4.Text = "Not found";
                else
                    label4.Text = "Success, index = " + index.ToString();
            } catch {
                label4.Text = "Error";
            }
            printListBox();
        }

        private void button5_Click(object sender, EventArgs e) {
            try {
                int value = list.findAt(Int32.Parse(textBox5.Text));
                label5.Text = "Success, value = " + value.ToString();
            } catch {
                label5.Text = "Error";
            }
            printListBox();
        }

        private void button6_Click(object sender, EventArgs e) {
            try {
                if(list.remove(Int32.Parse(textBox6.Text)))
                    label6.Text = "Success";
                else
                    label6.Text = "Can't remove";
            } catch {
                label6.Text = "Error";
            }
            printListBox();

        }

        private void button7_Click(object sender, EventArgs e) {
            try {
                if(list.removeAt(Int32.Parse(textBox7.Text)))
                    label7.Text = "Success";
                else
                    label7.Text = "Can't remove";
            } catch {
                label7.Text = "Error";
            }
            printListBox();
        }

        private void printListBox() {
            listBox1.Items.Clear();
            if(list.getCount() != 0) {
                foreach(var value in list) {
                    listBox1.Items.Add(value);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
