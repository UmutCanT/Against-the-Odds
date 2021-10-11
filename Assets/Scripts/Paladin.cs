using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : PlayerCharacter
{
    readonly int healAmount = 5;

    void Start()
    {
        currentHealth = maxHealth;
        UiHandlerForPlayer(currentHealth);
    }

    public override int DealDamage()
    {
        Heal(healAmount);
        return base.DealDamage();
    }

    void Heal(int healAmount)
    {
        if (Random.Range(0, 10) <= 2)
        {
            currentHealth += healAmount;
        }
    }
}
