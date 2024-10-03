using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NodeUi : MonoBehaviour
{
    private Node target;
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellMoney;
    public GameObject ui;
    public Button upgradeButton;

    public void SetTarget (Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "-" + target.turretBlueprint.cost + " BC";
            upgradeButton.interactable = true;
        }
        else
        {
          upgradeCost.text = "Lvl Max";
          upgradeButton.interactable = false;       
        }
          sellMoney.text = "+" + target.turretBlueprint.cost / 2 + "BC";      
        ui.SetActive(true);
    }
  public void Hide () 
  {
    ui.SetActive(false);
  }

  public void Upgrade()
  {
    target.UpgradeTurret();
    BuildManager.instance.DeselectNode();
  }

  public void Sell()
  {
    target.SellTurret();
    BuildManager.instance.DeselectNode();
  }
}
