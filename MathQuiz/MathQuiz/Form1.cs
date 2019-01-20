using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();

        // Math problem numbers
        int addend1;
        int addend2;

        int subend1;
        int subend2;

        int multend1;
        int multend2;

        int divend1;
        int divend2;

        // sums
        int addSum;
        int subSum;
        int multSum;
        int divSum;

        // Other components for quiz
        int timeLeft;

        // Validation of answers
        bool isAddCorrect = false;
        bool isSubCorrect = false;
        bool isMultCorrect = false;
        bool isDivCorrect = false;

        public Form1()
        {
            InitializeComponent();

            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        public void StartQuiz()
        {
            // Reset the answers
            timeLabel.BackColor = Color.White;

            sum1.Value = 0;
            sum2.Value = 0;
            sum3.Value = 0;
            sum4.Value = 0;

            sum1.BackColor = Color.White;
            sum2.BackColor = Color.White;
            sum3.BackColor = Color.White;
            sum4.BackColor = Color.White;

            sum1.ForeColor = Color.Black;
            sum2.ForeColor = Color.Black;
            sum3.ForeColor = Color.Black;
            sum4.ForeColor = Color.Black;

            // Set Addition
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel1.Text = addend1.ToString();
            plusRightLabel1.Text = addend2.ToString();

            // Set Subtraction
            subend1 = randomizer.Next(51);
            subend2 = randomizer.Next(51);
            if (subend1 == subend2)
            {
                subend2 -= randomizer.Next(6);
            }

            plusLeftLabel2.Text = subend1.ToString();
            plusRightLabel2.Text = subend2.ToString();

            // Set Multiplication
            multend1 = randomizer.Next(1, 11);
            multend2 = randomizer.Next(1, 11);

            plusLeftLabel3.Text = multend1.ToString();
            plusRightLabel3.Text = multend2.ToString();

            // Set Division
            divend1 = randomizer.Next(11, 51);
            divend2 = randomizer.Next(1, 11);

            plusLeftLabel4.Text = divend1.ToString();
            plusRightLabel4.Text = divend2.ToString();

            // Time Stuffz
            timeLeft = 30;
            timeLabel.Text = "30 Seconds";
            timer1.Start();

        }

        /*********************         EVENTS           ***********************/

        private void button1_Click(object sender, EventArgs e)
        {
            StartQuiz();
            startButton.Enabled = false;

            isAddCorrect = false;
            isSubCorrect = false;
            isMultCorrect = false;
            isDivCorrect = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " Seconds";

                if (isAddCorrect && isSubCorrect && isMultCorrect && isDivCorrect)
                {
                    timer1.Stop();

                    MessageBox.Show("Congratulations! You passed the quiz!", "Yay for you!");
                    startButton.Enabled = true;
                }

                if (timeLeft <= 5)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's Up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                // Show Answers
                sum1.Value = addend1 + addend2;
                sum2.Value = subend1 - subend2;
                sum3.Value = multend1 * multend2;
                sum4.Value = divend1 / divend2;

                startButton.Enabled = true;
            }
        }

        private void sum1_ValueChanged(object sender, EventArgs e)
        { 
            addSum = addend1 + addend2;
            if (sum1.Value == addSum)
            {
                sum1.BackColor = Color.Green;
                sum1.ForeColor = Color.White;
                isAddCorrect = true;
            }
        }

        private void sum2_ValueChanged(object sender, EventArgs e)
        {
            subSum = subend1 - subend2;
            if (sum2.Value == subSum)
            {
                sum2.BackColor = Color.Green;
                sum2.ForeColor = Color.White;
                isSubCorrect = true;
            }
        }

        private void sum3_ValueChanged(object sender, EventArgs e)
        {
            multSum = multend1 * multend2;
            if (sum3.Value == multSum)
            {
                sum3.BackColor = Color.Green;
                sum3.ForeColor = Color.White;
                isMultCorrect = true;
            }

        }

        private void sum4_ValueChanged(object sender, EventArgs e)
        {
            divSum = divend1 / divend2;
            if (sum4.Value == divSum)
            {
                sum4.BackColor = Color.Green;
                sum4.ForeColor = Color.White;
                isDivCorrect = true;
            }
        }
        
    }
}
