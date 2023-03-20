using System;
public class Character
{
    private int _health;
    private int _mana;
    private int _stamina;
    private int _xp;
    private List<string> _skills = new List<string>();
    private List<string> _spells = new List<string>();
    private List<string> _equipment = new List<string>();

    /*Constructors*/
    public Character(){}

    public Character(int health, int mana, int stamina, int xp, List<string> skills, List<string> spells, List<string> equipment)
    {
        _health = health;
        _mana = mana;
        _stamina = stamina;
        _xp = xp;
        _skills = skills;
        _spells = spells;
        _equipment = equipment;
    }

    /*Methods*/
    public void AcquireSkill()
    {

    }

    public void EquipArmor()
    {

    }

    public void EquipWeapon()
    {
        
    }
}