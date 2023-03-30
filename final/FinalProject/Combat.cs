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
    private List<Loot> _newLoot = new List<Loot>();
    /*Constructors*/

    /*Methods*/
    public List<Mob> CombatMenu(Character player, List<Mob> mobs)
    {
        string userInput = "";
        while (userInput != "4" && player.GetHealth() > 0)
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
                try
                {
                    int mobTarget = ChooseTarget(mobs);
                    Mob defendingMob = mobs[mobTarget];
                    bool result = CombatResults(defendingMob, player);
                    foreach (Mob mob in mobs)
                    {
                        CombatAI(player, mob);
                    }
                    if (!result)
                    {
                        _newLoot.Add(new MobLoot(mobs[mobTarget].GetMobType()));
                        mobs.RemoveAt(mobTarget);
                    }
                } catch {}
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
                foreach (Mob mob in mobs)
                {
                    CombatAI(player, mob);
                }
            }
            else if (userInput == "3")
            {

            }
        }
        return mobs;
    }

    public void CombatAI(Character player, Mob mob)
    {
        int attack = CalculateAttack(mob.GetAttack());
        int defense = CalculateDefense(player.GetDefense());
        int damage = mob.GetDamage();
        attack -= defense;
        if (attack > 0)
        {
            attack += damage;
            player.DecreaseHealth(damage);
            Console.WriteLine($"{mob.GetMobType()} dealt {attack} damage");
            Console.Write("Press enter to continue: ");
            Console.ReadLine();
        }
    }

    public void CombatEffects()
    {

    }

    private int CalculateAttack(int attack, string effect="")
    {
        Random getRandomNum = new Random();
        int attackValue = getRandomNum.Next(0, attack);
        return attackValue;
    }

    private int CalculateDefense(int defense, string effect="")
    {
        Random getRandomNum = new Random();
        int defenseValue = getRandomNum.Next(0, defense);
        return defenseValue;
    }

    private int ChooseTarget(List<Mob> mobs)
    {
        Console.Clear();
        int listNum = 0;
        foreach (Mob mob in mobs)
        {
            Console.WriteLine($"  {listNum += 1}. {mob.GetMobType()}  HP: {mob.GetHealth()}");
        }
        Console.Write("Select the mob you would like to attack: ");
        int mobTarget = int.Parse(Console.ReadLine()) - 1;
        return mobTarget;
    }

    private bool CombatResults(Mob mob, Character player)
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
            Console.WriteLine($"You dealt {attack} damage");
            Console.Write($"Press enter to continue:");
            Console.ReadLine();
            if (!mob.GetState())
            {
                return false;
            }
        }
        return true;
    }

    public List<Loot> GetNewLoot()
    {
        List<Loot> lootToAdd = _newLoot;
        _newLoot.Clear();
        return lootToAdd;
    }
}