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

    private GameObject turretToBuild;

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void setTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
