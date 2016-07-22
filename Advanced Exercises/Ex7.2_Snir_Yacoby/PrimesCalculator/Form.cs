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

namespace PrimesCalculator
{
    public partial class Form : System.Windows.Forms.Form
    {
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private CancellationToken cancellationToken;

        public Form()
        {
            cancellationToken = cancellationTokenSource.Token;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxMinRange_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            int min, max;
            bool isValidInput = int.TryParse((textBoxMinRange as TextBox).Text, out min);
            isValidInput &= int.TryParse((textBoxMaxRange as TextBox).Text, out max);
            isValidInput &= min >= 2 && min <= max;
            List<int> primes = new List<int>();
            var synchronizationContext = SynchronizationContext.Current;

            if (isValidInput)
            {
                Task.Run(() =>
                {
                    for (int i = min; i <= max; i++)
                    {
                        bool isPrime = true;
                        for (int j = 2; j < i; j++)
                        {
                            if (i % j == 0)
                            {
                                isPrime = false;
                            }
                        }

                        if (isPrime)
                        {
                            primes.Add(i);
                        }
                    }

                    synchronizationContext.Send(o =>
                    {
                        listBoxPrimeNumbers.DataSource = primes;
                    }, null);
                }, cancellationToken);
            }
            else
            {
                MessageBox.Show("Invalid inputs! Minimum range must be at least 2");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
        }
    }
}
