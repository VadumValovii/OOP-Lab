using System;
using System.Linq;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private double[] _array;
        private Random _rnd;

        public MainWindow()
        {
            InitializeComponent();
            _rnd = new Random();
        }

        private void OnGenerateArrayClicked(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(inputBox.Text, out int n))
            {
                _array = new double[n];
                for (int i = 0; i < n; i++)
                {
                    _array[i] = Math.Round(_rnd.NextDouble() * (3.59 - (-7.51)) + (-7.51), 2);
                }

                arrayList.Items.Clear();
                foreach (var num in _array)
                {
                    arrayList.Items.Add(num);
                }

                double sum = _array.Where(num => num - Math.Truncate(num) < 0.5).Sum(num => Math.Abs(num));

                sumTextBlock.Text = $"Сума модулів елементів з дробовою частиною меншою за 0.5: {sum}";
            }
            else
            {
                MessageBox.Show("Введіть коректне значення для n.");
            }
        }

        private void OnSortArrayClicked(object sender, RoutedEventArgs e)
        {
            if (_array != null && _array.Length > 1)
            {
                double min = _array[0];
                int minIndex = 0;
                for (int i = 1; i < _array.Length; i++)
                {
                    if (_array[i] < min)
                    {
                        min = _array[i];
                        minIndex = i;
                    }
                }

                if (minIndex < _array.Length - 1) // Если минимальный элемент не последний в массиве
                {
                    Array.Sort(_array, minIndex + 1, _array.Length - minIndex - 1);
                    Array.Reverse(_array, minIndex + 1, _array.Length - minIndex - 1);

                    arrayList.Items.Clear();
                    foreach (var num in _array)
                    {
                        arrayList.Items.Add(num);
                    }
                }
                else
                {
                    MessageBox.Show("Сортировка не возможна, так как минимальный элемент находится в конце массива или перед ним нет других элементов.");
                }
            }
            else
            {
                MessageBox.Show("Масив пустий або містить лише один елемент. Спочатку згенеруйте масив.");
            }
        }


    }
}
