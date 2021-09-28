using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!isGameOver)
        {
            Debug.Log("yey");
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
