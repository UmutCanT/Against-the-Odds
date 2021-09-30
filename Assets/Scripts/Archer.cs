using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : PlayerCharacter
{
    int critMultiplier = 3;
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;
        Debug.Log("Player " + currentHealth);
        currentHealth = DealDamage(currentHealth, damageAmount);
        Debug.Log("Player " + currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override int DealDamage(int hp, int dmg)
    {
        return base.DealDamage(hp, Crit(dmg));
    }

    int Crit(int dmg)
    {
        if (Random.Range(0, 10) <= 2)
        {
            return dmg *= critMultiplier;
        }
        return dmg;
    }
}
