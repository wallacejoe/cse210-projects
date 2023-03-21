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

    /*Methods*/
    public override void RandomLoot()
    {
        Random getRandomNum = new Random();
        int randomNum = getRandomNum.Next(0, 5);
        if (_mob == "zombie")
        {
            AddItems(1, "Wrath Pendant", "equipment");
            AddItems(20, "Tattered Clothes", "armor");
            randomNum = getRandomNum.Next(0, 1);
        }
        else if (_mob == "spider")
        {
            AddItems(5, "Weak Poison", "poison");
            AddItems(2, "Potion of Poison Resistance", "potion");
            randomNum = getRandomNum.Next(0, 3);
        }
        for (int i = 0; i < randomNum; i++)
        {
            _loot.Add(_potentialLoot[getRandomNum.Next(0, _potentialLoot.Count())]);
        }
    }
}