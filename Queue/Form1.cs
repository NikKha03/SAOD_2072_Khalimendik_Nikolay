namespace Queue {
    public partial class Form1 : Form {

        QueuePrototype<int> queue;

        public Form1() {
            InitializeComponent();
            queue = new QueuePrototype<int>();
        }

        private void button1_Click(object sender, EventArgs e) {
            String valueString = textBox1.Text;
            if(valueString == "") {
                label1.Text = "Fill the cell";
                return;
            }

            try {
                queue.enqueue(Int32.Parse(valueString));
                label1.Text = "Success";
                drowQueue();
            } catch (QueueOverflowException ex) {
                label1.Text = ex.Message;
            }
        }
        private void button2_Click(object sender, EventArgs e) {
            try {
                int elem = queue.dequeue();
                label2.Text = elem.ToString();
                drowQueue();
            } catch(QueueEmptyException ex) {
                label2.Text = ex.Message;
            }
        }
        private void button3_Click(object sender, EventArgs e) {
            try {
                label3.Text = queue.peek().ToString();
                drowQueue();
            } catch (QueueEmptyException ex) {
                label3.Text = ex.Message;
            }
        }
        private void button4_Click(object sender, EventArgs e) {
                label4.Text = queue.isEmpty().ToString();
                drowQueue();
        }

        private void textBox5_TextChanged(object sender, EventArgs e) {
            String capacityString = textBox5.Text;
            if(capacityString != "") {
                queue = new QueuePrototype<int>(Int32.Parse(capacityString));
                drowQueue();
            }
        }

        private void drowQueue() {
            listBox1.Items.Clear();
            int[] outputArray = queue.toArray();
            for(int i = 0; i < queue.getCount(); i++) {
                listBox1.Items.Add(outputArray[i]);
            }
        }

    }
}