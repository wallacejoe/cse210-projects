using System;

public class Circle : Shape
{
    private double _radius;

    /*Constructor*/
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    /*Getters/Setters*/
    public double getRadius()
    {
        return _radius;
    }

    public void setRadius(double radius)
    {
        _radius = radius;
    }

    /*Override Method*/
    public override double GetArea()
    {
        double area = _radius * _radius * 3.14;
        return area;
    }
}