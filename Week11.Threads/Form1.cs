using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week11.Threads
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private static int Fibonacci(int n)
        {
            int a = 0, b = 1, c = 0;
            if (n == 0)
                return a;
            for (int i = 2; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return b;
        }

        private List<double> GenFibonacci(double n)
        {
            List<double> fibonacci = new List<double>();
            for (int i = 0; i < n; i++)
            {
                fibonacci.Add(Fibonacci(i));
            }
            return fibonacci;
        }

        private async void btn_Gen_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (!int.TryParse(textBox1.Text, out int n) || n <= 0)
            {
                MessageBox.Show("Enter a positive integer greater than zero");
                textBox1.Text = " ";
            }

            await Task.Run(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    int fibNumber = Fibonacci(i);
                    BeginInvoke(new Action(() => listBox1.Items.Add(fibNumber)));
                    Thread.Sleep(100);  
                }
                
            });
            textBox1.Text = " ";
        }

    }
}
