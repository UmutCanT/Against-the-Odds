using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance { get; private set; } // Encapsulation

    int charId;

    /// <summary>
    /// Returns or sets the character ID according to choosing section from main menu
    /// </summary>
    public int CharID // Encapsulation
    {
        set
        {
            charId = value;
        }

        get
        {
            return charId;
        }
    }

    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
