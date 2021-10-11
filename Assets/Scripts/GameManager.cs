using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] GameObject[] characters = new GameObject[3];

    //Enemy Spawn variables
    readonly float spawnInterval = 2f;
    readonly float spawnDelay = 5f;
    readonly float xRangeEnemy = 19f;
    readonly float zRangeEnemy = 18f;

    bool isGameOver = false;

    int score;

    Vector3 playerSpawnPos = Vector3.up;

    public bool IsGameOver
    {
        get
        {
            return isGameOver;
        }

        set
        {
            isGameOver = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ScoreUpdate(score);
        if (!isGameOver)
        {
#if UNITY_EDITOR
            GameObject player = Instantiate(characters[1], playerSpawnPos, Quaternion.identity);
            player.AddComponent<PlayerController>();
            InvokeRepeating(nameof(SpawnEnemy), spawnDelay, spawnInterval);
#else
            GameObject player = Instantiate(characters[DataManager.instance.CharID], playerSpawnPos, Quaternion.identity);
            player.AddComponent<PlayerController>();
#endif
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            GameOver();
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = ObjectPooling.instance.GetPooledObjects(ObjectPooling.instance.enemies, ObjectPooling.instance.AmountofObject(1));
        if (enemy != null)
        {
            enemy.transform.position = new Vector3(Random.Range(-xRangeEnemy, xRangeEnemy), 1, Random.Range(-zRangeEnemy, zRangeEnemy));
            enemy.transform.rotation = Quaternion.identity;
            enemy.SetActive(true);
        }
    }

    public void ScoreUpdate(int add)
    {
        score += add;
        UIManager.instance.ScoreUIHandler(score);
    }

    void GameOver()
    {
        CancelInvoke(nameof(SpawnEnemy));
        ObjectPooling.instance.DestroyObjects(ObjectPooling.instance.enemies);
        ObjectPooling.instance.DestroyObjects(ObjectPooling.instance.flames);
        ObjectPooling.instance.DestroyObjects(ObjectPooling.instance.projectiles);
        StartCoroutine(UIManager.instance.GameOverUI(score));
    }
}
