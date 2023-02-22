using System;

public class Square : Shape
{
    private double _side;

    /*Constructor*/
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    /*Override Method*/
    public override double getArea()
    {
        double area = _side * _side;
        return area;
    }
}