using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("green", 5);
        /*Console.WriteLine(square.GetColor());
        Console.WriteLine(square.getArea());
        Console.WriteLine();*/

        Rectangle rectangle = new Rectangle("red", 8, 5);
        /*Console.WriteLine(rectangle.GetColor());
        Console.WriteLine(rectangle.getArea());
        Console.WriteLine();*/

        Circle circle = new Circle("blue", 10);
        /*Console.WriteLine(circle.GetColor());
        Console.WriteLine(circle.getArea());
        Console.WriteLine();*/

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shp in shapes)
        {
            Console.WriteLine(shp.GetColor());
            Console.WriteLine(shp.GetArea());
            Console.WriteLine();
        }
    }
}