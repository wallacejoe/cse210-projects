using System;
public class Character
{
    private int _health;
    private int _mana;
    private int _stamina;
    private int _xp;
    private int _attack;
    private int _defense;
    private List<string[]> _skills = new List<string[]>();
    private List<string[]> _unclaimedSkills;
    private List<string[]> _spells = new List<string[]>();
    private List<string[]> _equipment = new List<string[]>();
    private string[] _equipedWeapon;
    private string[] _equipedArmor;

    /*Constructors*/
    public Character()
    {
        string userInput = "";
        _xp = 10;
        _attack = 5;
        _defense = 5;
        _unclaimedSkills = AllSkills();
        Console.WriteLine("Create your character:");
        while (_xp > 0)
        {
            Console.Clear();
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

    public Character(int health, int mana, int stamina, int xp, int attack, int defense, List<string[]> skills, List<string[]> unclaimedSkills, List<string[]> spells, List<string[]> equipment)
    {
        _health = health;
        _mana = mana;
        _stamina = stamina;
        _xp = xp;
        _attack = attack;
        _defense = defense;
        _skills = skills;
        _unclaimedSkills = unclaimedSkills;
        _spells = spells;
        _equipment = equipment;
    }

    /*Methods*/
    public void CharacterMenu()
    {
        string userInput = "";
        while (userInput != "5")
        {
            Console.Clear();
            Console.WriteLine("Character menu:");
            Console.WriteLine("  1. Character stats");
            Console.WriteLine("  2. Character skills");
            Console.WriteLine("  3. Character spells");
            Console.WriteLine("  4. Character equipment");
            Console.WriteLine("  5. Exit Character menu");
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
                SkillMenu();
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
                Console.WriteLine("Equipment menu:");
                Console.WriteLine("  1. Equip armor");
                Console.WriteLine("  2. Equip weapon");
                Console.WriteLine("  3. Exit equipment menu");
                Console.Write("Select a choice from the menu: ");
                string equipChoice = Console.ReadLine();
                if (equipChoice == "1")
                {
                    Console.Clear();
                    EquipArmor();
                }
                else if (equipChoice == "2")
                {
                    Console.Clear();
                    EquipWeapon();
                }
            }
        }
    }

    //Previously the "AcquireSkill" method
    private void SkillMenu()
    {
        Console.Clear();
        Console.WriteLine("Skill menu:");
        Console.WriteLine("  1. View your skills");
        Console.WriteLine("  2. View all skills");
        Console.WriteLine("  3. Acquire skill");
        Console.Write("Select a choice from the menu: ");
        string userInput = Console.ReadLine();

        if (userInput == "1")
        {
            try
            {
                int skillChoice = 0;
                while (skillChoice < _skills.Count())
                {
                    Console.Clear();
                    int listNum = 0;
                    foreach (string[] skill in _skills)
                    {
                        listNum += 1;
                        Console.WriteLine($"  {listNum}. {skill[0]}");
                    }
                    Console.WriteLine("  Enter. exit skill menu");
                    Console.Write("Select a skill to view its description: ");
                    skillChoice = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine($"\n{_skills[skillChoice][0]}");
                    Console.WriteLine(_skills[skillChoice][1]);
                    Console.Write("Press enter to continue:");
                    Console.ReadLine();
                }
            } catch {}
        }
        else if (userInput == "2")
        {
            try
            {
                List<string[]> allSkills = AllSkills();
                int skillChoice = 0;
                while (skillChoice < allSkills.Count())
                {
                    Console.Clear();
                    int listNum = 0;
                    foreach (string[] skill in allSkills)
                    {
                        listNum += 1;
                        Console.WriteLine($"  {listNum}. {skill[0]}");
                    }
                    Console.WriteLine("  Enter. exit skill menu");
                    Console.Write("Select a skill to view its description: ");
                    skillChoice = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine($"\n{allSkills[skillChoice][0]}");
                    Console.WriteLine(allSkills[skillChoice][1]);
                    Console.Write("Press enter to continue:");
                    Console.ReadLine();
                }
            } catch {}
        }
        else if (userInput == "3")
        {
        try
            {
                int skillChoice = 0;
                while (skillChoice < _unclaimedSkills.Count())
                {
                    Console.Clear();
                    int listNum = 0;
                    foreach (string[] skill in _unclaimedSkills)
                    {
                        listNum += 1;
                        Console.WriteLine($"  {listNum}. {skill[0]} cost: {skill[2]}");
                    }
                    Console.WriteLine("  Enter. exit skill menu");
                    Console.WriteLine("To acquire a skill, you must have xp equal to or greater than its cost");
                    Console.Write("Select a skill to acquire: ");
                    skillChoice = int.Parse(Console.ReadLine()) - 1;
                    int skillCost = int.Parse(_unclaimedSkills[skillChoice][2]);
                    if (_xp >= skillCost)
                    {
                        _xp -= skillCost;
                        Console.WriteLine($"You have acquired {_unclaimedSkills[skillChoice][0]}");
                        _skills.Add(_unclaimedSkills[skillChoice]);
                        _unclaimedSkills.RemoveAt(skillChoice);
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough experience");
                    }
                    Console.Write("Press enter to continue:");
                    Console.ReadLine();
                }
            } catch {}
        }
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
        try
        {
            Console.Write("Select the item you'd like to equip: ");
            _equipedArmor = armorList[int.Parse(Console.ReadLine()) - 1];
        } catch {}
    }

    private void EquipWeapon()
    {
        List<string[]> weaponList = new List<string[]>();
        foreach (string[] item in _equipment)
        {
            if (item[1] == "weapon")
            {
                weaponList.Add(item);
            }
        }
        int listNum = 0;
        foreach (string[] item in weaponList)
        {
            listNum += 1;
            Console.WriteLine($"  {listNum}. {item[0]}");
        }
        try
        {
            Console.Write("Select the item you'd like to equip: ");
            _equipedWeapon = weaponList[int.Parse(Console.ReadLine()) - 1];
        } catch {}
    }

    private List<string[]> AllSkills()
    {
        //Skills are formatted: name, description, type, value (if any), experience cost
        List<string[]> allSkills = new List<string[]>();
        allSkills.Add(AddSkillArray("Iron Skin", "Reduces all damage dealt to you by a set amount", "protection", "10", "20"));
        allSkills.Add(AddSkillArray("Grapple", "A physical attack, has a chance of stunning the target", "attack", "4", "10"));
        /*allSkills.Add(AddSkillArray("2", "description", "10"));
        allSkills.Add(AddSkillArray("3", "description", "10"));
        allSkills.Add(AddSkillArray("4", "description", "10"));
        allSkills.Add(AddSkillArray("5", "description", "10"));
        allSkills.Add(AddSkillArray("6", "description", "10"));
        allSkills.Add(AddSkillArray("7", "description", "10"));
        allSkills.Add(AddSkillArray("8", "description", "10"));
        allSkills.Add(AddSkillArray("9", "description", "10"));*/

        return allSkills;
    }

    //I couldn't find how to initialize an array with all it's content while
    //adding it to a list, so I decided to create a simple function to handle it.
    private string[] AddSkillArray(string name, string description, string type, string value, string cost)
    {
        string[] skillArray = {name, description, type, value, cost};
        return skillArray;
    }

    public void CalculateHealth(int damage)
    {
        _health -= damage;
    }

    /*Getters and setters*/
    public void AddEquipment(string[] equipment)
    {
        _equipment.Add(equipment);
    }

    public List<string[]> GetSkills()
    {
        return _skills;
    }

    public int GetAttack()
    {
        return _attack;
    }

    public int GetDefense()
    {
        return _defense;
    }

    public string[] GetEquipedWeapon()
    {
        return _equipedWeapon;
    }

    public string[] GetEquipedArmor()
    {
        return _equipedArmor;
    }
}