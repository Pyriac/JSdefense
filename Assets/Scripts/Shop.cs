
using UnityEngine;

public class Shop : MonoBehaviour
{

    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
 public void PurchaseStandardTurret()
 {
    buildManager.setTurretToBuild(buildManager.standardTurretPrefab);
 }

 public void PurchaseMissileLauncher()
 {
    buildManager.setTurretToBuild(buildManager.missileLauncherPrefab);
 }
}
