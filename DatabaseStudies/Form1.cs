using System.Collections;

namespace DatabaseStudies
{
    public partial class Form1 : Form
    {
        ArrayList questions = new ArrayList();
        ArrayList answers = new ArrayList();
        bool isRandom = true;        
        Random rnd = new Random();
        int getRandom = -1;

        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;

            if (isRandom) {
                showRandomQuestion();
                return;
            }
            showLinearQuestion();

        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                isRandom = true;
            else {
                isRandom = false;
                getRandom = -1;
            }
                

            String[] splitted = new string[3];
            textBox1.Text = null;

            FileStream inFile = new FileStream("answers.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);

            while (!reader.EndOfStream)
            {
                splitted = reader.ReadLine().Split("|");
                questions.Add(splitted[1]);
                answers.Add(splitted[2]);
            }

            reader.Close();
            inFile.Close();
            button1_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
            textBox2.Text = (String)answers[getRandom];
        }

        private void showRandomQuestion()
        {
            getRandom = rnd.Next(0, questions.Count);
            textBox1.Text = (String)questions[getRandom];
        }

        private void showLinearQuestion()
        {
            getRandom++;
            if (getRandom == questions.Count)
            {
                MessageBox.Show("restarting from the beggining");
                getRandom = 0;
            }


            textBox1.Text = (String)questions[getRandom];
            

            
        }
    }
}
