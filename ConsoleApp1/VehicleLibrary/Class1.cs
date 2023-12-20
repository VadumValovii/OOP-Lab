namespace VehicleLibrary
{
        public class Vehicle
        {
            public string Brand { get; set; }
            public double Mileage { get; set; }
            public int Power { get; set; }
            public int CylinderCount { get; set; }

            public Vehicle()
            {
                // Конструктор за замовчуванням
            }

            public Vehicle(string brand, double mileage, int power, int cylinderCount)
            {
                Brand = brand;
                Mileage = mileage;
                Power = power;
                CylinderCount = cylinderCount;
            }

            public Vehicle(Vehicle other)
            {
                // Конструктор копіювання
                Brand = other.Brand;
                Mileage = other.Mileage;
                Power = other.Power;
                CylinderCount = other.CylinderCount;
            }

            public virtual void ShowInfo()
            {
                Console.WriteLine($"Brand: {Brand}, Mileage: {Mileage}, Power: {Power}, Cylinders: {CylinderCount}");
            }
        }

        public class Car : Vehicle
        {
            public int PassengerCount { get; set; }

            public Car()
            {
                // Конструктор за замовчуванням
            }

            public Car(string brand, double mileage, int power, int cylinderCount, int passengerCount)
                : base(brand, mileage, power, cylinderCount)
            {
                PassengerCount = passengerCount;
            }

            public Car(Car other)
                : base(other)
            {
                // Конструктор копіювання
                PassengerCount = other.PassengerCount;
            }

            public override void ShowInfo()
            {
                base.ShowInfo();
                Console.WriteLine($"Passenger Count: {PassengerCount}");
            }
        }

        public class Lorry : Vehicle
        {
            public double LoadCapacity { get; set; }

            public Lorry()
            {
                // Конструктор за замовчуванням
            }

            public Lorry(string brand, double mileage, int power, int cylinderCount, double loadCapacity)
                : base(brand, mileage, power, cylinderCount)
            {
                LoadCapacity = loadCapacity;
            }

            public Lorry(Lorry other)
                : base(other)
            {
                // Конструктор копіювання
                LoadCapacity = other.LoadCapacity;
            }

            public override void ShowInfo()
            {
                base.ShowInfo();
                Console.WriteLine($"Load Capacity: {LoadCapacity}");
            }
        }

}
