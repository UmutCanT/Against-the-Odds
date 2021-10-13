using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour //Parent abstract class
{
    [SerializeField] protected int damageAmount;
    [SerializeField] protected int maxHealth;

    // Abstraction
    public virtual int DealDamage()
    {
        return damageAmount;
    }

    protected abstract void Dying();
 
    public abstract int CurrentHealth { get; set; }
}
