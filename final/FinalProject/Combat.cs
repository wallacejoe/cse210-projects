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
    //I realized it was better to track active effects in each individual class
    //private List<string[]> _activeEffects = new List<string[]>();
    private int _increasedPlayerDefense = 0;
    private List<Loot> _newLoot = new List<Loot>();
    /*Constructors*/

    /*Methods*/
    public List<Mob> CombatMenu(Character player, List<Mob> mobs)
    {
        string userInput = "";
        while (userInput != "4" && player.GetHealth() > 0)
        {
            Console.Clear();
            player.DisplayStatLine();
            Console.WriteLine("Combat menu:");
            Console.WriteLine("  1. Basic Attack");
            Console.WriteLine("  2. Combat Skill");
            Console.WriteLine("  3. Combat Spell");
            Console.WriteLine("  4. Exit combat menu");
            Console.Write("Select a choice from the menu: ");
            userInput = Console.ReadLine();
            bool incapacitated = false;
            foreach (string[] effect in player.GetActiveEffects())
            {
                if (effect[0] == "stun")
                {
                    incapacitated = true;
                }
            }
            if (!incapacitated)
            {
                if (userInput == "1")
                {
                    try
                    {
                        int mobTarget = ChooseTarget(mobs);
                        Mob defendingMob = mobs[mobTarget];
                        int damage = 0;
                        int playerAttack = CalculateAttack(player.GetAttack());
                        foreach (string[] effect in player.GetActiveEffects())
                        {
                            if (effect[0] == "rage")
                            {
                                playerAttack += 2;
                            }
                            if (effect[0] == "confusion")
                            {
                                playerAttack -= 2;
                            }
                        }
                        try
                        {
                            string[] equipedWeapon = player.GetEquipedWeapon();
                            damage = int.Parse(equipedWeapon[2]);
                            if (equipedWeapon[3] == "poison")
                            {
                                equipedWeapon[3] = "";
                                player.SetEquipedWeapon(equipedWeapon);
                                damage += 3;
                            }
                        } catch {}
                        bool result = CombatResults(defendingMob, playerAttack, damage);
                        CombatAI(player, mobs);
                        if (!result)
                        {
                            _newLoot.Add(new MobLoot(mobs[mobTarget].GetMobType()));
                            int gainedXP = mobs[mobTarget].GetXP();
                            player.IncreaseXP(gainedXP);
                            mobs.RemoveAt(mobTarget);
                        }
                    } catch {}
                }
                else if (userInput == "2")
                {
                    Console.Clear();
                    int listNum = 0;
                    List<string[]> combatSkills = new List<string[]>();
                    //Creates a list containing only combat skills
                    foreach (string[] skill in player.GetSkills())
                    {
                        if (skill[2] == "attack" || skill[2] == "defense" || skill[2] == "cunning")
                        {
                            combatSkills.Add(skill);
                        }
                    }
                    //Lists all combat skills
                    foreach (string[] skill in combatSkills)
                    {
                        listNum += 1;
                        Console.WriteLine($"{listNum}. {skill[0]}: {skill[5]}");
                    }
                    try
                    {
                        Console.Write("Select the skill you would like to use: ");
                        int skillChoice = int.Parse(Console.ReadLine()) - 1;
                        string[] chosenSkill = combatSkills[skillChoice];
                        if (int.Parse(chosenSkill[4]) <= player.GetStamina())
                        {
                            int afterCost = player.GetStamina() - int.Parse(chosenSkill[4]);
                            player.SetStamina(afterCost);
                            //Handles a chosen attack skill
                            if (chosenSkill[2] == "attack")
                            {
                                int mobTarget = ChooseTarget(mobs);
                                Mob defendingMob = mobs[mobTarget];
                                int damage = int.Parse(chosenSkill[3]);
                                int playerAttack = CalculateAttack(player.GetAttack(), chosenSkill[6]);
                                if (chosenSkill[6] == "stun")
                                {
                                    defendingMob.AddActiveEffects("stun", "1");
                                }
                                if (chosenSkill[6] == "rage")
                                {
                                    player.AddActiveEffects("rage", "3");
                                }
                                bool result = CombatResults(defendingMob, playerAttack, damage);
                                if (!result)
                                {
                                    _newLoot.Add(new MobLoot(mobs[mobTarget].GetMobType()));
                                    int gainedXP = mobs[mobTarget].GetXP();
                                    player.IncreaseXP(gainedXP);
                                    mobs.RemoveAt(mobTarget);
                                }
                            }
                            //Handles a chosen defense skill
                            else if (chosenSkill[2] == "defense")
                            {
                                _increasedPlayerDefense += int.Parse(chosenSkill[4]);
                            }
                            //Handles a chosen cunning skill
                            else if (chosenSkill[2] == "cunning")
                            {
                                foreach (Mob mob in mobs)
                                {
                                    mob.AddActiveEffects(chosenSkill[6], "2");
                                }
                            }

                            //Calculates the combat results of each mob in the area
                            CombatAI(player, mobs);
                        }
                        else
                        {
                            Console.WriteLine("You do not have the required stamina");
                            Console.Write("Press enter to continue:");
                            Console.ReadLine();
                        }
                    } catch{}
                }
                else if (userInput == "3")
                {
                    Console.Clear();
                    int listNum = 0;
                    List<string[]> combatSpells = new List<string[]>();
                    //Creates a list containing only combat spells
                    foreach (string[] spell in player.GetSpells())
                    {
                        if (spell[2] == "attack" || spell[2] == "defense" || spell[2] == "cunning")
                        {
                            combatSpells.Add(spell);
                        }
                    }
                    //Lists all combat spells
                    foreach (string[] spell in combatSpells)
                    {
                        listNum += 1;
                        Console.WriteLine($"{listNum}. {spell[0]}: {spell[5]}");
                    }
                    try
                    {
                        Console.Write("Select the spell you would like to use: ");
                        int spellChoice = int.Parse(Console.ReadLine()) - 1;
                        string[] chosenSpell = combatSpells[spellChoice];
                        if (int.Parse(chosenSpell[4]) <= player.GetStamina())
                        {
                            int afterCost = player.GetStamina() - int.Parse(chosenSpell[4]);
                            player.SetStamina(afterCost);
                            //Handles a chosen attack spell
                            if (chosenSpell[2] == "attack")
                            {
                                int mobTarget = ChooseTarget(mobs);
                                Mob defendingMob = mobs[mobTarget];
                                int damage = int.Parse(chosenSpell[3]);
                                int playerAttack = CalculateAttack(player.GetAttack(), chosenSpell[6]);
                                if (chosenSpell[6] == "stun")
                                {
                                    defendingMob.AddActiveEffects("stun", "1");
                                }
                                if (chosenSpell[6] == "rage")
                                {
                                    player.AddActiveEffects("rage", "3");
                                }
                                bool result = CombatResults(defendingMob, playerAttack, damage);
                                if (!result)
                                {
                                    _newLoot.Add(new MobLoot(mobs[mobTarget].GetMobType()));
                                    int gainedXP = mobs[mobTarget].GetXP();
                                    player.IncreaseXP(gainedXP);
                                    mobs.RemoveAt(mobTarget);
                                }
                            }
                            //Handles a chosen defense spell
                            else if (chosenSpell[2] == "defense")
                            {
                                _increasedPlayerDefense += int.Parse(chosenSpell[4]);
                            }
                            //Handles a chosen cunning spell
                            else if (chosenSpell[2] == "cunning")
                            {
                                foreach (Mob mob in mobs)
                                {
                                    mob.AddActiveEffects(chosenSpell[6], "2");
                                }
                            }

                            //Calculates the combat results of each mob in the area
                            CombatAI(player, mobs);
                        }
                        else
                        {
                            Console.WriteLine("You do not have the required stamina");
                            Console.Write("Press enter to continue:");
                            Console.ReadLine();
                        }
                    } catch{}
                }
            }
            else
            {
                CombatAI(player, mobs);
            }
            if (userInput == "c")
            {
                player.CharacterMenu();
            }
        }
        return mobs;
    }

    public void CombatAI(Character player, List<Mob> mobs)
    {
        foreach (Mob mob in mobs)
        {
            int attack = CalculateAttack(mob.GetAttack());
            int defense = CalculateDefense(player.GetDefense() + _increasedPlayerDefense);
            bool incapacitated = false;
            foreach (string[] effect in mob.GetActiveEffects())
            {
                if (effect[0] == "stun")
                {
                    incapacitated = true;
                }
                if (effect[0] == "confusion")
                {
                    attack -= 2;
                }
            }
            if (!incapacitated)
            {
                Random getRandomNum = new Random();
                int attackType = getRandomNum.Next(0, 2);
                int damage = mob.GetDamage();
                attack -= defense;

                //Determines what skill the mob will use
                if (attackType == 0)
                {
                    try
                    {
                        List<string[]> mobSkills = mob.GetSkills();
                        int mobChoice = getRandomNum.Next(0, mobSkills.Count());
                        string[] mobSkill = mobSkills[mobChoice];
                        damage = int.Parse(mobSkill[3]);
                        if (attack > 0)
                        {
                            if (mobSkill[4] == "stun")
                            {
                                player.AddActiveEffects("stun", "2");
                                Console.WriteLine("You have been stunned, you cannot take a combat action");
                                Console.Write("Press enter to continue");
                                Console.ReadLine();
                            }
                        }
                    } catch{}
                }

                if (attack > 0)
                {
                    damage += attack;
                    foreach (string[] skill in player.GetSkills())
                    {
                        if (skill[2] == "protection")
                        {
                            damage -= int.Parse(skill[3]);
                        }
                    }
                    try
                    {
                        int armor = int.Parse(player.GetEquipedArmor()[2]);
                        damage -= CalculateDefense(armor);
                    } catch{}
                    player.DecreaseHealth(damage);
                    Console.WriteLine($"{mob.GetMobType()} dealt {damage} damage");
                    Console.Write("Press enter to continue: ");
                    Console.ReadLine();
                }
            }
        }
        _increasedPlayerDefense = 0;
        CombatEffects(player, mobs);
    }

    public void CombatEffects(Character player, List<Mob> mobs)
    {
        //Decrease the duration of each player effect
        List<string[]> newEffects = new List<string[]>();
        foreach (string[] effect in player.GetActiveEffects())
        {
            int effectCount = int.Parse(effect[1]);
            effectCount -= 1;
            if (effectCount > 0)
            {
                effect[1] = $"{effectCount}";
                newEffects.Add(effect);
            }
        }
        player.SetActiveEffects(newEffects);
        //Decrease the duration of each mob effect
        foreach (Mob mob in mobs)
        {
            List<string[]> newMobEffects = new List<string[]>();
            foreach (string[] effect in mob.GetActiveEffects())
            {
                int effectCount = int.Parse(effect[1]);
                effectCount -= 1;
                if (effectCount > 0)
                {
                    effect[1] = $"{effectCount}";
                    newMobEffects.Add(effect);
                }
                mob.SetActiveEffects(newMobEffects);
            }
        }
    }

    //The empty string "effect" was added for potential later use
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

    private bool CombatResults(Mob mob, int attack, int damage)
    {
        int defense = CalculateDefense(mob.GetDefense());
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
        List<Loot> lootToAdd = new List<Loot>(_newLoot);
        _newLoot.Clear();
        return lootToAdd;
    }
}