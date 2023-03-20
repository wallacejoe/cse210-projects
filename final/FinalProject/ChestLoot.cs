using System;
public class ChestLoot : Loot
{
    private string _currentLocal;

    /*Constructors*/
    public ChestLoot(string currentLocal)
    {
        _currentLocal = currentLocal;
    }

    /*Methods*/
    public override List<string> RandomLoot()
    {

    }
}