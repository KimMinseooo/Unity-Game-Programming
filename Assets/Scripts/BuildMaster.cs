using UnityEngine;

public class BuildMaster : MonoBehaviour
{
    public static BuildMaster instance;

    void Awake() {
        if(instance != null) {
            Debug.LogError("More than one BuildMaster in scene");
            return ;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;

    private TurretBluePrint turretToBuild;

    // 선택한 터렛의 종류가 들어있는지 검사
    public bool CanBuild {
        get {
            return turretToBuild != null;
        }
    }

    public bool HasMoney {
        get {
            return PlayerStats.money >= turretToBuild.cost;
        }
    }

    public void BuildTurretOn(Node node) {
        if(PlayerStats.money < turretToBuild.cost) {
            Debug.Log("Not enough money to build that");
            return ;
        }

        PlayerStats.money -= turretToBuild.cost;

        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret Build Money left: " + PlayerStats.money);
    }
    
    public void SelectTurretToBuild(TurretBluePrint turret) {
        turretToBuild = turret;
    }
}
