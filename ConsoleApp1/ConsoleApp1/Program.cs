using System;

class Currency
{
    public string Name { get; set; }
    public double ExRate { get; set; }

    public Currency()
    {
        // Конструктор за замовчуванням
    }

    public Currency(string name, double exRate)
    {
        Name = name;
        ExRate = exRate;
    }

    public Currency(Currency other)
    {
        // Конструктор копіювання
        Name = other.Name;
        ExRate = other.ExRate;
    }

    public override string ToString()
    {
        return $"{Name} (Exchange Rate: {ExRate})";
    }
}

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public Currency Cost { get; set; }
    public int Quantity { get; set; }
    public string Producer { get; set; }
    public double Weight { get; set; }

    public Product()
    {
        // Конструктор за замовчуванням
    }

    public Product(string name, double price, Currency cost, int quantity, string producer, double weight)
    {
        Name = name;
        Price = price;
        Cost = cost;
        Quantity = quantity;
        Producer = producer;
        Weight = weight;
    }

    public Product(Product other)
    {
        // Конструктор копіювання
        Name = other.Name;
        Price = other.Price;
        Cost = new Currency(other.Cost);
        Quantity = other.Quantity;
        Producer = other.Producer;
        Weight = other.Weight;
    }

    public double GetPriceInUAH()
    {
        return Price * Cost.ExRate;
    }

    public double GetWeightInPounds()
    {
        return Weight * 2.20462; // Коефіцієнт для переведення кілограмів в фунти
    }

    public override string ToString()
    {
        return $"{Name} - Price: {GetPriceInUAH()} UAH, Weight: {GetWeightInPounds()} lbs";
    }
}

class Program
{
    static void Main()
    {
        int n = 2; // Кількість об'єктів

        Product[] products = ReadProductsFromConsole(n);

        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Вивести інформацію про один товар");
            Console.WriteLine("2. Вивести інформацію про всі товари");
            Console.WriteLine("3. Вихід");
            Console.Write("Виберіть опцію: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введіть індекс товару: ");
                    int index = int.Parse(Console.ReadLine());
                    if (index >= 0 && index < n)
                    {
                        PrintProduct(products[index]);
                    }
                    else
                    {
                        Console.WriteLine("Невірний індекс товару");
                    }
                    break;

                case "2":
                    PrintAllProducts(products);
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Невірний вибір");
                    break;
            }
        }
    }

    static Product[] ReadProductsFromConsole(int n)
    {
        Product[] products = new Product[n];
        Console.WriteLine("Введіть дані про товари:");

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Товар {i + 1}:");
            Console.Write("Назва товару: ");
            string name = Console.ReadLine();
            Console.Write("Вартість товару: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Валюта: ");
            string currencyName = Console.ReadLine();
            Console.Write("Курс обміну: ");
            double exRate = double.Parse(Console.ReadLine());
            Currency cost = new Currency(currencyName, exRate);
            Console.Write("Кількість на складі: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("Виробник: ");
            string producer = Console.ReadLine();
            Console.Write("Вага товару (в кг): ");
            double weight = double.Parse(Console.ReadLine());

            products[i] = new Product(name, price, cost, quantity, producer, weight);
        }

        return products;
    }

    static void PrintProduct(Product product)
    {
        Console.WriteLine(product);
    }

    static void PrintAllProducts(Product[] products)
    {
        Console.WriteLine("Інформація про всі товари:");
        foreach (Product product in products)
        {
            Console.WriteLine(product);
        }
    }
}
