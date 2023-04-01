using System;

public class SwampMob : Mob
{
    /*Constructors*/
    public SwampMob() : base()
    {
        RandomMob();
        MobStats();
    }

    public SwampMob(string type) : base(type)
    {
        MobStats();
    }

    /*Methods*/
    private void RandomMob()
    {
        List<string> potentialMobs = new List<string>{};
        potentialMobs = new List<string>{"spider", "zombie"};

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
        else if (_type == "zombie")
        {
            _xp = 10;
            _health = 10;
            _attack = 3;
            _defense = 3;
            _damage = 4;
            _skills.Add(AddSkillArray("Grapple", "A physical attack, stuns the target", "attack", "3", "stun"));
        }
    }
}