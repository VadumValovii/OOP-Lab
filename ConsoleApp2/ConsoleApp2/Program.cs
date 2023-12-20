using System;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    public int Numerator
    {
        get { return _numerator; }
        set { _numerator = value; }
    }

    public int Denominator
    {
        get { return _denominator; }
        set
        {
            if (value == 0) throw new ArgumentException("Знаменник не може бути нулем!");
            _denominator = value;
        }
    }

    public Fraction(int numerator, int denominator = 1)
    {
        Numerator = numerator;
        Denominator = denominator;
        Reduce();
    }

    public static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = a % b;
            a = b;
            b = temp;
        }
        return a;
    }

    public void Reduce()
    {
        int gcd = GCD(Numerator, Denominator);
        Numerator /= gcd;
        Denominator /= gcd;
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        return new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
    }

    public static Fraction operator -(Fraction a)
    {
        return new Fraction(-a.Numerator, a.Denominator);
    }

    public static Fraction operator -(Fraction a, Fraction b)
    {
        return new Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
    }

    public static Fraction operator *(Fraction a, Fraction b)
    {
        return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
    }

    public static Fraction operator /(Fraction a, Fraction b)
    {
        return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
    }

    public static bool operator >(Fraction a, Fraction b)
    {
        return a.Numerator * b.Denominator > b.Numerator * a.Denominator;
    }

    public static bool operator >=(Fraction a, Fraction b)
    {
        return a.Numerator * b.Denominator >= b.Numerator * a.Denominator;
    }

    public static bool operator <(Fraction a, Fraction b)
    {
        return a.Numerator * b.Denominator < b.Numerator * a.Denominator;
    }

    public static bool operator <=(Fraction a, Fraction b)
    {
        return a.Numerator * b.Denominator <= b.Numerator * a.Denominator;
    }

    public static bool operator ==(Fraction a, Fraction b)
    {
        return a.Numerator * b.Denominator == b.Numerator * a.Denominator;
    }
    public static bool operator !=(Fraction a, Fraction b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        Fraction fraction = (Fraction)obj;
        return this == fraction;
    }

    public override int GetHashCode()
    {
        return Numerator.GetHashCode() ^ Denominator.GetHashCode();
    }

    public static implicit operator double(Fraction fraction)
    {
        return (double)fraction.Numerator / fraction.Denominator;
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }
}

public class Program
{
    public static void Main()
    {
        Fraction a = new Fraction(3, 4);
        Fraction b = new Fraction(2, 3);
        Console.WriteLine($"a = {a}");
        Console.WriteLine($"b = {b}");

        Console.WriteLine($"a + b = {a + b}");
        Console.WriteLine($"a - b = {a - b}");
        Console.WriteLine($"a * b = {a * b}");
        Console.WriteLine($"a / b = {a / b}");

        Console.WriteLine($"a > b: {a > b}");
        Console.WriteLine($"a >= b: {a >= b}");
        Console.WriteLine($"a < b: {a < b}");
        Console.WriteLine($"a <= b: {a <= b}");
        Console.WriteLine($"a == b: {a == b}");
        Console.WriteLine($"a != b: {a != b}");

        Console.WriteLine($"a десяткового дробу: {(double)a}");
        Console.ReadLine();
    }
}
