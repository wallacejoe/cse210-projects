using System;

public class Fraction
{
    /*Attributes*/
    private int _top;
    private int _bottom;

    /*Constructors*/
    //Sets a default value for the Fraction attributes
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    //Takes a single whole number as the value
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }
    //Takes two integers as the values
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    /*Getters and Setters*/
    //Returns the value of the _top attribute
    public int GetTop()
    {
        return _top;
    }
    //Sets the value of the _top attribute
    public void SetTop(int top)
    {
        _top = top;
    }
    //Returns the value of the _bottom attribute
    public int GetBottom()
    {
        return _bottom;
    }
    //Sets the value of the _bottom attribute
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }
    /*Methods*/
    //Returns the fraction as a string in this form 1/2
    public string GetFractionString()
    {
        string fracString = $"{_top}/{_bottom}";
        return fracString;
    }
    public double GetDecimalValue()
    {
        double decValue = (double)_top / (double)_bottom;
        return decValue;
    }
}