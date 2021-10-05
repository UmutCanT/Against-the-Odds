using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : PlayerCharacter
{
    Coroutine enchantCountdown;
    int enchantMultiplier = 2;
    bool hasEnchant;

    // Start is called before the first frame update
    void Start()
    {
        hasEnchant = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override int DealDamage()
    {
        if (Random.Range(0, 10) <= 1)
        {
            if(hasEnchant != true)
            {
                damageAmount *= enchantMultiplier;
                hasEnchant = true;
            }           
            if(enchantCountdown != null)
            {
                StopCoroutine(enchantCountdown);
            }
            enchantCountdown = StartCoroutine(EnchantedPowerCoroutine());
        }

        return base.DealDamage();
    }

    IEnumerator EnchantedPowerCoroutine()
    {
        yield return new WaitForSeconds(5);
        damageAmount /= enchantMultiplier;
        hasEnchant = false;
    }
}
