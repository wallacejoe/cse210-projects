using System;
public abstract class Loot
{
    protected List<string> _loot = new List<string>();
    protected string _lootContainer;

    /*Constructors*/

    /*Methods*/
    public string ClaimLoot()
    {
        Console.Write("Select which loot you'd like to take: ");
        int userInput = int.Parse(Console.ReadLine());
        string chosenLoot = _loot[userInput - 1];
        _loot.RemoveAt(userInput - 1);
        return chosenLoot;
    }

    public void DisplayLoot()
    {
        int lootNum = 0;
        foreach (string loot in _loot)
        {
            lootNum += 1;
            Console.WriteLine($"  {lootNum}. {loot}");
        }
    }

    public abstract void RandomLoot();

    /*Getters and setters*/
    public string GetLootContainer()
    {
        return _lootContainer;
    }
}