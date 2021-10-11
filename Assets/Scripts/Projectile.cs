using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameObject player;
    GameObject enemy;

    [SerializeField] float projectileSpeed;

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
}
