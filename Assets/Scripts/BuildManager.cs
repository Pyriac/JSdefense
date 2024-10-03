using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Singleton

    public static BuildManager instance;

    private void Awake()
    {
        if(instance != null){
            Debug.LogError("Il y a déjà un BuildManager dans la scène !");
            return;
        }
        instance = this;
    }

    #endregion

    private TurretBlueprint turretToBuild;

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;
    public GameObject buildEffect;
    public bool canBuild { get { return turretToBuild != null; } }
  public bool hasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public void selectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void buildTurretOn(Node node) {
        if(PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("not enough money");
            return;
        }
        PlayerStats.money -= turretToBuild.cost;

       GameObject turret = Instantiate(turretToBuild.prefab, node.transform.position + node.positionOffset, Quaternion.identity);
       node.turret = turret;
       GameObject effect = (GameObject)Instantiate(buildEffect, node.transform.position + node.positionOffset, Quaternion.identity);
       Destroy(effect, 1f);
    }
}
