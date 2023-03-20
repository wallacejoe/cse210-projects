using System;
public class ChestLoot : Loot
{
    private string _currentLocal;
    private List<string> potentialLoot = new List<string>();

    /*Constructors*/
    public ChestLoot(string currentLocal)
    {
        _lootContainer = "Chest";
        _currentLocal = currentLocal;
        RandomLoot();
    }

    /*Methods*/
    public override void RandomLoot()
    {
        if (_currentLocal == "forest")
        {
            potentialLoot.Add("Wooden Club");
            AddMultiple(5, "arrow");
            AddMultiple(3, "Bandage");
            potentialLoot.Add("Torch");
            AddMultiple(3, "Weak Poison");
            potentialLoot.Add("Leather Armor");
            potentialLoot.Add("Wooden Sheild");
            potentialLoot.Add("Potion of Poison Resistance");
        }
        else if (_currentLocal == "swamp")
        {
            AddMultiple(5, "Weak Poison");
            AddMultiple(5, "arrow");
            AddMultiple(3, "Potion of Poison Resistance");
        }
        Random getRandomNum = new Random();
        int randomNum = getRandomNum.Next(3, 20);
        for (int i = 0; i < randomNum; i++)
        {
            _loot.Add(potentialLoot[getRandomNum.Next(0, potentialLoot.Count())]);
        }
    }

    private void AddMultiple(int numToAdd, string adding)
    {
        for (int i = 0; i < numToAdd; i++)
        {
            potentialLoot.Add(adding);
        }
    }
}