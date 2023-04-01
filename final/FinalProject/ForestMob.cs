using System;

public class ForestMob : Mob
{
    /*Constructors*/
    public ForestMob() : base()
    {
        RandomMob();
        MobStats();
    }

    public ForestMob(string type) : base(type)
    {
        MobStats();
    }

    /*Methods*/
    private void RandomMob()
    {
        List<string> potentialMobs = new List<string>{};
        potentialMobs = new List<string>{"spider"};

        Random getRandomNum = new Random();
        int randomNum = getRandomNum.Next(0, potentialMobs.Count());
        _type = potentialMobs[randomNum];
    }

    private void MobStats()
    {
        if (_type == "spider")
        {
            _xp = 5;
            _health = 5;
            _attack = 3;
            _defense = 5;
            _damage = 2;
        }
    }
}