using System;

public class MageTowerMob : Mob
{
    /*Constructors*/
    public MageTowerMob() : base()
    {
        RandomMob();
        MobStats();
    }

    public MageTowerMob(string type) : base(type)
    {
        MobStats();
    }

    /*Methods*/
    private void RandomMob()
    {
        List<string> potentialMobs = new List<string>{};
        potentialMobs = new List<string>{"golem"};

        Random getRandomNum = new Random();
        int randomNum = getRandomNum.Next(0, potentialMobs.Count());
        _type = potentialMobs[randomNum];
    }

    private void MobStats()
    {
        if (_type == "golem")
        {
            _xp = 30;
            _health = 25;
            _attack = 3;
            _defense = 4;
            _damage = 8;
            _skills.Add(AddSkillArray("Pummel", "A flurry of blows, deals high damage and stuns the target", "attack", "5", "stun"));
        }
    }
}