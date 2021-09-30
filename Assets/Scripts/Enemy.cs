using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    int currentHealth;

    override public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }

        set
        {
            currentHealth = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Enemy " + currentHealth);
        currentHealth = DealDamage(maxHealth, damageAmount);
        Debug.Log("Enemy " + currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
