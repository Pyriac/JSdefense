using TMPro;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
 public TextMeshProUGUI lifeText;
    void Update()
    {
        lifeText.text = PlayerStats.lives.ToString() + " vie(s)";
    }
}

