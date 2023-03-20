using System;
public abstract class Loot
{
    private List<string> _loot = new List<string>();

    /*Constructors*/

    /*Methods*/
    public List<string> ClaimLoot()
    {
        return new List<string>();
    }

    public void DisplayLoot()
    {

    }

    public abstract List<string> RandomLoot();
}