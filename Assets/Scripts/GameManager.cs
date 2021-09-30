using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isGameOver = false;
    [SerializeField] GameObject[] characters = new GameObject[3];
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
        if (!isGameOver)
        {
#if UNITY_EDITOR
            GameObject player = Instantiate(characters[0], playerSpawnPos, Quaternion.identity);
            player.AddComponent<PlayerController>();
#else
            GameObject player = Instantiate(characters[DataManager.instance.CharID], playerSpawnPos, Quaternion.identity);
            player.AddComponent<PlayerController>();
#endif
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameOver()
    {

    }
}
