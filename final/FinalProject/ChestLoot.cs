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

    public ChestLoot(List<string[]> loot, string container)
    {
        _loot = loot;
        _lootContainer = container;
    }

    /*Methods*/
    public override void RandomLoot()
    {
        int maxSize = 10;
        int minSize = 3;
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
            maxSize = 5;
            minSize = 1;
            AddItems(5, "Weak Poison", "poison");
            AddItems(1, "Healing Potion", "healing", "5");
        }
        else if (_currentLocal == "mage tower")    //attribute
        {            //    name    loot type    value    effect    description    cost    type
            maxSize = 2;
            minSize = 1;
            AddItems(1, "shock", "spell", "2", "", "A basic attack spell, has no extraordinary effects", "1", "attack");
            AddItems(5, "healing hands", "spell", "2", "", "Heals the caster by a small amount (2HP)", "2", "healing");
        }
        Random getRandomNum = new Random();
        int randomNum = getRandomNum.Next(minSize, maxSize);
        for (int i = 0; i < randomNum; i++)
        {
            _loot.Add(_potentialLoot[getRandomNum.Next(0, _potentialLoot.Count())]);
        }
    }
}