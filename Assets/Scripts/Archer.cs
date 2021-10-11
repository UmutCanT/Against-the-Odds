using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : PlayerCharacter
{
    readonly int critMultiplier = 3;

    public override int DealDamage()
    {
        if (Random.Range(0, 10) <= 2)
        {
            return base.DealDamage() * critMultiplier;
        }
        return base.DealDamage();
    }
}
