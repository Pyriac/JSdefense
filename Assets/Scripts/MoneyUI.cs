using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
 public TextMeshProUGUI moneyText;
    void Update()
    {
        moneyText.text = PlayerStats.money.ToString() + "Bcoin";
    }
}
