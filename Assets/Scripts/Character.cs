using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected int damageAmount;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected float shootRange;
    protected int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void HealthAsigner(int currentHp, int maxHp)
    {
        currentHp = maxHp;
        Debug.Log(currentHp + " = " + maxHp);
    }

    public virtual void DealDamage(int hp,int dmg)
    {
        if(!(hp <= 0)){
            hp -= dmg;
        }
        Debug.Log(hp + "heeyoo");
        
        if(hp <= 0)
        {
            hp = 0;
            Dying();
        }
    }

    void Dying()
    {
        Debug.Log("GameOver");
    }
}
