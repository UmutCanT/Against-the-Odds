using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : PlayerCharacter
{
    readonly int critMultiplier = 3;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UiHandlerForPlayer(currentHealth);
    }

    public override int DealDamage()
    {
        if (Random.Range(0, 10) <= 2)
        {
            return base.DealDamage() * critMultiplier;
        }
        return base.DealDamage();
    }
}
