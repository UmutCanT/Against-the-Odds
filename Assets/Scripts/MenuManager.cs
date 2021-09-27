using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuManager : MonoBehaviour
{
    [SerializeField]
    Button[] charChooser = new Button[3];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetCharName(string name)
    {
        DataManager.instance.CharName = name;

        switch (name)
        {
            case "Archer":
                charChooser[0].interactable = false;
                charChooser[1].interactable = true;
                charChooser[2].interactable = true;
                break;
            case "Wizard":
                charChooser[0].interactable = true;
                charChooser[1].interactable = false;
                charChooser[2].interactable = true;
                break;
            case "Paladin":
                charChooser[0].interactable = true;
                charChooser[1].interactable = true;
                charChooser[2].interactable = false;
                break;
            default:
                break;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
