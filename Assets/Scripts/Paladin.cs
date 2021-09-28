using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : PlayerCharacter
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override int DealDamage(int hp, int dmg)
    {
        Heal(dmg);
        return base.DealDamage(hp, dmg);
    }

    void Heal(int healAmount)
    {
        if(Random.Range(0,10) <= 2)
        {
            currentHealth += healAmount;
        }      
    }
}
