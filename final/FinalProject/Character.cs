using System;
public class Character
{
    private int _maxHealth;
    private int _health;
    private int _maxMana;
    private int _mana;
    private int _maxStamina;
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
    private List<string[]> _activeEffects = new List<string[]>();

    /*Constructors*/
    public Character()
    {
        string userInput = "";
        _xp = 10;
        _attack = 6;
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
                _maxHealth += 1;
                _health += 1;
                _xp -= 1;
            }
            else if (userInput == "2")
            {
                _maxMana += 2;
                _mana += 2;
                _xp -= 1;
            }
            else if (userInput == "3")
            {
                _maxStamina += 2;
                _stamina += 2;
                _xp -= 1;
            }
            else {Console.WriteLine("That was not a valid input");}
        }
    }

    public Character(int maxHealth, int health, int maxMana, int mana, int maxStamina, int stamina, int xp, int attack, int defense, List<string[]> skills, List<string[]> unclaimedSkills, List<string[]> spells, List<string[]> equipment)
    {
        _maxHealth = maxHealth;
        _health = health;
        _maxMana = maxMana;
        _mana = mana;
        _maxStamina = maxStamina;
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
                Console.WriteLine("  3. Use equipment");
                Console.WriteLine("  4. Exit equipment menu");
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
                else if (equipChoice == "3")
                {
                    Console.Clear();
                    int listNum = 0;
                    foreach (string[] item in _equipment)
                    {
                        listNum += 1;
                        Console.WriteLine($"  {listNum}. {item[0]}");
                    }
                    Console.WriteLine("Select an item to use: ");
                    try
                    {
                        int chosenItem = int.Parse(Console.ReadLine()) - 1;
                        string[] chosenEquipment = _equipment[chosenItem];
                        if (chosenEquipment[1] == "healing")
                        {
                            int healing = int.Parse(chosenEquipment[2]);
                            IncreaseHealth(healing);
                            _equipment.RemoveAt(chosenItem);
                        }
                        else if (chosenEquipment[1] == "poison")
                        {
                            Console.Write($"Would you like to poison {_equipedWeapon} (y/n)? ");
                            if (Console.ReadLine() == "y")
                            {
                                _equipedWeapon[3] = "poison";
                            }
                        }
                    } catch{}
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
                        Console.WriteLine($"  {listNum}. {skill[0]} cost: {skill[5]}");
                    }
                    Console.WriteLine("  Enter. exit skill menu");
                    Console.WriteLine("To acquire a skill, you must have xp equal to or greater than its cost");
                    Console.Write("Select a skill to acquire: ");
                    skillChoice = int.Parse(Console.ReadLine()) - 1;
                    int skillCost = int.Parse(_unclaimedSkills[skillChoice][5]);
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
        //Skills are formatted: name, description, type, value (if any), stamina cost (if any), experience cost, effect (if any)
        List<string[]> allSkills = new List<string[]>();
        allSkills.Add(AddSkillArray("Stone Skin", "Reduces all damage dealt to you by a set amount", "protection", "1", "0", "20", ""));
        allSkills.Add(AddSkillArray("Grapple", "A physical attack, has a chance of stunning the target", "attack", "3", "2", "10", "stun"));
        allSkills.Add(AddSkillArray("Dodge", "Allows you to perform a \"Dogde\" that increases your defense", "Defense", "2", "1", "5", ""));
        allSkills.Add(AddSkillArray("Rage", "You fly into a rage, causing your attacks to deal increased damage", "attack", "3", "5", "20", "rage"));
        allSkills.Add(AddSkillArray("Deception", "Decrease all opponents attack by confusing them", "cunning", "0", "2", "20", "confusion"));

        return allSkills;
    }

    //I couldn't find how to initialize an array with all it's content while
    //adding it to a list, so I decided to create a simple function to handle it.
    private string[] AddSkillArray(string name, string description, string type, string value, string cost, string xpCost, string effect)
    {
        string[] skillArray = {name, description, type, value, cost, xpCost, effect};
        return skillArray;
    }

    public void DecreaseHealth(int damage)
    {
        _health -= damage;
    }

    public void IncreaseHealth(int healing)
    {
        _health += healing;
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    public void IncreaseXP(int xp)
    {
        _xp += xp;
    }

    public void DeathReset()
    {
        _xp = 0;
        _health = _maxHealth;
        _stamina = _maxStamina;
        _mana = _maxMana;
    }

    public void AddEquipment(string[] equipment)
    {
        _equipment.Add(equipment);
    }

    public void AddActiveEffects(string name, string value)
    {
        string[] effect = {name, value};
        _activeEffects.Add(effect);
    }

    /*Getters and setters*/

    public List<string[]> GetActiveEffects()
    {
        return _activeEffects;
    }

    public void SetActiveEffects(List<string[]> newEffects)
    {
        _activeEffects = newEffects;
    }

    public int GetHealth()
    {
        return _health;
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

    public int GetStamina()
    {
        return _stamina;
    }

    public void SetStamina(int stamina)
    {
        _stamina = stamina;
    }

    public int GetMana()
    {
        return _mana;
    }

    public void SetMana(int mana)
    {
        _mana = mana;
    }

    public string[] GetEquipedWeapon()
    {
        return _equipedWeapon;
    }

    public void SetEquipedWeapon(string[] weapon)
    {
        _equipedWeapon = weapon;
    }

    public string[] GetEquipedArmor()
    {
        return _equipedArmor;
    }
}