using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : PlayerCharacter // Inheritance
{
    readonly int critMultiplier = 3;

    public override int DealDamage() // Polymorphism
    {
        if (Random.Range(0, 10) <= 2)
        {
            return base.DealDamage() * critMultiplier;
        }
        return base.DealDamage();
    }
}
