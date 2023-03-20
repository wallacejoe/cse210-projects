using System;
public abstract class Combat
{
    private List<string> _activeEffects = new List<string>();

    /*Constructors*/

    /*Methods*/
    public void CombatMenu()
    {

    }

    public void CombatAI()
    {

    }

    public void CombatEffects()
    {

    }

    public abstract int CalculateAttack();

    public abstract int CalculateDefense();

    public abstract void CombatResults();
}