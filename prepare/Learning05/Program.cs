using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("green", 5);
        Console.WriteLine(square.GetColor());
        Console.WriteLine(square.getArea());
    }
}