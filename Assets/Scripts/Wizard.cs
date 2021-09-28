using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : PlayerCharacter
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public override int DealDamage(int hp, int dmg)
    //{
    //    if (Random.Range(0,10) <= 2)
    //    {
    //        StartCoroutine(Toxic());
    //    }

    //    return base.DealDamage(hp, dmg);
    //}

    //IEnumerator Toxic(GameObject enemy)
    //{
    //    yield return new WaitForSeconds(5);
    //    enemy.GetComponent<Enemy>().DealDamage(currentHealth, 5);
    //}
}
