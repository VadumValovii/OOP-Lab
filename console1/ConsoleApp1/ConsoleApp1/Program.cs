using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть кількість елементів масиву (n): ");
            int n = int.Parse(Console.ReadLine());

            Random rnd = new Random();
            double[] arr = new double[n];

            // Генерація масиву
            for (int i = 0; i < n; i++)
            {
                arr[i] = Math.Round(rnd.NextDouble() * (3.59 - (-7.51)) + (-7.51), 2);
            }

            Console.WriteLine("Початковий масив:");
            Console.WriteLine(string.Join(", ", arr));
            Console.ReadLine();

            // Завдання 1
            double sum = 0;
            foreach (double num in arr)
            {
                if (num - Math.Truncate(num) < 0.5)
                {
                    sum += Math.Abs(num);
                }
            }
            Console.WriteLine("\nСума модулів елементів з дробовою частиною меншою за 0.5: " + sum);

            // Завдання 2
            double min = arr[0];
            int minIndex = 0;
            for (int i = 1; i < n; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    minIndex = i;
                }
            }

            Array.Sort(arr, minIndex + 1, n - minIndex - 1);
            Array.Reverse(arr, minIndex + 1, n - minIndex - 1);
            Console.WriteLine("\nМасив після впорядкування елементів після мінімального елементу за спаданням:");
            Console.WriteLine(string.Join(", ", arr));
            Console.ReadLine();

        }
    }
}
