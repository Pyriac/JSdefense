using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    private BuildManager buildManager;

    public Color hoverColor;
    private Color startColor;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;


    private Renderer rend;
    public Color notEnoughMoneyColor;

    public Vector3 positionOffset;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public void UpgradeTurret() 
    {
              if(PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("not enough money");
            return;
        }
        PlayerStats.money -= turretBlueprint.upgradeCost;
    Destroy(turret);
       GameObject _turret = Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
       turret = _turret;
       GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
       Destroy(effect, 1f);
       isUpgraded = true;
    }

    private void BuildTurret(TurretBlueprint blueprint) 
    {
      if(PlayerStats.money < blueprint.cost)
        {
            Debug.Log("not enough money");
            return;
        }
        PlayerStats.money -= blueprint.cost;

        turretBlueprint = blueprint;

       GameObject _turret = Instantiate(blueprint.prefab, transform.position + positionOffset, Quaternion.identity);
       turret = _turret;
       GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, transform.position + positionOffset, Quaternion.identity);
       Destroy(effect, 1f);
    }

    public void SellTurret ()
    {
        PlayerStats.money += turretBlueprint.cost / 2;
        Destroy(turret);
        turretBlueprint = null;
        isUpgraded = false;
        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, transform.position + positionOffset, Quaternion.identity);
       Destroy(effect, 1f);
    }

    private void OnMouseDown(){

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

     if(turret != null){
            buildManager.selectNode(this);
            Debug.Log("Impossible de contruire ici, il y a déjà une tourelle.");
            return;
        }

             if(!buildManager.canBuild)
        {

            return;
        }


     BuildTurret(buildManager.GetTurretToBuild());
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseEnter(){ 

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if(!buildManager.canBuild)
        {
            return;
        }
        
        if (buildManager.hasMoney)
        {rend.material.color = hoverColor;}
        else {
            rend.material.color = notEnoughMoneyColor;
        }
        
    }

    private void OnMouseExit(){
        rend.material.color = startColor;
    }
}
   
