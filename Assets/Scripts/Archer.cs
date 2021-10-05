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
    }

    // Update is called once per frame
    void Update()
    {
        
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
