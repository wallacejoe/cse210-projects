using System;

public class Circle : Shape
{
    private double _radius;

    /*Constructor*/
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    /*Override Method*/
    public override double getArea()
    {
        double area = _radius * _radius * 3.14;
        return area;
    }
}