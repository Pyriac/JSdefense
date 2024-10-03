
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncherTurret;

    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
 public void SelectStandardTurret()
 {
    buildManager.selectTurretToBuild(standardTurret);
 }

 public void SelectMissileLauncher()
 {
    buildManager.selectTurretToBuild(missileLauncherTurret);
 }
}
