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
    private List<string[]> _activeEffects = new List<string[]>();

    /*Constructors*/

    /*Methods*/
    public void CombatMenu(Character player, List<Mob> mobs)
    {
        string userInput = "";
        while (userInput != "4")
        {
            Console.Clear();
            Console.WriteLine("Combat menu:");
            Console.WriteLine("  1. Basic Attack");
            Console.WriteLine("  2. Combat Skill");
            Console.WriteLine("  3. Combat Spell");
            Console.WriteLine("  4. Exit combat menu");
            Console.Write("Select a choice from the menu: ");
            userInput = Console.ReadLine();
            
            if (userInput == "1")
            {
                Mob defendingMob = ChooseTarget(mobs);
                CombatResults(defendingMob, player);
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
                Console.Write("Select the skill you would like to use: ");
                int skillChoice = int.Parse(Console.ReadLine());
                string[] chosenSkill = combatSkills[skillChoice];
            }
            else if (userInput == "3")
            {

            }
        }
    }

    public void CombatAI(Character player, List<Mob> mobs)
    {
        foreach (Mob mob in mobs)
        {
            int attack = CalculateAttack(mob.GetAttack());
            int defense = CalculateDefense(player.GetDefense());
            int damage = mob.GetDamage();
            attack -= defense;
            if (attack > 0)
            {
                attack += damage;
                player.CalculateHealth(damage);
            }
        }
    }

    public void CombatEffects()
    {

    }

    public int CalculateAttack(int attack, string effect="")
    {
        Random getRandomNum = new Random();
        int attackValue = getRandomNum.Next(0, attack);
        return attackValue;
    }

    public int CalculateDefense(int defense, string effect="")
    {
        Random getRandomNum = new Random();
        int defenseValue = getRandomNum.Next(0, defense);
        return defenseValue;
    }

    private Mob ChooseTarget(List<Mob> mobs)
    {
        Console.Clear();
        int listNum = 0;
        foreach (Mob mob in mobs)
        {
            Console.WriteLine($"  {listNum += 1}. {mob.GetMobType()}  HP: {mob.GetHealth()}");
        }
        Console.Write("Select the mob you would like to attack: ");
        int mobTarget = int.Parse(Console.ReadLine()) - 1;
        Mob targetMob = mobs[mobTarget];
        return targetMob;
    }

    public void CombatResults(Mob mob, Character player)
    {
        int attack = CalculateAttack(player.GetAttack());
        int defense = CalculateDefense(mob.GetDefense());
        int damage = 0;
        try
        {
            string[] equipedWeapon = player.GetEquipedWeapon();
            damage = int.Parse(equipedWeapon[2]);
        } catch {}
        attack -= defense;
        if (attack > 0)
        {
            attack += damage;
            mob.CalculateDamage(attack);
        }
    }
}