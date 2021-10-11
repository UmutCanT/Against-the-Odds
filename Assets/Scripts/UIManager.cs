using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] GameObject playerUI;
    [SerializeField] GameObject gameOverPanel;

    [SerializeField] Text score;
    [SerializeField] Text playerHp;


    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerUI.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void HealthUIHandler(int hp)
    {
        TextManager(playerHp, hp);
    }

    public void ScoreUIHandler(int score)
    {
        TextManager(this.score, score);
    }

    void TextManager(Text textToChange, int value)
    {
        textToChange.text = string.Format(FormatDecider(textToChange), value);
    }

    string FormatDecider(Text textToFormat)
    {
        return textToFormat.name switch
        {
            "PlayerHp" => "HP: {0}",
            "Score" => "Score: {0}",
            _ => default
        };
    }

    public IEnumerator GameOverUI(int endScore)
    {
        yield return new WaitForSeconds(0.5f);
        playerUI.SetActive(false);
        TextManager(gameOverPanel.GetComponentInChildren<Text>(), endScore);
        gameOverPanel.SetActive(true);
    }

    public void BacktoMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
