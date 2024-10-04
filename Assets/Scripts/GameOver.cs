using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
  public WaveSpawner waveSpawner;
  public TextMeshProUGUI roundsText;
  void OnEnable() {
    roundsText.text = "Vous avez survécu " + (PlayerStats.rounds-1).ToString()  + " vagues.";
  }

  public void Retry() {
      WaveSpawner.EnemiesAlive = 0;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  public void Menu() {
    SceneManager.LoadScene(0);
  }
}
