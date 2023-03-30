using System;
public class ChestLoot : Loot
{
    private string _currentLocal;

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
            AddItems(1, "Wooden Club", "weapon", "3");
            AddItems(4, "Bandage", "healing", "2");
            AddItems(3, "Weak Poison", "poison");
            AddItems(1, "Leather Armor", "armor", "3");
            AddItems(1, "Healing Potion", "healing", "5");
        }
        else if (_currentLocal == "swamp")
        {
            AddItems(5, "Weak Poison", "poison");
            AddItems(1, "Healing Potion", "healing", "5");
        }
        Random getRandomNum = new Random();
        int randomNum = getRandomNum.Next(3, 10);
        for (int i = 0; i < randomNum; i++)
        {
            _loot.Add(_potentialLoot[getRandomNum.Next(0, _potentialLoot.Count())]);
        }
    }
}