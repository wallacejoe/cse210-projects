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
            AddItems(20, "Tattered Clothes", "armor", "1");
            randomNum = getRandomNum.Next(0, 1);
        }
        else if (_mob == "spider")
        {
            AddItems(5, "Weak Poison", "poison");
            randomNum = getRandomNum.Next(0, 3);
        }
        for (int i = 0; i < randomNum; i++)
        {
            _loot.Add(_potentialLoot[getRandomNum.Next(0, _potentialLoot.Count())]);
        }
    }
}