using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть значення n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Некоректне значення n.");
                return;
            }
            Console.Write("Введіть значення k: ");
            if (!int.TryParse(Console.ReadLine(), out int k) || k <= 0)
            {
                Console.WriteLine("Некоректне значення k.");
                return;
            }
            while (true)
            {
                Console.WriteLine("Виберіть обчислення (1, 2 або 3):");
                Console.WriteLine("1. Сума: 1^n + 2^(n/2) + ... + k^(n/k)");
                Console.WriteLine("2. Сума: 1^k + 2^k + ... + n^k");
                Console.WriteLine("3. Сума: 1/n + 2/n^2 + 3/n^3 + ... + k/n^k");
                switch (Console.ReadLine())
                {
                    case "1":
                        double sum1 = 0;
                        for (int i = 1; i <= k; i++)
                        {
                            sum1 += Math.Pow(i, (double)n / i);
                        }
                        Console.WriteLine($"Результат: {sum1}");
                        break;

                    case "2":
                        double sum2 = 0;
                        for (int i = 1; i <= n; i++)
                        {
                            sum2 += Math.Pow(i, k);
                        }
                        Console.WriteLine($"Результат: {sum2}");
                        break;

                    case "3":
                        double sum3 = 0;
                        for (int i = 1; i <= k; i++)
                        {
                            sum3 += 1 / Math.Pow(n, i);
                        }
                        Console.WriteLine($"Результат: {sum3}");
                        break;

                    default:
                        Console.WriteLine("Некоректний вибір опції.");
                        break;
                }
                Console.WriteLine("Натисніть 'esc' для виходу або будь-яку іншу клавішу, щоб продовжити.");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
