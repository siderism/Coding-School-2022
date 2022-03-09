using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session_06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAddition_Click(object sender, EventArgs e)
        {
            try
            {
                decimal num1 = Convert.ToDecimal(this.textBox1.Text);
                decimal num2 = Convert.ToDecimal(this.textBox2.Text);
                var add = new Calculator.Addition(num1, num2);
                string result = add.Execute();
                this.textLogger.Text += this.textBox1.Text + " + " + this.textBox2.Text + " = " + result + Environment.NewLine;
            }
            catch (Exception ex)
            {
                this.textLogger.Text += ex.Message + Environment.NewLine;
            }
        }

        private void buttonSquareRoot_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = Convert.ToDouble(this.textBox1.Text);
                var square = new Calculator.SquareRoot(num1);
                string result = square.Execute();
                this.textLogger.Text += "√" + this.textBox1.Text + " = " + result + Environment.NewLine;
            }
            catch (Exception ex)
            {
                this.textLogger.Text += ex.Message + Environment.NewLine;
            }
        }

        private void buttonToPower_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = Convert.ToDouble(this.textBox1.Text);
                double num2 = Convert.ToDouble(this.textBox2.Text);
                var pow = new Calculator.ToPower(num1, num2);
                string result = pow.Execute();
                this.textLogger.Text += this.textBox1.Text + " ^ " + this.textBox2.Text + " = " + result + Environment.NewLine;
            }
            catch (Exception ex)
            {
                this.textLogger.Text += ex.Message + Environment.NewLine;
            }
        }

        private void buttonDivision_Click(object sender, EventArgs e)
        {
            try
            {
                decimal num1 = Convert.ToDecimal(this.textBox1.Text);
                decimal num2 = Convert.ToDecimal(this.textBox2.Text);
                if (num2 == 0.0m)
                {
                    this.textLogger.Text += "Division with 0 error." + Environment.NewLine;
                    return;
                }
                var div = new Calculator.Division(num1, num2);
                string result = div.Execute();
                this.textLogger.Text += this.textBox1.Text + " / " + this.textBox2.Text + " = " + result + Environment.NewLine;
            }
            catch (Exception ex)
            {
                this.textLogger.Text += ex.Message + Environment.NewLine;
            }
        }

        private void buttonMultiplication_Click(object sender, EventArgs e)
        {
            try
            {
                decimal num1 = Convert.ToDecimal(this.textBox1.Text);
                decimal num2 = Convert.ToDecimal(this.textBox2.Text);
                var multi = new Calculator.Multiplication(num1, num2);
                string result = multi.Execute();
                this.textLogger.Text += this.textBox1.Text + " * " + this.textBox2.Text + " = " + result + Environment.NewLine;
            }
            catch (Exception ex)
            {
                this.textLogger.Text += ex.Message + Environment.NewLine;
            }
        }

        private void buttonSubtraction_Click(object sender, EventArgs e)
        {
            try
            {
                decimal num1 = Convert.ToDecimal(this.textBox1.Text);
                decimal num2 = Convert.ToDecimal(this.textBox2.Text);
                var sub = new Calculator.Subtraction(num1, num2);
                string result = sub.Execute();
                this.textLogger.Text += this.textBox1.Text + " - " + this.textBox2.Text + " = " + result + Environment.NewLine;
            }
            catch (Exception ex)
            {
                this.textLogger.Text += ex.Message + Environment.NewLine;
            }
        }
    }
}
