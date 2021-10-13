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

    public void GetCharName(int id)
    {
        DataManager.instance.CharID = id;

        switch (id)
        {
            case 0:
                charChooser[0].interactable = false;
                charChooser[1].interactable = true;
                charChooser[2].interactable = true;
                break;
            case 1:
                charChooser[0].interactable = true;
                charChooser[1].interactable = false;
                charChooser[2].interactable = true;
                break;
            case 2:
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
