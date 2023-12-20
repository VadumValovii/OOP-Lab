using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!TryGetDouble("Введіть дробове значення x = ", out double x))
                return;
            if (!TryGetDouble("Введіть дробове значення y = ", out double y))
                return;
            if (!TryGetDouble("Введіть дробове значення y = ", out double z))
                return;

            double topValue =2*Math.Cos(Math.Pow(x,2))-1/Math.Sqrt(2)+Math.Pow(2.71,2);
            double botValue = 2 / 3 + Math.Sin(Math.Pow(y, 2 - z));

            double s = topValue / botValue;

            double roundedS = Math.Round(s, 3);
            Console.WriteLine($"Результат: s = {roundedS}");

            Console.WriteLine("Натисніть Enter, щоб вийти.");
            Console.ReadLine();
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
