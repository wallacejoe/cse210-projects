using System;
public class MobLoot : Loot
{
    private string _mob;

    /*Constructors*/
    public MobLoot(string mob)
    {
        _mob = mob;
    }

    /*Methods*/
    public override List<string> RandomLoot()
    {

    }
}