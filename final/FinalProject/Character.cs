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
    public Character()
    {
        string userInput = "";
        _xp = 10;
        Console.WriteLine("Create your character:");
        while (_xp > 0)
        {
            Console.WriteLine($"Increases left {_xp}");
            Console.WriteLine("  1. Increase health");
            Console.WriteLine("  2. Increase mana");
            Console.WriteLine("  3. Increase stamina");
            Console.Write("Select a base stat to increase: ");
            userInput = Console.ReadLine();

            if (userInput == "1")
            {
                _health += 1;
                _xp -= 1;
            }
            else if (userInput == "2")
            {
                _mana += 2;
                _xp -= 1;
            }
            else if (userInput == "3")
            {
                _stamina += 2;
                _xp -= 1;
            }
            else {Console.WriteLine("That was not a valid input");}
        }
    }

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