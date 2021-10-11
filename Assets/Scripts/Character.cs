using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected int damageAmount;
    [SerializeField] protected int maxHealth; 

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual int DealDamage()
    {
        return damageAmount;
    }

    protected abstract void Dying();
 
    public abstract int CurrentHealth { get; set; }
}
