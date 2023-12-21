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
                    double number = Math.Round((rnd.Next(-249, 603) + rnd.NextDouble()), 2);
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

            // Переставлення рядків за спаданням сум елементів у рядках
            SortRowsBySum(array, n, m);

            Console.WriteLine("Масив після перестановки рядків за спаданням сум:");
            PrintArray(array,n,m);
        }

        // Метод для перестановки рядків за спаданням сум елементів у рядках
        static void SortRowsBySum(double[,] array, int n, int m)
        {
            double[] rowSums = new double[n];

            // Обчислення сум елементів у кожному рядку
            for (int i = 0; i < n; i++)
            {
                double rowSum = 0;
                for (int j = 0; j < m; j++)
                {
                    rowSum += array[i, j];
                }
                rowSums[i] = rowSum;
            }

            // Сортування рядків за спаданням сум
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (rowSums[j] > rowSums[i])
                    {
                        // Обмін рядків
                        for (int k = 0; k < m; k++)
                        {
                            double temp = array[i, k];
                            array[i, k] = array[j, k];
                            array[j, k] = temp;
                        }

                        // Обмін сум
                        double tempSum = rowSums[i];
                        rowSums[i] = rowSums[j];
                        rowSums[j] = tempSum;
                    }
                }
            }
        }

        // Метод для виведення масиву на екран
        static void PrintArray(double[,] array,int n,int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
       
    }
}
