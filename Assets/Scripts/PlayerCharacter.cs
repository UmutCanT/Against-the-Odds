using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    [SerializeField] protected float moveSpeed;

    protected int currentHealth;

    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
    }

    public override int CurrentHealth
    {
        get
        {
            if (currentHealth < 0)
            {
                return 0;
            }
            return currentHealth;
        }

        set
        {
            currentHealth = value;
        }
    }

    // Start is called before the first frame update
    protected void Start()
    {
        currentHealth = maxHealth;
        UiHandlerForPlayer(currentHealth);
    }

    protected void Update()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Dying();
        }
    }

    protected void UiHandlerForPlayer(int currentHp)
    {
        UIManager.instance.HealthUIHandler(currentHp);
    }

    protected override void Dying()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().IsGameOver = true;
        Destroy(gameObject, 1f);
    }
}
