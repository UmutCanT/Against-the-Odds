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
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Dying(gameObject);
        }

        if (!gameObject.activeInHierarchy)
        {
            currentHealth = maxHealth;
        }
    }
}
