using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    [SerializeField] float moveSpeed;

    private void Start()
    {
        maxHealth = 70;
        Debug.Log("before: " + currentHealth);
        HealthAsigner(currentHealth , maxHealth);
        Debug.Log("after: " + currentHealth);
        DealDamage(currentHealth, 20);
    }

    private void Update()
    {
        Debug.Log(currentHealth);
        Debug.Log(maxHealth);
    }
}
