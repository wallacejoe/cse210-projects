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
            AddItems(1, "Wooden Club", "weapon");
            AddItems(5, "Arrow", "arrow");
            AddItems(3, "Bandage", "loot");
            AddItems(1, "Torch", "equipment");
            AddItems(3, "Weak Poison", "poison");
            AddItems(1, "Leather Armor", "armor");
            AddItems(1, "Wooden Sheild", "equipment");
            AddItems(1, "Potion of Poison Resistance", "potion");
        }
        else if (_currentLocal == "swamp")
        {
            AddItems(5, "Weak Poison", "poison");
            AddItems(5, "Arrow", "arrow");
            AddItems(3, "Potion of Poison Resistance", "potion");
        }
        Random getRandomNum = new Random();
        int randomNum = getRandomNum.Next(3, 20);
        for (int i = 0; i < randomNum; i++)
        {
            _loot.Add(_potentialLoot[getRandomNum.Next(0, _potentialLoot.Count())]);
        }
    }
}