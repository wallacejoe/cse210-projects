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
        _maxHealth = 5;
        _health = 5;
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

    public Character(int maxHealth, int health, int maxMana, int mana, int maxStamina, int stamina, int xp, int attack, int defense, List<string[]> skills, List<string[]> unclaimedSkills, List<string[]> spells, List<string[]> equipment, string[] equipedWeapon, string[] equipedArmor)
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
        _equipedWeapon = equipedWeapon;
        _equipedArmor = equipedArmor;
    }

    /*Methods*/
    public void CharacterMenu()
    {
        string userInput = "";
        while (userInput != "6")
        {
            Console.Clear();
            Console.WriteLine("Character menu:");
            Console.WriteLine("  1. Character stats");
            Console.WriteLine("  2. Character skills");
            Console.WriteLine("  3. Character spells");
            Console.WriteLine("  4. Character equipment");
            Console.WriteLine("  5. Character level-up");
            Console.WriteLine("  6. Exit Character menu");
            Console.Write("Select a choice from the menu: ");
            userInput = Console.ReadLine();

            if (userInput == "1")
            {
                Console.Clear();
                Console.WriteLine($"Health: {_health}/{_maxHealth}");
                Console.WriteLine($"Mana: {_mana}/{_maxMana}");
                Console.WriteLine($"Stamina: {_stamina}/{_maxStamina}");
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
                SpellMenu();
            }
            else if (userInput == "4")
            {
                EquipmentMenu();
            }
            else if (userInput == "5")
            {
                Console.WriteLine("Available stats:");
                Console.WriteLine("  1. Health cost: 10xp");
                Console.WriteLine("  2. Mana cost: 5xp");
                Console.WriteLine("  3. Stamina cost: 5xp");
                if (_attack < 10)
                {
                    Console.WriteLine("  4. Attack cost: 25xp");
                }
                if (_defense < 10)
                {
                    Console.WriteLine("  5. Defense cost: 25xp");
                }
                Console.WriteLine("Enter. Back to game");
                Console.Write("Select a stat to level up: ");
                string levelInput = Console.ReadLine();
                if (levelInput == "1" && _xp >= 10)
                {
                    _xp -= 10;
                    _maxHealth += 1;
                    _health += 1;
                }
                else if (levelInput == "2" && _xp >= 5)
                {
                    _xp -= 5;
                    _maxMana += 1;
                    _mana += 1;
                }
                else if (levelInput == "3" && _xp >= 5)
                {
                    _xp -= 5;
                    _maxStamina += 1;
                    _stamina += 1;
                }
                else if (levelInput == "4" && _xp >= 25 && _attack < 10)
                {
                    _xp -= 25;
                    _attack += 1;
                }
                else if (levelInput == "5" && _xp >= 25 && _defense < 10)
                {
                    _xp -= 25;
                    _defense += 1;
                }
                else if (levelInput == "1" || levelInput == "2" || levelInput == "3" || levelInput == "4" || levelInput == "5")
                {
                    Console.WriteLine("You don't have enough experience");
                    Console.Write("Press enter to conitnue:");
                    Console.ReadLine();
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

    private void SpellMenu()
    {
        Console.Clear();
        Console.WriteLine("Spell menu:");
        Console.WriteLine("  1. View your spells");
        Console.WriteLine("  2. Use spell");
        Console.Write("Select a choice from the menu: ");
        string userInput = Console.ReadLine();

        if (userInput == "1")
        {
            try
            {
                int spellChoice = 0;
                while (spellChoice < _spells.Count())
                {
                    Console.Clear();
                    int listNum = 0;
                    foreach (string[] spell in _spells)
                    {
                        listNum += 1;
                        Console.WriteLine($"  {listNum}. {spell[0]}");
                    }
                    Console.WriteLine("  Enter. exit spell menu");
                    Console.Write("Select a spell to view its description: ");
                    spellChoice = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine($"\n{_spells[spellChoice][0]}");
                    Console.WriteLine(_spells[spellChoice][1]);
                    Console.Write("Press enter to continue:");
                    Console.ReadLine();
                }
            } catch {}
        }
        else if (userInput == "2")
        {
            Console.Clear();
            int listNum = 0;
            foreach (string[] spell in _spells)
            {
                listNum += 1;
                Console.WriteLine($"  {listNum}. {spell[0]}");
            }
            Console.Write("Select a spell to use: ");
            try
            {
                int chosenSpellNum = int.Parse(Console.ReadLine()) - 1;
                string[] chosenSpell = _spells[chosenSpellNum];
                if (_mana >= int.Parse(chosenSpell[4]))
                {
                    _mana -= int.Parse(chosenSpell[4]);
                    if (chosenSpell[2] == "healing")
                    {
                        int healing = int.Parse(chosenSpell[3]);
                        IncreaseHealth(healing);
                    }
                }
                else
                {
                    Console.WriteLine("You don't have enough mana for this spell");
                }
            } catch{}
        }
    }

    private void EquipmentMenu()
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
                    Console.Write($"Would you like to poison {_equipedWeapon[0]} (y/n)? ");
                    if (Console.ReadLine() == "y")
                    {
                        _equipedWeapon[3] = "poison";
                    }
                }
                else if (chosenEquipment[1] == "spell")
                {
                    bool alreadyHave = false;
                    foreach (string[] spell in _spells)
                    {
                        if (spell[0] == chosenEquipment[0])
                        {
                            alreadyHave = true;
                        }
                    }
                    if (alreadyHave)
                    {
                        Console.WriteLine("You already know this spell");
                        Console.Write("Press enter to continue:");
                        Console.ReadLine();
                    }
                    else
                    {
                        _spells.Add(AddSpellArray(chosenEquipment[0], chosenEquipment[4], chosenEquipment[6], chosenEquipment[2], chosenEquipment[5], chosenEquipment[3]));
                    }
                }
            } catch{}
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

    public void DisplayStatLine()
    {
        Console.WriteLine($"HP:{_health}/{_maxHealth} Mana:{_mana}/{_maxMana} Stamina:{_stamina}/{_maxStamina} XP:{_xp}");
    }

    //I couldn't find how to initialize an array with all it's content while
    //adding it to a list, so I decided to create a simple function to handle it.
    private string[] AddSkillArray(string name, string description, string type, string value, string cost, string xpCost, string effect)
    {
        string[] skillArray = {name, description, type, value, cost, xpCost, effect};
        return skillArray;
    }

    private string[] AddSpellArray(string name, string description, string type, string value, string cost, string effect)
    {
        string[] spellArray = {name, description, type, value, cost, effect};
        return spellArray;
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

    public List<string> Serialize()
    {
        List<string> listToSerialize = new List<string>();
        listToSerialize.Add($"character|/^|{_maxHealth}|/^|{_health}|/^|{_maxMana}|/^|{_mana}|/^|{_maxStamina}|/^|{_stamina}|/^|{_xp}|/^|{_attack}|/^|{_defense}");
        try
        {
            foreach (string line in SerializeArray(_skills, "skill"))
            {
                listToSerialize.Add(line);
            }
        } catch{}
        try
        {
            foreach (string line in SerializeArray(_unclaimedSkills, "un-skill"))
            {
                listToSerialize.Add(line);
            }
        } catch{}
        try
        {
            foreach (string line in SerializeArray(_spells, "spell"))
            {
                listToSerialize.Add(line);
            }
        } catch{}
        try
        {
            foreach (string line in SerializeArray(_equipment, "equipment"))
            {
                listToSerialize.Add(line);
            }
        } catch{}
        try
        {
            string serializeWeapon = "equiped weapon";
            foreach (string line in _equipedWeapon)
            {
                serializeWeapon += $"|/^|{line}";
            }
        } catch{}
        try
        {
            string serializeArmor = "equiped armor";
            foreach (string line in _equipedArmor)
            {
                serializeArmor += $"|/^|{line}";
            }
        } catch{}

        return listToSerialize;
    }

    private List<string> SerializeArray(List<string[]> list, string identifier)
    {
        List<string> serializedList = new List<string>();
        foreach (string[] array in list)
        {
            string serialized = $"{identifier}";
            foreach (string value in array)
            {
                serialized += $"|/^|{value}";
            }
            serializedList.Add(serialized);
        }
        return serializedList;
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

    public List<string[]> GetSpells()
    {
        return _spells;
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

    public int GetMaxStamina()
    {
        return _maxStamina;
    }

    public void SetStamina(int stamina)
    {
        _stamina = stamina;
    }

    public int GetMaxMana()
    {
        return _maxMana;
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