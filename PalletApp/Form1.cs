using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;


namespace PalletApp
{
    public partial class PalletApp : Form
    {
        public PalletApp()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel3.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel4.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
        //Calculate

        private void pictureBox3_Click(object sender, EventArgs e)
        {           
            //                   Collective packages
            string length = textBox1.Text;
            string wide = textBox2.Text;
            string heigth = textBox3.Text;
            string weigth = textBox4.Text;

            //                   Cargo details
            string quantity = textBox5.Text;
            string maxHeigth = textBox7.Text;
            string maxWeigth = textBox8.Text;

            bool valid = true;

            if (string.IsNullOrEmpty(length) && string.IsNullOrEmpty(wide) && string.IsNullOrEmpty(heigth)
                && string.IsNullOrEmpty(weigth) && string.IsNullOrEmpty(quantity) && string.IsNullOrEmpty(maxHeigth) && string.IsNullOrEmpty(maxWeigth))
            {
                valid = false;
                MessageBox.Show("Fill in the data!");
            }
            else if (string.IsNullOrEmpty(length))
            {
                valid = false;
                MessageBox.Show("Fill in the length!");
            }

            else if (string.IsNullOrEmpty(wide))
            {
                valid = false;
                MessageBox.Show("Fill in the width!");
            }

            else if (string.IsNullOrEmpty(heigth))
            {
                valid = false;
                MessageBox.Show("Fill in the height!");
            }
            else if (string.IsNullOrEmpty(weigth))
            {
                valid = false;
                MessageBox.Show("Fill in the weight!");
            }

            else if (string.IsNullOrEmpty(quantity))
            {
                valid = false;
                MessageBox.Show("Fill in the quantity!");
            }

            else if (string.IsNullOrEmpty(maxHeigth))
            {
                valid = false;
                MessageBox.Show("Fill in the max height!");
            }

            else if (string.IsNullOrEmpty(maxWeigth))
            {
                valid = false;
                MessageBox.Show("Fill in the max weight!");
            }

            //Stacking
            //Total number of layers
            if (radioButtonTrue.Checked && valid)
            {
                calcStack();
            }
            else if (radioButtonFalse.Checked && valid)
            {
                calcNoStack();
            }
            else
            {
                MessageBox.Show("Check the stack option!");
            }

            void calcStack()
            {
                string result1 = getRes1(length, wide);
                string result2 = Convert.ToString(Math.Floor((Convert.ToDouble(maxHeigth) - 144) / Convert.ToDouble(heigth)));
                string result3 = getRes3(result1, result2);
                string result4 = getRes4(result2, heigth);
                string result5 = getRes5(result3, weigth);
                string result6 = getRes6(result4);
                string result7 = getRes7(quantity, result3);
                string result8 = getRes8(result6, result7);
                string result9 = getRes9(result5, result7);

                textResult1.Text = Convert.ToString(result3);
                textResult2.Text = Convert.ToString(result1);
                textResult3.Text = Convert.ToString(result2);
                textResult4.Text = Convert.ToString(result7);
                textResult5.Text = Convert.ToString(result4 + "mm");
                textResult6.Text = Convert.ToString(result6 + "m3");
                textResult7.Text = Convert.ToString(result8 + "m3");
                textResult8.Text = Convert.ToString(result5 + "kg");
                textResult9.Text = Convert.ToString(result9 + "kg");

                //                  Total cargo weight
                if (Convert.ToDouble(result9) > Convert.ToDouble(maxWeigth))
                {
                    MessageBox.Show("Total cargo weight is bigger than max weight!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                string getRes1(string length, string wide)
                {
                    double result1 = Math.Ceiling((1200 / Convert.ToDouble(length)) * (800 / Convert.ToDouble(wide)));
                    return Convert.ToString(result1);
                }

                string getRes3(string result1, string result2)
                {
                    double result3 = Math.Ceiling(Convert.ToDouble(result1) * Convert.ToDouble(result2));
                    return Convert.ToString(result3);
                }

                string getRes4(string result2, string heigth)
                {
                    double result4 = 144 + (Convert.ToDouble(result2) * Convert.ToDouble(heigth));
                    return Convert.ToString(result4);
                }

                string getRes5(string result3, string weigth)
                {
                    double result5 = Math.Round((Convert.ToDouble(result3) * Convert.ToDouble(weigth)), 2) + 25;
                    return Convert.ToString(result5);
                }

                string getRes6(string result4)
                {
                    double result6 = Math.Round(1.2 * 0.8 * (Convert.ToDouble(result4) / 1000), 2);
                    return Convert.ToString(result6);
                }

                string getRes7(string quantity, string result3)
                {
                    double result7 = Math.Ceiling(Convert.ToDouble(quantity) / Convert.ToDouble(result3));
                    return Convert.ToString(result7);
                }

                string getRes8(string result6, string result7)
                {
                    double result8 = Math.Round(Convert.ToDouble(result6) * Convert.ToDouble(result7), 2);
                    return Convert.ToString(result8);
                }

                string getRes9(string result5, string result7)
                {
                    double result9 = Math.Round(Convert.ToDouble(result5) * Convert.ToDouble(result7), 3);
                    return Convert.ToString(result9);
                }
            }

            void calcNoStack()
            {
                string result1 = getRes1(length, wide);
                string result2 = "1";
                string result3 = getRes3(result1, result2);
                string result4 = getRes4(result2, heigth);
                string result5 = getRes5(result3, weigth);
                string result6 = getRes6(result4);
                string result7 = getRes7(quantity, result3);
                string result8 = getRes8(result6, result7);
                string result9 = getRes9(result5, result7);

                textResult1.Text = Convert.ToString(result3);
                textResult2.Text = Convert.ToString(result1);
                textResult3.Text = Convert.ToString(result2);
                textResult4.Text = Convert.ToString(result7);
                textResult5.Text = Convert.ToString(result4 + "mm");
                textResult6.Text = Convert.ToString(result6 + "m3");
                textResult7.Text = Convert.ToString(result8 + "m3");
                textResult8.Text = Convert.ToString(result5 + "kg");
                textResult9.Text = Convert.ToString(result9 + "kg");

                //                  Total cargo weight
                if (Convert.ToDouble(result9) > Convert.ToDouble(maxWeigth))
                {
                    MessageBox.Show("Total cargo weight is bigger than max weight!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                string getRes1(string length, string wide)
                {
                    double result1 = Math.Ceiling((1200 / Convert.ToDouble(length)) * (800 / Convert.ToDouble(wide)));
                    return Convert.ToString(result1);
                }

                string getRes3(string result1, string result2)
                {
                    double result3 = Math.Ceiling(Convert.ToDouble(result1) * Convert.ToDouble(result2));
                    return Convert.ToString(result3);
                }

                string getRes4(string result2, string heigth)
                {
                    double result4 = 144 + (Convert.ToDouble(result2) * Convert.ToDouble(heigth));
                    return Convert.ToString(result4);
                }

                string getRes5(string result3, string weigth)
                {
                    double result5 = Math.Round((Convert.ToDouble(result3) * Convert.ToDouble(weigth)), 2) + 25;
                    return Convert.ToString(result5);
                }

                string getRes6(string result4)
                {
                    double result6 = Math.Round(1.2 * 0.8 * (Convert.ToDouble(result4) / 1000), 2);
                    return Convert.ToString(result6);
                }

                string getRes7(string quantity, string result3)
                {
                    double result7 = Math.Ceiling(Convert.ToDouble(quantity) / Convert.ToDouble(result3));
                    return Convert.ToString(result7);
                }

                string getRes8(string result6, string result7)
                {
                    double result8 = Math.Round(Convert.ToDouble(result6) * Convert.ToDouble(result7), 2);
                    return Convert.ToString(result8);
                }

                string getRes9(string result5, string result7)
                {
                    double result9 = Math.Round(Convert.ToDouble(result5) * Convert.ToDouble(result7), 3);
                    return Convert.ToString(result9);
                }
            }
        }

        //Textbox accepts only numbers                            
        //Lenth
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
        //Width
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
        //Height
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
        //Weight
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
        //Quantity
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //Stacking
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
        //Max height
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
        //Max weight 
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Do you really want to close Pallet App?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }   

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textResult1.Text = "Result";
            textResult2.Text = "Result";
            textResult3.Text = "Result";
            textResult4.Text = "Result";
            textResult5.Text = "Result";
            textResult6.Text = "Result";
            textResult7.Text = "Result";
            textResult8.Text = "Result";
            textResult9.Text = "Result";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form2 info = new Form2();
            info.ShowDialog();
        }

        private void textResult1_TextChanged(object sender, EventArgs e)
        {
            textResult1.Enabled = false;
        }
    }
}
