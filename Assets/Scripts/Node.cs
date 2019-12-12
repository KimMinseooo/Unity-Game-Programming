using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour{

    public Vector3 positionOffSet;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    public Color hoverColor; 
    public Color notEnoughMoneyColor; 
    private Color startColor;

    BuildMaster buildMaster;

    void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildMaster = BuildMaster.instance;
    }

    public Vector3 GetBuildPosition() {
        return transform.position + positionOffSet;
    }

    void OnMouseDown() {
        if(EventSystem.current.IsPointerOverGameObject()) {
            return ;
        }

        if(!buildMaster.CanBuild) 
            return ;
        

        if(turret != null) {
            return ;
        }

        buildMaster.BuildTurretOn(this);
    }

    void OnMouseEnter() {
        if(EventSystem.current.IsPointerOverGameObject()) {
            return ;
        }

        if(!buildMaster.CanBuild) 
            return ;
    
        if(buildMaster.HasMoney) {
            rend.material.color = hoverColor;
        } else {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit() {
        rend.material.color = startColor;
    }
}
