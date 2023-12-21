using System;

struct Vector3D
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public Vector3D(double x, double y, double z)
    {
        try
        {
            if (x < 0 || y < 0 || z < 0)
            {
                throw new ArgumentException("Координати повинні бути не від'ємними.");
            }

            X = x;
            Y = y;
            Z = z;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Помилка при створенні вектора: {ex.Message}");
            X = Y = Z = 0; // Призначити значення за замовчуванням у випадку помилки
        }
    }

    public static Vector3D operator +(Vector3D v1, Vector3D v2)
    {
        return new Vector3D(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }

    public static Vector3D operator -(Vector3D v1, Vector3D v2)
    {
        return new Vector3D(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
    }

    public static double operator *(Vector3D v1, Vector3D v2)
    {
        return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z; // Скалярний добуток
    }

    public static Vector3D operator *(Vector3D v, double scalar)
    {
        return new Vector3D(v.X * scalar, v.Y * scalar, v.Z * scalar);
    }

    public static bool operator ==(Vector3D v1, Vector3D v2)
    {
        return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
    }

    public static bool operator !=(Vector3D v1, Vector3D v2)
    {
        return !(v1 == v2);
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Vector3D))
            return false;

        Vector3D other = (Vector3D)obj;
        return this == other;
    }

    public override int GetHashCode()
    {
        return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
    }

    public double Length()
    {
        return Math.Sqrt(X * X + Y * Y + Z * Z);
    }

    public static bool CompareLength(Vector3D v1, Vector3D v2)
    {
        return v1.Length() == v2.Length();
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }
}

class Program
{
    static Vector3D[] ReadVectorsFromConsole(int n)
    {
        Vector3D[] vectors = new Vector3D[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введіть координати вектора {i + 1} (x y z): ");
            string[] input = Console.ReadLine().Split();
            double x = double.Parse(input[0]);
            double y = double.Parse(input[1]);
            double z = double.Parse(input[2]);
            vectors[i] = new Vector3D(x, y, z);
        }
        return vectors;
    }

    static void PrintVector(Vector3D vector)
    {
        Console.WriteLine($"Вектор: {vector}");
    }

    static void SortVectors(Vector3D[] vectors)
    {
        Array.Sort(vectors, (v1, v2) => v1.Length().CompareTo(v2.Length()));
    }

    static void ModifyVector(ref Vector3D vector)
    {
        Console.Write("Введіть нові координати для вектора (x y z): ");
        string[] input = Console.ReadLine().Split();
        double x = double.Parse(input[0]);
        double y = double.Parse(input[1]);
        double z = double.Parse(input[2]);
        vector = new Vector3D(x, y, z);
    }

    static void FindMinMaxLength(Vector3D[] vectors, out double maxLength, out double minLength)
    {
        maxLength = minLength = vectors[0].Length();

        foreach (Vector3D vector in vectors)
        {
            double length = vector.Length();
            if (length > maxLength)
                maxLength = length;
            if (length < minLength)
                minLength = length;
        }
    }

    static void Main()
    {
        Console.Write("Введіть кількість векторів: ");
        int n = int.Parse(Console.ReadLine());

        Vector3D[] vectors = ReadVectorsFromConsole(n);

        Console.WriteLine("Введені вектори:");
        foreach (Vector3D vector in vectors)
        {
            PrintVector(vector);
        }

        SortVectors(vectors);

        Console.WriteLine("Відсортовані за довжиною вектори:");
        foreach (Vector3D vector in vectors)
        {
            PrintVector(vector);
        }

        int vectorIndexToModify = 0;
        ModifyVector(ref vectors[vectorIndexToModify]);

        Console.WriteLine("Вектор після модифікації:");
        PrintVector(vectors[vectorIndexToModify]);

        double maxLength, minLength;
        FindMinMaxLength(vectors, out maxLength, out minLength);

        Console.WriteLine($"Максимальна довжина вектора: {maxLength}");
        Console.WriteLine($"Мінімальна довжина вектора: {minLength}");
        Console.WriteLine("Операції з векторами:");

        Vector3D vector1 = new Vector3D(2, 3, 4);
        Vector3D vector2 = new Vector3D(1, 2, 3);

        Console.WriteLine($"Вектор1: {vector1}");
        Console.WriteLine($"Вектор2: {vector2}");

        Vector3D sum = vector1 + vector2;
        Console.WriteLine($"Додавання векторів: {sum}");

        Vector3D difference = vector1 - vector2;
        Console.WriteLine($"Віднімання векторів: {difference}");

        double dotProduct = vector1 * vector2;
        Console.WriteLine($"Скалярний добуток: {dotProduct}");

        double scalar = 2.5;
        Vector3D scalarProduct = vector1 * scalar;
        Console.WriteLine($"Множення вектора на скаляр ({scalar}): {scalarProduct}");

        bool areEqual = vector1 == vector2;
        Console.WriteLine($"Порівняння векторів за координатами: {areEqual}");

        bool sameLength = Vector3D.CompareLength(vector1, vector2);
        Console.WriteLine($"Порівняння довжин векторів: {sameLength}");
    }
}
