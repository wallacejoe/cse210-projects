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
        _mobs.Add(new Mob(_locationName));
        _loot.Add(new ChestLoot(_locationName));
    }

    public Location(string locationName, string description, List<Mob> mobs, List<Loot> loot)
    {
        _description = description;
        _locationName = locationName;
        _mobs = mobs;
        _loot = loot;
    }

    /*Methods*/
    public void LocationDescription()
    {
        Console.Clear();
        Console.WriteLine(_locationName);
        Console.WriteLine();
        Console.WriteLine(_description);
    }

    //This method returns a boolean value based on whether the user
    //has chosen to change location.
    public bool InteractionMenu(Character player)
    {
        string userInput = "";
        while (userInput != "5")
        {
            LocationDescription();
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
                List<Loot> newLoot = _combat.GetNewLoot();
                _mobs = _combat.CombatMenu(player, _mobs);
                foreach (Loot loot in newLoot)
                {
                    _loot.Add(loot);
                }
            }
            else if (userInput == "3")
            {

            }
            else if (userInput == "4")
            {
                _combat.CombatAI(player, _mobs);
                return true;
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
                Console.WriteLine("  2. Load saved game");
                Console.WriteLine("  3. Exit to main menu");
                Console.Write("Select a choice from the menu: ");
                string deathInput = Console.ReadLine();
                player.DeathReset();
                _mobs.Clear();
                _loot.Clear();
                if (deathInput == "1")
                {
                    
                }
                else if (deathInput == "2")
                {

                }
                else if (deathInput == "3")
                {
                    return false;
                }
            }
        }
        return false;
    }

    /*Getters and setters*/
    public string GetLocationName()
    {
        return _locationName;
    }
}