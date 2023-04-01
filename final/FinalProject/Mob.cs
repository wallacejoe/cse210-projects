using System;
public class Mob
{
    private int _xp;
    private string _type;
    private int _health;
    private int _attack;
    private int _defense;
    private int _damage;
    private List<string[]> _skills = new List<string[]>();
    private List<string[]> _activeEffects = new List<string[]>();
    private bool _state = true;
    private string _currentLocal;

    /*Constructors*/
    public Mob(string currentLocal)
    {
        _currentLocal = currentLocal;
        RandomMob();
        MobStats();
    }

    public Mob(string type, bool state)
    {
        _type = type;
        MobStats();
    }

    /*Methods*/
    public void RandomMob()
    {
        List<string> potentialMobs = new List<string>{};
        if (_currentLocal == "forest")
        {
            potentialMobs = new List<string>{"spider"};
        }
        else if (_currentLocal == "swamp")
        {
            potentialMobs = new List<string>{"spider", "zombie"};
        }
        else if (_currentLocal == "mage tower")
        {
            potentialMobs = new List<string>{"golem"};
        }
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
        else if (_type == "golem")
        {
            _xp = 30;
            _health = 25;
            _attack = 3;
            _defense = 4;
            _damage = 8;
            _skills.Add(AddSkillArray("Pummel", "A flurry of blows, deals high damage and stuns the target", "attack", "5", "stun"));
        }
    }

    private string[] AddSkillArray(string name, string description, string type, string value, string effect)
    {
        string[] skillArray = {name, description, type, value, effect};
        return skillArray;
    }

    public void DisplayStats()
    {
        Console.WriteLine($"Health: {_health}");
        Console.WriteLine($"Attack: {_attack}");
        Console.WriteLine($"Defense: {_defense}");
        Console.WriteLine($"Damage: {_damage}");
        Console.WriteLine();
        foreach (string[] skill in _skills)
        {
            Console.WriteLine($"{skill[0]}: {skill[1]}");
        }
    }

    public void CalculateDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _state = false;
        }
    }

    /*Getters and setters*/
    public void AddActiveEffects(string name, string value)
    {
        string[] effect = {name, value};
        _activeEffects.Add(effect);
    }

    public List<string[]> GetActiveEffects()
    {
        return _activeEffects;
    }

    public void SetActiveEffects(List<string[]> newEffects)
    {
        _activeEffects = newEffects;
    }

    public List<string[]> GetSkills()
    {
        return _skills;
    }

    public int GetXP()
    {
        return _xp;
    }

    public int GetDamage()
    {
        return _damage;
    }

    public int GetAttack()
    {
        return _attack;
    }

    public int GetDefense()
    {
        return _defense;
    }

    public string GetMobType()
    {
        return _type;
    }

    public int GetHealth()
    {
        return _health;
    }

    public bool GetState()
    {
        return _state;
    }
}