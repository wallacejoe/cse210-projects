using System;
public class Mob
{
    private string _type;
    private int _health;
    private int _attack;
    private int _defense;
    private int _damage;
    private List<string[]> _skills = new List<string[]>();
    private bool _state = true;
    private string _currentLocal;

    /*Constructors*/
    public Mob(string currentLocal)
    {
        _currentLocal = currentLocal;
        RandomMob();
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
        Random getRandomNum = new Random();
        int randomNum = getRandomNum.Next(0, potentialMobs.Count());
        _type = potentialMobs[randomNum];
    }

    private void MobStats()
    {
        if (_type == "spider")
        {
            _health = 5;
            _attack = 3;
            _defense = 5;
            _damage = 2;
            _skills.Add(AddSkillArray("Infectious Bite", "A physical attack, deals mild poison damage", "attack", "2"));
        }
        else if (_type == "zombie")
        {
            _health = 10;
            _attack = 3;
            _defense = 3;
            _damage = 4;
            _skills.Add(AddSkillArray("Grapple", "A physical attack, has a chance of stunning the target", "attack", "4"));
        }
    }

    private string[] AddSkillArray(string name, string description, string type, string value)
    {
        string[] skillArray = {name, description, type, value};
        return skillArray;
    }

    public void DisplayStats()
    {
        Console.WriteLine($"Health: {_health}");
        Console.WriteLine($"Attack: {_attack}");
        Console.WriteLine($"Defense: {_defense}");
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

    public void CheckState()
    {
        if (!_state)
        {

        }
    }

    /*Getters and setters*/
    public List<string[]> GetSkills()
    {
        return _skills;
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
}