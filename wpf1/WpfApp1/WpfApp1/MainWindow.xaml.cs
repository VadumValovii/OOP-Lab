using System;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCalculateClick(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(xInput.Text, out double x))
            {
                MessageBox.Show("Невірний ввід для x. Будь ласка, введіть дійсне число.");
                return;
            }

            if (!double.TryParse(yInput.Text, out double y))
            {
                MessageBox.Show("Невірний ввід для y. Будь ласка, введіть дійсне число.");
                return;
            }

            if (!double.TryParse(zInput.Text, out double z))
            {
                MessageBox.Show("Невірний ввід для z. Будь ласка, введіть дійсне число.");
                return;
            }

            double topValue = 2 * Math.Cos(Math.Pow(x, 2)) - 1 / Math.Sqrt(2) + Math.Pow(2.71, 2);
            double botValue = 2 / 3 + Math.Sin(Math.Pow(y, 2 - z));

            double s = topValue / botValue;
            double roundedS = Math.Round(s, 3);

            resultTextBlock.Text = $"Результат: s = {roundedS}";
        }

        private void zInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
