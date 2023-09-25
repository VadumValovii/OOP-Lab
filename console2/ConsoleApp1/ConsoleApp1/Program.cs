using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введіть кількість рядків масиву n: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Введіть кількість стовпців масиву m: ");
            int m = int.Parse(Console.ReadLine());

            double[,] array = new double[n, m];
            Random rnd = new Random();

            // Заповнення масиву псевдовипадковими числами
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    double number = Math.Round((rnd.Next(-4231, 704) + rnd.NextDouble()), 2);
                    array[i, j] = number;
                }
            }

            // Виведення оригінального масиву
            Console.WriteLine("Оригінальний масив:");
            PrintArray(array, n, m);

            // Визначення кількість рядків, які не містять жодного від’ємного елемента
            int positiveRowCount = 0;
            for (int i = 0; i < n; i++)
            {
                bool allPositive = true;
                for (int j = 0; j < m; j++)
                {
                    if (array[i, j] < 0)
                    {
                        allPositive = false;
                        break;
                    }
                }
                if (allPositive)
                    positiveRowCount++;
            }
            Console.WriteLine($"Кількість рядків, які не містять жодного від’ємного елемента: {positiveRowCount}");

            // Поміняти порядок слідування елементів у стовпцях на протилежний
            double[,] reversedArray = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    reversedArray[i, j] = array[n - i - 1, j];
                }
            }

            // Виведення масиву після зміни порядку слідування елементів у стовпцях
            Console.WriteLine("Масив після зміни порядку слідування елементів у стовпцях:");
            PrintArray(reversedArray, n, m);
        }

        static void PrintArray(double[,] array, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{array[i, j],7} ");
                }
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}
