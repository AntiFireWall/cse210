using System;
using Fractions;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(6);
        Fraction fraction3 = new Fraction(1,7);
        Console.WriteLine(fraction1.GetTop());
        Console.WriteLine(fraction1.GetBottom());
        fraction2.SetTop(10);
        Console.WriteLine(fraction2.GetTop());
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());
    }
}