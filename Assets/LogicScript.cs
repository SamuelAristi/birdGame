using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI BestScoreText;
    public GameObject gameOverScreen;
    public AudioClip restartSound;
    public float restartDelay = 1.5f;

    private int bestScore;

    [ContextMenu("increase Score")]

    void Start()
    {
        // Al inicio, obtenemos el mejor puntaje guardado (si existe)
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateBestScoreText();
    }
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        ScoreText.text = "Score: " + playerScore.ToString();

        if (playerScore > bestScore)
        {
            bestScore = playerScore;
            
            PlayerPrefs.SetInt("BestScore", bestScore);
            UpdateBestScoreText();
        }

    }
    void UpdateBestScoreText()
    {
        BestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    public void restarGame()
    {
        soundController.Instance.startSound(restartSound);
        Invoke("ReloadSceneWithDelay", restartDelay);
    }

    private void ReloadSceneWithDelay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
    public void exit()
    {
        Debug.Log("salir");
        Application.Quit();
    }


}
