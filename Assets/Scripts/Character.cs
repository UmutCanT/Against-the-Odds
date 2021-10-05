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

    public virtual int DealDamage()
    {
        return damageAmount;
    }

    protected void Dying(GameObject character)
    {
        if (character.CompareTag("Player"))
        {
            Debug.Log("GameOver");
        }

        if (character.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }    
    }

    public abstract int CurrentHealth { get; set; }
}
