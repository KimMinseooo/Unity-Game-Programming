using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour{

    public Vector3 positionOffSet;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBluePrint turretBluePrint;
    [HideInInspector]
    // 업그레이드 여부.
    public bool isUpgraded = false;

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

        if(turret != null) {
            buildMaster.SelectNode(this);
            return ;
        }

        if(!buildMaster.CanBuild) {
            return ;
        }

        BuildTurret(buildMaster.GetBluePrint());
    }

    void BuildTurret (TurretBluePrint bluePrint) {
        if(PlayerStats.money < bluePrint.cost) {
            Debug.Log("Not enough money to build that");
            return ;
        }

        PlayerStats.money -= bluePrint.cost;

        GameObject _turret = (GameObject) Instantiate(bluePrint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBluePrint = bluePrint;

        Debug.Log("Turret Build Money left: " + PlayerStats.money);
    }

    public void UpgradeTureet () {
        if(isUpgraded) {
            Debug.Log("Upgrade is done");
            return ;
        }
        if(PlayerStats.money < turretBluePrint.upgradeCost) {
            Debug.Log("Not enough money to upgrade that");
            return ;
        }

        PlayerStats.money -= turretBluePrint.upgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject) Instantiate(turretBluePrint.upgradePrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        isUpgraded = true;

        Debug.Log("Turret Upgrade!");
    }

    public void SellTurret () {
        if(isUpgraded) {
            PlayerStats.money += turretBluePrint.sellCost + turretBluePrint.upgradeCost / 2;
            Destroy(turret);
            turretBluePrint = null;
            Debug.Log("Turret Sell");
            return ;
        }

        PlayerStats.money += turretBluePrint.sellCost;

        Destroy(turret);
        turretBluePrint = null;
        Debug.Log("Turret Sell");       
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
