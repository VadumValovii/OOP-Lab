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
            if (!TryGetDouble("Введіть дробове значення a = ", out double a))
                return;

            if (!TryGetDouble("Введіть дробове значення b = ", out double b))
                return;

            if (!TryGetDouble("Введіть дробове значення c = ", out double c))
                return;

            double discriminant = b * b - 4 * a * c;
            Console.WriteLine($"Дискримінант: {discriminant}");

            if (discriminant > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine($"Розв'язки: x1 = {x1}, x2 = {x2}");
                Console.ReadLine();
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine($"Розв'язок: x = {x}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Розв'язків немає.");
                Console.ReadKey();
            }          
        }
        private static bool TryGetDouble(string message, out double result)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out result))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Помилка введення значення. Будь ласка, повторіть введення.");
                }
            }
        }
    }
}
