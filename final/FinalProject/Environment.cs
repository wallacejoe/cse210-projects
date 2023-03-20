using System;
public class Environment
{
    private Location _currentLocal;
    private List<Location> _allLocations = new List<Location>();

    /*Constructors*/
    public Environment(){}

    public Environment(Location currentLocal)
    {
        _currentLocal = currentLocal;
    }

    /*Methods*/
    public void ActionMenu()
    {

    }

}