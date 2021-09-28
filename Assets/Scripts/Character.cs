using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected int damageAmount;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected float shootRange;   

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual int DealDamage(int hp,int dmg)
    {
        hp-= dmg;

        Debug.Log(hp + " heeyoo");
        
        if(hp <= 0)
        {
            hp = 0;
            Dying();
        }
        return hp;
    }

    void Dying()
    {
        Debug.Log("GameOver");
    }

    public abstract int CurrentHealth { get; }
}
