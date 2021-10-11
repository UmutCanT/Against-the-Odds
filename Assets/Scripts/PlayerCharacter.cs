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

    override public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }

        set
        {
            currentHealth = value;
        }
    }

    protected void UiHandlerForPlayer(int currentHp)
    {
        UIManager.instance.HealthUIHandler(currentHp);
    }

    private void Start()
    {
       
    }

    private void Update()
    {
       
    }
}
