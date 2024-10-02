using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    private BuildManager buildManager;

    public Color hoverColor;
    private Color startColor;
    private GameObject turret;
    private Renderer rend;

    public Vector3 positionOffset;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown(){

        if(buildManager.GetTurretToBuild() == null)
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

        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    private void OnMouseEnter(){ 

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if(buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        rend.material.color = hoverColor;
    }

    private void OnMouseExit(){
        rend.material.color = startColor;
    }
}
   
