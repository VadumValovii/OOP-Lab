using System;

using VehicleLibrary;

class Program
{
    static void Main()
    {
        const int arraySize = 2;
        Vehicle[] vehicles = new Vehicle[arraySize];

        vehicles[0] = new Car("Toyota", 120000, 150, 4, 5);
        vehicles[1] = new Lorry("Volvo", 80000, 300, 8, 15000);

        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Показати інформацію про транспорт");
            Console.WriteLine("2. Вихід");
            Console.Write("Виберіть опцію: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowAllVehiclesInfo(vehicles);
                    break;

                case "2":
                    return;

                default:
                    Console.WriteLine("Невірний вибір");
                    break;
            }
        }
    }

    static void ShowAllVehiclesInfo(Vehicle[] vehicles)
    {
        Console.WriteLine("Інформація про транспорт:");

        foreach (var vehicle in vehicles)
        {
            vehicle.ShowInfo();
            Console.WriteLine();
        }
    }
}

