using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{

    public int nextLevel = 3;

  public void Continue() {
    SceneManager.LoadScene(nextLevel);
    nextLevel++;
    Time.timeScale = 1f;
  }

  public void Menu() {
    SceneManager.LoadScene(0);
  }
}
