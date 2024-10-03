using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;
  void OnEnable() {
    roundsText.text = "Vous avez survécu " + (PlayerStats.rounds-1).ToString()  + " vagues.";
  }

  public void Retry() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Time.timeScale = 1f;
  }

  public void Menu() {
    SceneManager.LoadScene(0);
  }
}
