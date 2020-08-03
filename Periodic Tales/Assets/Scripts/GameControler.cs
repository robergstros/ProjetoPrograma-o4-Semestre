using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{

    public int totalScore;
    public Text scoreText;

    public GameObject gameOver;

    public static GameControler instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestarGame(string lvlName)// foi criado o parametro string para poder referenciar a fase dentro da unity e assim poupar código
    {
        SceneManager.LoadScene(lvlName);
    }

    public void CarregarFase1(string lvlName)
    {
        SceneManager.LoadScene("Fase1");
    }

}
