using System;
public class Environment
{
    private Location _currentLocal;
    private int _chosenLocal = 0;
    private Character _playerCharacter;
    private List<Location> _allLocations = new List<Location>();

    /*Constructors*/
    public Environment()
    {
        InitializeStartingLocations();
        _currentLocal = _allLocations[_chosenLocal];
        _playerCharacter = new Character();
    }

    public Environment(int localNum, Character playerCharacter, List<Location> allLocations)
    {
        _playerCharacter = playerCharacter;
        _allLocations = allLocations;
        _currentLocal = _allLocations[localNum];
    }

    /*Methods*/
    public void MainMenu()
    {
        string userInput = "";
        while (userInput != "4")
        {
            Console.Clear();
            Console.WriteLine("Main menu:");
            Console.WriteLine("  1. Back to game");
            Console.WriteLine("  2. Character Menu");
            Console.WriteLine("  3. Keyboard shortcuts");
            Console.WriteLine("  4. Save and Quit");
            Console.Write("Select a choice from the menu: ");
            userInput = Console.ReadLine();

            if (userInput == "1")
            {
                bool localChange;
                do
                {
                    localChange = _currentLocal.InteractionMenu(_playerCharacter);
                    if (localChange)
                    {
                        ChangeLocation();
                    }
                } while (localChange);
            }
            else if (userInput == "2")
            {
                _playerCharacter.CharacterMenu();
            }
            else if (userInput == "3")
            {
                Console.Clear();
                Console.WriteLine("c. Character menu");
                Console.Write("Press enter to continue:");
                Console.ReadLine();
            }
            else if (userInput == "4")
            {
                List<string> saveToFile = new List<string>();
                Console.WriteLine("Leave blank if you'd like to quit without saving");
                Console.Write("Enter the file you'd like to save to: ");
                File file = new File(Console.ReadLine());
                saveToFile.Add($"current local|/^|{_chosenLocal}");
                foreach (string line in _playerCharacter.Serialize())
                {
                    saveToFile.Add(line);
                }
                foreach (Location area in _allLocations)
                {
                    foreach (string line in area.Serialize())
                    {
                        saveToFile.Add(line);
                    }
                }
                file.WriteToFile(saveToFile);
            }
            else {
                Console.Write("That input was not valid. Press enter to continue:");
                Console.ReadLine();
            }
        }
    }

    private void ChangeLocation()
    {
        Console.Clear();
        int listNum = 0;
        List<Location> locationOptions = new List<Location>();
        List<int> localNum = new List<int>();
        foreach (Location local in _allLocations)
        {
            if (listNum == _chosenLocal -1 || listNum == _chosenLocal +1)
            {
                locationOptions.Add(local);
                localNum.Add(listNum);
            }
            listNum += 1;
        }
        listNum = 0;
        foreach (Location local in locationOptions)
        {
            listNum += 1;
            Console.WriteLine($"  {listNum}. {local.GetLocationName()}");
        }
        if (_chosenLocal + 2 > _allLocations.Count())
        {
            listNum += 1;
            Console.WriteLine($"  {listNum}. New location");
        }
        Console.Write("Enter the location you'd like to move to: ");
        try
        {
            int chosenNum = int.Parse(Console.ReadLine()) - 1;
            if (chosenNum == localNum.Count())
            {
                InitializeNewLocation();
                _chosenLocal = _allLocations.Count() - 1;
                _currentLocal = _allLocations[_allLocations.Count() - 1];
            }
            else
            {
                _chosenLocal = localNum[chosenNum];
                _currentLocal = _allLocations[_chosenLocal];
            }
        } catch {}
    }

    private void InitializeStartingLocations()
    {
        _allLocations.Add(new Location("forest", "A dense forest, thick enough to block most light, unnerving sounds eminate from the trees around you."));
        _allLocations.Add(new Location("swamp", "This foul bog reeks of death and decay, and has several steaming pools of some unknown substance. Aside from a constant hiss from the pools, the swamp is unnaturally silent."));
        _allLocations.Add(new Location("mage tower", "A large mystical tower, might not want to spend too much time here."));
    }

    private void InitializeNewLocation()
    {
        Random getRandomNum = new Random();
        List<string[]> locations = new List<string[]>();
        locations.Add(AddArray("forest", "A dense forest, thick enough to block most light, unnerving sounds eminate from the trees around you."));
        locations.Add(AddArray("swamp", "This foul bog reeks of death and decay, and has several steaming pools of some unknown substance. Aside from a constant hiss from the pools, the swamp is unnaturally silent."));
        locations.Add(AddArray("mage tower", "A large mystical tower, might not want to spend too much time here."));
        
        int randomNum = getRandomNum.Next(0, locations.Count());
        string[] chosenLocal = locations[randomNum];
        _allLocations.Add(new Location(chosenLocal[0], chosenLocal[1]));
    }

    private string[] AddArray(string name, string description)
    {
        string[] array = {name, description};
        return array;
    }

    public List<string> Serialize()
    {
        List<string> listToSerialize = new List<string>();

        return listToSerialize;
    }
}