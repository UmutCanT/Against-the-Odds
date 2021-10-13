using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character // Inheritance
{
    int currentHealth;
    readonly int heldPoints = 5;
    readonly float fireDelay = 2f;
    float fireInterval;

    public override int CurrentHealth // Encapsulation
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

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        fireInterval = Random.Range(2f, 5f);
        InvokeRepeating(nameof(Fire), fireDelay, fireInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.activeInHierarchy)
        {
            CancelInvoke(nameof(Fire));
        }

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Dying();
        }
    }

    protected override void Dying() // Polymorphism
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().ScoreUpdate(heldPoints);
        gameObject.SetActive(false);
        currentHealth = maxHealth;
    }

    void Fire()
    {
        GameObject fire = ObjectPooling.instance.GetPooledObjects(ObjectPooling.instance.flames, ObjectPooling.instance.AmountofObject(3));
        if (fire != null)
        {
            fire.transform.position = transform.position;
            Vector3 lookDirection = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
            fire.transform.eulerAngles = new Vector3(0, Mathf.Atan2(-lookDirection.z, lookDirection.x) * Mathf.Rad2Deg, 0);
            fire.SetActive(true);
        }
    }
}
