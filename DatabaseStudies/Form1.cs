using System.Collections;
using System.Windows.Forms;

namespace DatabaseStudies
{
    public partial class Form1 : Form
    {
        ArrayList questions = new ArrayList();
        ArrayList answers = new ArrayList();
        bool isRandom = true;        
        Random rnd = new Random();
        int questionIndex = -1;

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
            String[] splitted = new string[3];
            textBox1.Text = null;
            var fileContent = string.Empty;
            var filePath = string.Empty;

            questions.Clear();
            answers.Clear();

            if (radioButton1.Checked)
                isRandom = true;
            else
            {
                isRandom = false;
                questionIndex = -1;
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = ".\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox3.Text = Path.GetFileName(openFileDialog.FileName);
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        while (!reader.EndOfStream)
                        {
                            splitted = reader.ReadLine().Split("|");
                            questions.Add(splitted[1]);
                            answers.Add(splitted[2]);
                        }
                    }
                }
            }
            button1_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
            textBox2.Text = Convert.ToString(answers[questionIndex]);
        }

        private void showRandomQuestion()
        {
            questionIndex = rnd.Next(0, questions.Count);
            textBox1.Text = Convert.ToString(questions[questionIndex]);
            textBox4.Text = Convert.ToString(questionIndex);
        }

        private void showLinearQuestion()
        {
            questionIndex++;
            if (questionIndex == questions.Count)
            {
                MessageBox.Show("restarting from the beggining");
                questionIndex = 0;
            }


            textBox1.Text = Convert.ToString(questions[questionIndex]);
            textBox4.Text= Convert.ToString(questionIndex+1);
            
        }
    }
}
