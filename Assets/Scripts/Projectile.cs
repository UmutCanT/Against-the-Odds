using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameObject player;
    GameObject enemy;

    [SerializeField] float projectileSpeed;

    readonly float bulletRange = 20f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            transform.position += transform.right * projectileSpeed * Time.deltaTime;
            CheckRange();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {          
            other.gameObject.GetComponent<Enemy>().CurrentHealth -= player.GetComponent<PlayerCharacter>().DealDamage();           
        }

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerCharacter>().CurrentHealth -= enemy.GetComponent<Enemy>().DealDamage();
            UIManager.instance.HealthUIHandler(other.gameObject.GetComponent<PlayerCharacter>().CurrentHealth);
        }
        gameObject.SetActive(false);
    }

    void CheckRange()
    {
        if (transform.position.x >= bulletRange || transform.position.x <= -bulletRange)
        {
            gameObject.SetActive(false);
        } 
        
        if (transform.position.z >= bulletRange || transform.position.z <= -bulletRange)
        {
            gameObject.SetActive(false);
        }
    }
}
