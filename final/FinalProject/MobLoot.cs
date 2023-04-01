using System;
public class MobLoot : Loot
{
    private string _mob;
    
    /*Constructors*/
    public MobLoot(string mob)
    {
        _lootContainer = "Corpse";
        _mob = mob;
        RandomLoot();
    }

    public MobLoot(List<string[]> loot, string container)
    {
        _loot = loot;
        _lootContainer = container;
    }

    /*Methods*/
    public override void RandomLoot()
    {
        Random getRandomNum = new Random();
        int randomNum = getRandomNum.Next(0, 5);
        if (_mob == "zombie")
        {
            AddItems(1, "Tattered Clothes", "armor", "1");
            AddItems(1, "Wooden Club", "weapon", "2");
            randomNum = getRandomNum.Next(0, 2);
        }
        else if (_mob == "spider")
        {
            AddItems(1, "Weak Poison", "poison");
            randomNum = getRandomNum.Next(0, 3);
        }
        else if (_mob == "golem")
        {
            AddItems(5, "Iron Armor", "armor", "4");
            AddItems(5, "Iron Sword", "weapon", "5");
            randomNum = getRandomNum.Next(0, 2);
        }
        for (int i = 0; i < randomNum; i++)
        {
            _loot.Add(_potentialLoot[getRandomNum.Next(0, _potentialLoot.Count())]);
        }
    }
}