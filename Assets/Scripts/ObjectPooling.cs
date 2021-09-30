using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;

    public List<GameObject> projectiles = new List<GameObject>();
    [SerializeField] GameObject projectile;
    readonly int projectileAmount = 30;
    readonly int enemyAmount = 30;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CreatingObjectsToPool(projectiles, projectile, projectileAmount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatingObjectsToPool(List<GameObject> listToHold, GameObject obj, int amount)
    {
        GameObject tmp;
        for (int i = 0; i < amount; i++)
        {
            tmp = Instantiate(obj);
            tmp.SetActive(false);
            listToHold.Add(tmp);
        }
    }

    public GameObject GetPooledObjects(List<GameObject> objList, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (!objList[i].activeInHierarchy)
            {
                return objList[i];
            }
        }
        return null;
    }

    public int AmountofObject(int type)
    {
        return type switch
        {
            1 => enemyAmount,
            2 => projectileAmount,
            _ => default
        };
    }

    public void DestroyObjects(List<GameObject> list)
    {
        foreach (GameObject item in list)
        {
            Destroy(item);
        }
    }
}
