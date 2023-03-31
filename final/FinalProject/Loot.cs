using System;
public abstract class Loot
{
    protected List<string[]> _loot = new List<string[]>();
    protected string _lootContainer;
    protected List<string[]> _potentialLoot = new List<string[]>();

    /*Constructors*/

    /*Methods*/
    public string[] ClaimLoot()
    {
        Console.Write("Select which loot you'd like to take: ");
        int userInput = int.Parse(Console.ReadLine());
        string[] chosenLoot = _loot[userInput - 1];
        _loot.RemoveAt(userInput - 1);
        return chosenLoot;
    }

    public void DisplayLoot()
    {
        int lootNum = 0;
        foreach (string[] loot in _loot)
        {
            lootNum += 1;
            Console.WriteLine($"  {lootNum}. {loot[0]}");
        }
    }

    protected void AddItems(int numToAdd, string item, string type, string value="", string attribute="")
    {
        for (int i = 0; i < numToAdd; i++)
        {
            string[] completeItem = {item, type, value, attribute};
            _potentialLoot.Add(completeItem);
        }
    }

    public List<string> Serialize()
    {
        List<string> serializedList = new List<string>();
        foreach (string[] loot in _loot)
        {
            string serializedString = "loot";
            foreach (string value in loot)
            {
                serializedString += $"|/^|{value}";
            }
            serializedList.Add(serializedString);
        }
        serializedList.Add($"container|/^|{_lootContainer}");

        return serializedList;
    }

    public abstract void RandomLoot();

    /*Getters and setters*/
    public string GetLootContainer()
    {
        return _lootContainer;
    }
}