using System;
public class Location
{
    private List<Mob> _mobs = new List<Mob>();
    private List<Loot> _loot = new List<Loot>();
    private Combat _combat = new Combat();
    private string _description;
    private string _locationName;

    /*Constructors*/
    public Location(string locationName, string description)
    {
        _description = description;
        _locationName = locationName;
        if (locationName == "forest")
        {
            _mobs.Add(new ForestMob(_locationName));
            _loot.Add(new ChestLoot(_locationName));
        }
        else if (locationName == "swamp")
        {
            _mobs.Add(new SwampMob(_locationName));
            _mobs.Add(new SwampMob(_locationName));
            _loot.Add(new ChestLoot(_locationName));
        }
        else if (locationName == "mage tower")
        {
            _mobs.Add(new MageTowerMob(_locationName));
            _loot.Add(new ChestLoot(_locationName));
        }
    }

    public Location(string locationName, string description, List<string> mobs, List<Loot> loot)
    {
        _description = description;
        _locationName = locationName;
        foreach (string mob in mobs)
        {
            if (_locationName == "forest")
            {
                _mobs.Add(new ForestMob(mob));
            }
            else if (_locationName == "swamp")
            {
                _mobs.Add(new SwampMob(mob));
            }
            else if (_locationName == "mage tower")
            {
                _mobs.Add(new MageTowerMob(mob));
            }
        }
        _loot = loot;
    }

    /*Methods*/
    public void LocationDescription()
    {
        Console.Clear();
        Console.WriteLine(_locationName);
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.WriteLine("Mobs in this location:");
        if (_mobs.Count() <= 0)
        {
            Console.WriteLine("There are no mobs");
        }
        else
        {
            foreach (Mob mob in _mobs)
            {
                Console.WriteLine(mob.GetMobType());
            }
        }
    }

    //This method returns a boolean value based on whether the user
    //has chosen to change location.
    public bool InteractionMenu(Character player)
    {
        string userInput = "";
        while (userInput != "5")
        {
            LocationDescription();
            player.DisplayStatLine();
            Console.WriteLine($"\nLocation menu:");
            Console.WriteLine("  1. Interact with loot");
            Console.WriteLine("  2. Combat menu");
            Console.WriteLine("  3. Rest");
            Console.WriteLine("  4. Move to new location");
            Console.WriteLine("  5. Main menu");
            Console.Write("Select a choice from the menu: ");
            userInput = Console.ReadLine();

            if (userInput == "1")
            {
                try
                {
                    while (_loot.Count() > 0)
                    {
                        Console.Clear();
                        int lootNum = 0;
                        int lootInput;
                        foreach (Loot loot in _loot)
                        {
                            lootNum += 1;
                            Console.WriteLine($"  {lootNum}. {loot.GetLootContainer()}");
                        }
                        Console.WriteLine($"  {lootNum += 1}. Exit loot menu");
                        Console.Write("Select a choice from the menu: ");
                        lootInput = int.Parse(Console.ReadLine()) - 1;
                        
                        _loot[lootInput].DisplayLoot();
                        player.AddEquipment(_loot[lootInput].ClaimLoot());
                    }
                } catch {}
                _combat.CombatAI(player, _mobs);
            }
            else if (userInput == "2")
            {
                _mobs = _combat.CombatMenu(player, _mobs);
                List<Loot> newLoot = _combat.GetNewLoot();
                foreach (Loot loot in newLoot)
                {
                    _loot.Add(loot);
                }
            }
            else if (userInput == "3")
            {
                if (_mobs.Count() > 0)
                {
                    Console.Clear();
                    Console.WriteLine("You may not rest with mobs nearby");
                    Console.Write("Press enter to continue:");
                    Console.ReadLine();
                }
                else
                {
                    Random getRandomNum = new Random();
                    int randomNum = getRandomNum.Next(0, 10);
                    if (randomNum < 3)
                    {
                        _mobs.Add(new Mob(_locationName));
                        _mobs.Add(new Mob(_locationName));
                    }
                    else
                    {
                        player.IncreaseHealth(3);
                        player.SetMana(player.GetMaxMana());
                        player.SetStamina(player.GetMaxStamina());
                    }
                }
            }
            else if (userInput == "4")
            {
                _combat.CombatAI(player, _mobs);
                if (player.GetHealth() > 0)
                {
                    return true;
                }
            }
            else if (userInput == "c")
            {
                player.CharacterMenu();
            }
            if (player.GetHealth() <= 0)
            {
                Console.Clear();
                Console.WriteLine("You have been defeated");
                Console.WriteLine("  1. Respawn");
                Console.WriteLine("  2. Exit to main menu");
                Console.Write("Select a choice from the menu: ");
                string deathInput = Console.ReadLine();
                player.DeathReset();
                _mobs.Clear();
                _loot.Clear();
                if (deathInput == "2")
                {
                    return false;
                }
            }
        }
        return false;
    }

    public List<string> Serialize()
    {
        List<string> allToSerialize = new List<string>();
        string toSerialize = "mobs";
        foreach (Mob mob in _mobs)
        {
            toSerialize += $"|/^|{mob.GetMobType()}";
        }
        allToSerialize.Add(toSerialize);
        foreach (Loot loot in _loot)
        {
            foreach (string item in loot.Serialize())
            {
                allToSerialize.Add(item);
            }
        }
        allToSerialize.Add($"location|/^|{_locationName}|/^|{_description}");
        return allToSerialize;
    }

    /*Getters and setters*/
    public string GetLocationName()
    {
        return _locationName;
    }
}