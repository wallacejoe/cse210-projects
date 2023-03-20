using System;
public class Character
{
    private int _health;
    private int _mana;
    private int _stamina;
    private int _xp;
    private List<string> _skills = new List<string>();
    private List<string> _spells = new List<string>();
    private List<string[]> _equipment = new List<string[]>();
    private string[] _equipedWeapon;
    private string[] _equipedArmor;

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

    public Character(int health, int mana, int stamina, int xp, List<string> skills, List<string> spells, List<string[]> equipment)
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
    public void CharacterMenu()
    {
        string userInput = "";
        while (userInput != "7")
        {
            Console.Clear();
            Console.WriteLine("Character menu:");
            Console.WriteLine("  1. Character stats");
            Console.WriteLine("  2. Character skills");
            Console.WriteLine("  3. Character spells");
            Console.WriteLine("  4. Character equipment");
            Console.WriteLine("  5. Equip Armor");
            Console.WriteLine("  6. Equip Weapon");
            Console.WriteLine("  7. Exit Character menu");
            Console.Write("Select a choice from the menu: ");
            userInput = Console.ReadLine();

            if (userInput == "1")
            {
                Console.Clear();
                Console.WriteLine($"Health: {_health}");
                Console.WriteLine($"Mana: {_mana}");
                Console.WriteLine($"Stamina: {_stamina}");
                Console.WriteLine($"Experience: {_xp}");
                Console.Write("Press enter to continue:");
                Console.ReadLine();
            }
            else if (userInput == "2")
            {

            }
            else if (userInput == "3")
            {

            }
            else if (userInput == "4")
            {
                Console.Clear();
                Console.WriteLine("Currently equiped items:");
                Console.WriteLine(_equipedWeapon);
                Console.WriteLine(_equipedArmor);
                Console.WriteLine($"\nOther items:");
                foreach (string[] item in _equipment)
                {
                    Console.WriteLine(item[0]);
                }
                Console.Write("Press enter to continue:");
                Console.ReadLine();
            }
            else if (userInput == "5")
            {
                Console.Clear();
                EquipArmor();
            }
            else if (userInput == "6")
            {
                Console.Clear();
                EquipWeapon();
            }
        }
    }

    private void AcquireSkill()
    {

    }

    private void EquipArmor()
    {
        List<string[]> armorList = new List<string[]>();
        foreach (string[] item in _equipment)
        {
            if (item[1] == "armor")
            {
                armorList.Add(item);
            }
        }
        int listNum = 0;
        foreach (string[] item in armorList)
        {
            listNum += 1;
            Console.WriteLine($"  {listNum}. {item[0]}");
        }
        Console.Write("Select the item you'd like to equip: ");
        _equipedArmor = armorList[int.Parse(Console.ReadLine()) - 1];
    }

    private void EquipWeapon()
    {

    }

    /*Getters and setters*/
    public void AddEquipment(string[] equipment)
    {
        _equipment.Add(equipment);
    }
}