using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : PlayerCharacter // Inheritance
{
    readonly int healAmount = 5;

    public override int DealDamage() // Polymorphism
    {
        Heal(healAmount);
        return base.DealDamage();
    }

    void Heal(int healAmount)
    {
        if (Random.Range(0, 10) <= 2)
        {
            currentHealth += healAmount;
            UIManager.instance.HealthUIHandler(currentHealth);
        }
    }
}
