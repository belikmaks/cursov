using System.Diagnostics.Eventing.Reader;

namespace cursov
{
    public partial class Form1 : Form
    {
        int countF1 = 0;
        int countF2 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            countF1 = 0;
            countF2 = 0;

            try
            {
                double xn = double.Parse(textBox1.Text);
                double dx = double.Parse(textBox2.Text);
                double xk = double.Parse(textBox3.Text);

                Random random = new Random();

                for(double x = xn; x <= xk; x += dx)
                {
                    double q = Math.Round(random.NextDouble(), 2); 
                    if (q > 0 && q <= 0.3)
                    {
                        try
                        {
                            double val = Math.Log(Math.Sin(q * x));
                            if (val < 0)
                            {
                                listBox1.Items.Add($"Помилка: логарифм <= 0");
                            }
                            else
                            {
                                listBox1.Items.Add($"x = {x}, q = {q}, f1 = {val}");
                                countF1++;

                            }
                        }
                        catch (Exception ex)
                        {
                            listBox1.Items.Add($"Помилка: {ex.Message}");
                        }
                    }
                    else if (q > 0.3 && q <= 1)
                    {
                        try
                        {
                            double val = Math.Sqrt(Math.Cos(x) / (q * x));
                            if (val < 0)
                            {
                                listBox2.Items.Add($"Помилка: корінь з від'ємного числа");
                            }
                            else
                            {
                                listBox2.Items.Add($"x = {x}, q = {q}, f2 = {val}");
                                countF2++;
                            }
                        }
                        catch (Exception ex)
                        {
                            listBox2.Items.Add($"Помилка: {ex.Message}");
                        }
                    }
                }
                label1.Text = $"Кількість f1: {countF1}";
                label2.Text = $"Кількість f2: {countF2}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Введіть коректні числові значення для xn, dx та xk.", "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
