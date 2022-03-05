using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PalletApp
{
    public partial class PalletApp : Form
    {
        public PalletApp()
        {
            InitializeComponent();
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
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
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

        //                              Button
        //Calculate
        private void buttonOblicz_Click(object sender, EventArgs e)
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
            else
            {
                if (string.IsNullOrEmpty(length))
                {
                    valid = false;
                    MessageBox.Show("Fill in the length!");
                }

                if (string.IsNullOrEmpty(wide))
                {
                    valid = false;
                    MessageBox.Show("Fill in the width!");
                }

                if (string.IsNullOrEmpty(heigth))
                {
                    valid = false;
                    MessageBox.Show("Fill in the height!");
                }

                if (string.IsNullOrEmpty(weigth))
                {
                    valid = false;
                    MessageBox.Show("Fill in the weight!");
                }

                if (string.IsNullOrEmpty(quantity))
                {
                    valid = false;
                    MessageBox.Show("Fill in the quantity!");
                }

                if (string.IsNullOrEmpty(maxHeigth))
                {
                    valid = false;
                    MessageBox.Show("Fill in the max height!");
                }

                if (string.IsNullOrEmpty(maxWeigth))
                {
                    valid = false;
                    MessageBox.Show("Fill in the max weight!");
                }

            }

            //Stacking
            double result2 = 0.0;
            //Total number of layers
            if (radioButtonTrue.Checked)
            {
                double result12 = Math.Floor((Convert.ToDouble(maxHeigth) - 144) / Convert.ToDouble(heigth));
                result2 = result12;

            }
            else if (radioButtonFalse.Checked)
            {
                double result12 = 1;
                result2 = result12;

            }
            else
            {
                valid = false;
                MessageBox.Show("Check the stack option!");
            }

            if (valid)
            {

                //                      Freight unit
                //Total number of packages in one layer:
                double result1 = Math.Ceiling((1200 / Convert.ToDouble(length)) * (800 / Convert.ToDouble(wide)));

                //Total number of layers:        
                double result3 = Math.Ceiling(result1 * result2);

                //Freight unit height:
                double result4 = 144 + result2 * Convert.ToDouble(heigth);

                //Freight unit weight:
                double result5 = Math.Round((result3 * Convert.ToDouble(weigth)), 2) + 25;

                //Freight unit volume:
                double result6 = Math.Round(1.2 * 0.8 * (result4 / 1000), 2);

                //Number of palletes in cargo:
                double result7 = Math.Ceiling(Convert.ToDouble(quantity) / result3);

                //Total cargo volume:
                double result8 = Math.Round(result6 * result7, 2);

                //Total cargo weight:
                double result9 = Math.Round(result5 * result7, 3);

                textResult1.Text = Convert.ToString(result3);
                textResult2.Text = Convert.ToString(result2);
                textResult3.Text = Convert.ToString(result1);
                textResult4.Text = Convert.ToString(result7);
                textResult5.Text = Convert.ToString(result4 + "mm");
                textResult6.Text = Convert.ToString(result6 + "m3");
                textResult7.Text = Convert.ToString(result8 + "m3");
                textResult8.Text = Convert.ToString(result5 + "kg");
                textResult9.Text = Convert.ToString(result9 + "kg");

                //                  Total cargo weight
                if (result9 > Convert.ToDouble(maxWeigth))
                {
                    MessageBox.Show("Total cargo weight is bigger than max weight!","Warning" ,MessageBoxButtons.OK ,MessageBoxIcon.Warning);
                }

            }

        }
        //Clear(Collective packages)
        private void buttonWycz_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox7.Clear();
            textBox8.Clear();

        }
        //Clear(Result)
        private void button1_Click(object sender, EventArgs e)
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Do you really want to close Pallet App?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Form2 info = new Form2();
            info.ShowDialog();
        }
    }
}
