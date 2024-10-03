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
    private Node selectedNode;

    public NodeUi nodeUI;

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;
    public GameObject buildEffect;
     public GameObject sellEffect;
    public bool canBuild { get { return turretToBuild != null; } }
  public bool hasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public void selectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
       DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void selectNode(Node node)
    {
    if(node == selectedNode)
    {
        DeselectNode();
        return;
    }
      selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void DeselectNode() {
        selectedNode = null;
        nodeUI.Hide();
    }
}
