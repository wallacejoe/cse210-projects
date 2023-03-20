using System;
public class MobLoot : Loot
{
    private string _mob;

    /*Constructors*/
    public MobLoot(string mob)
    {
        _lootContainer = "Corpse";
        _mob = mob;
        RandomLoot();
    }

    /*Methods*/
    public override void RandomLoot()
    {
        if (_mob == "")
        {

        }
    }
}