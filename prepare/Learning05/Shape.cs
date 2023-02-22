using System;

public abstract class Shape
{
    private string _color;

    /*Constructor*/
    public Shape(string color)
    {
        _color = color;
    }

    /*Getters/Setters*/
    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }
    
    /*Abstract Method*/
    public abstract double getArea();
}