using System;

//I was initially going to create combat as an abstract class, creating
//multiple classes to account for each character/mob in combat. I realized
//that would make tracking effects across multiple classes very difficult.
//It would also require multiple classes for those mobs that have different
//attack types.
//As a result, I completely restructured the Combat class, and removed the
//subclasses.
public class Combat
{
    private List<string> _activeEffects = new List<string>();

    /*Constructors*/

    /*Methods*/
    public void CombatMenu(Character player)
    {
        string userInput = "";
        while (userInput != "4")
        {
            Console.WriteLine("Combat menu:");
            Console.WriteLine("  1. Basic Attack");
            Console.WriteLine("  2. Combat Skill");
            Console.WriteLine("  3. Combat Spell");
            Console.WriteLine("  4. Exit combat menu");
            Console.Write("Select a choice from the menu: ");
            userInput = Console.ReadLine();
            
            if (userInput == "1")
            {

            }
            else if (userInput == "2")
            {
                int listNum = 0;
                List<string[]> combatSkills = new List<string[]>();
                foreach (string[] skill in player.GetSkills())
                {
                    if (skill[2] == "attack" || skill[2] == "defense")
                    {
                        combatSkills.Add(skill);
                    }
                }
                foreach (string[] skill in combatSkills)
                {
                    listNum += 1;
                    Console.WriteLine($"{listNum}. {skill[0]}: {2}");
                }
                Console.WriteLine("Select the skill you would like to use: ");
                int skillChoice = int.Parse(Console.ReadLine());
            }
            else if (userInput == "3")
            {

            }
        }
    }

    public void CombatAI()
    {

    }

    public void CombatEffects()
    {

    }

    public int CalculateAttack()
    {
        return 0;
    }

    public int CalculateDefense()
    {
        return 0;
    }

    public void CombatResults()
    {
        
    }
}