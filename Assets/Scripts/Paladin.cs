using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : PlayerCharacter
{
    int healAmount = 5;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

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
