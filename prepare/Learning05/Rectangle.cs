using System;

public class Rectangle : Shape
{
    private double _length;
    private double _width;

    /*Constructor*/
    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }

    /*Getters/Setters*/
    public double getLength()
    {
        return _length;
    }

    public void setLength(double length)
    {
        _length = length;
    }

    public double getWidth()
    {
        return _width;
    }

    public void setWidth(double width)
    {
        _width = width;
    }

    /*Override Method*/
    public override double getArea()
    {
        double area = _length * _width;
        return area;
    }
}