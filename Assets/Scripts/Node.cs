using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    private BuildManager buildManager;

    public Color hoverColor;
    private Color startColor;
    public GameObject turret;
    private Renderer rend;
    public Color notEnoughMoneyColor;

    public Vector3 positionOffset;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown(){

        if(!buildManager.canBuild)
        {
            return;
        }

        
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(turret != null){
            Debug.Log("Impossible de contruire ici, il y a déjà une tourelle.");
            return;
        }

       buildManager.buildTurretOn(this);
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
   
