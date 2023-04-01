using System;
public class Mob
{
    protected int _xp;
    protected string _type;
    protected int _health;
    protected int _attack;
    protected int _defense;
    protected int _damage;
    protected List<string[]> _skills = new List<string[]>();
    protected List<string[]> _activeEffects = new List<string[]>();
    private bool _state = true;

    /*Constructors*/
    public Mob(){}

    public Mob(string type)
    {
        _type = type;
    }

    /*Methods*/
    protected string[] AddSkillArray(string name, string description, string type, string value, string effect)
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