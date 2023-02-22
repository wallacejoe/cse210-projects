using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("green", 5);
        Console.WriteLine(square.GetColor());
        Console.WriteLine(square.getArea());

        Rectangle rectangle = new Rectangle("red", 8, 5);
        Console.WriteLine(rectangle.GetColor());
        Console.WriteLine(rectangle.getArea());

        Circle circle = new Circle("blue", 10);
        Console.WriteLine(circle.GetColor());
        Console.WriteLine(circle.getArea());
    }
}