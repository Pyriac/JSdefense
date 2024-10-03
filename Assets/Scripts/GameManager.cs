using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CompleteLevelUI;
    public static bool gameIsOver;
    public GameObject gameOverUI;

    void Start() {
        gameIsOver = false;
    }
    void Update()
    {
        if(gameIsOver)
        {
            return;
        }

        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
        
    }

    void EndGame()
    {
        gameIsOver = true;
       gameOverUI.SetActive(true);
       Time.timeScale = 0;
    }

    public void WinLevel()
    {   
        gameIsOver = true;
        CompleteLevelUI.SetActive(true);
    }
}
