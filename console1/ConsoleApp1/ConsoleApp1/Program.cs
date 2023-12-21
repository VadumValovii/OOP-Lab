using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Swap(ref double e1, ref double e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
        static void Main(string[] args)
        {
            Console.Write("Введіть кількість елементів масиву (n): ");
            int n = int.Parse(Console.ReadLine());

            Random rnd = new Random();
            double[] arr = new double[n];

           
            for (int i = 0; i < n; i++)
            {
                arr[i] = Math.Round(rnd.NextDouble() * (12.91 - (-28.35)) + (-28.35), 2);
            }

            Console.WriteLine("Початковий масив:");
            Console.WriteLine(string.Join(", ", arr));
            Console.ReadLine();

            // Завдання 1
            double dobutok = 1;
            for(int i = 0; i <n; i++)
            {
                if (arr[i] < 0)
                {
                    dobutok *= i;
                }
            }
            Console.WriteLine("\nДобуток індексів від’ємних елементів: " + dobutok);

            // Завдання 2
            var len = arr.Length;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
         
            Console.WriteLine("\nМасив після впорядкування  елементів за спаданням їх значень.:");
            Console.WriteLine(string.Join(", ", arr));
            Console.ReadLine();

        }
    }
}
