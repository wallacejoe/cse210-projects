using System;
public class File
{
    private string _filename;
    private List<int> _characterStats;
    private List<string[]> _skills = new List<string[]>();
    private List<string[]> _unSkills = new List<string[]>();
    private List<string[]> _spells = new List<string[]>();
    private List<string[]> _equipment = new List<string[]>();
    private string[] _equipedWeapon;
    private string[] _equipedArmor;
    private List<Location> _locations = new List<Location>();
    private List<string> _mobs = new List<string>();
    private List<Loot> _loot = new List<Loot>();
    private List<string[]> _items = new List<string[]>();
    private string _container;
    private int _localNum;

    /*Constructors*/
    public File(string filename)
    {
        _filename = filename;
    }

    /*Methods*/
    public void WriteToFile(List<string> lines)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(_filename))
            foreach (string line in lines)
            {
                outputFile.WriteLine(line);
            }
        } catch {Console.WriteLine("Error: Could not save to the chosen file.");}
    }

    public void Deserialize()
    {
        try
        {
            string[] lines = System.IO.File.ReadAllLines(_filename);
            int locationNum = -1;

            foreach (string line in lines)
            {
                /*Deserialize Character*/
                string[] splitLine = line.Split("|/^|");
                if (splitLine[0] == "character")
                {
                    _characterStats = new List<int>{int.Parse(splitLine[1]), int.Parse(splitLine[2]), int.Parse(splitLine[3]), int.Parse(splitLine[4]), int.Parse(splitLine[5]), int.Parse(splitLine[6]), int.Parse(splitLine[7]), int.Parse(splitLine[8]), int.Parse(splitLine[9])};
                }
                else if (splitLine[0] == "skill")
                {
                    _skills.Add(splitLine.Skip(1).ToArray());
                }
                else if (splitLine[0] == "un-skill")
                {
                    _unSkills.Add(splitLine.Skip(1).ToArray());
                }
                else if (splitLine[0] == "spell")
                {
                    _spells.Add(splitLine.Skip(1).ToArray());
                }
                else if (splitLine[0] == "equipment")
                {
                    _equipment.Add(splitLine.Skip(1).ToArray());
                }
                else if (splitLine[0] == "equiped weapon")
                {
                    _equipedWeapon = splitLine.Skip(1).ToArray();
                }
                else if (splitLine[0] == "equiped armor")
                {
                    _equipedArmor = splitLine.Skip(1).ToArray();
                }
                /*Deserialize Locations*/
                else if (splitLine[0] == "mobs")
                {
                    splitLine = splitLine.Skip(1).ToArray();
                    foreach (string mob in splitLine)
                    {
                        _mobs.Add(mob);
                    }
                }
                else if (splitLine[0] == "container")
                {
                    _container = splitLine[1];
                    List<string[]> newItems = new List<string[]>(_items);
                    if (_container == "Chest")
                    {
                        _loot.Add(new ChestLoot(newItems, _container));
                    }
                    else if (_container == "Corpse")
                    {
                        _loot.Add(new MobLoot(newItems, _container));
                    }
                    _items.Clear();
                }
                else if (splitLine[0] == "loot")
                {
                    _items.Add(splitLine.Skip(1).ToArray());
                }
                else if (splitLine[0] == "location")
                {
                    List<string> newMobs = new List<string>(_mobs);
                    List<Loot> newLoot = new List<Loot>(_loot);
                    locationNum += 1;
                    _locations.Add(new Location(splitLine[1], splitLine[2], newMobs, newLoot));
                    _mobs.Clear();
                    _loot.Clear();
                }
                else if (splitLine[0] == "current local")
                {
                    _localNum = int.Parse(splitLine[1]);
                }
            }
        } catch {
            Console.WriteLine("Error: could not load the chosen file.");
        }
    }

    public Character CreateCharacterClass()
    {
        Character _character = new Character(_characterStats[0], _characterStats[1], _characterStats[2], _characterStats[3], _characterStats[4], _characterStats[5], _characterStats[6], _characterStats[7], _characterStats[8], _skills, _unSkills, _spells, _equipment, _equipedWeapon, _equipedArmor);
        return _character;
    }

    public List<Location> CreateLocationClasses()
    {
        return _locations;
    }

    public int GetLocalNum()
    {
        return _localNum;
    }
}