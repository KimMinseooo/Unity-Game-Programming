using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standardTurret;
    public TurretBluePrint MissileTurret;


    BuildMaster buildMaster;

    void Start() {
        buildMaster = BuildMaster.instance;

    }

    public void SelectStandardTurret() {
        Debug.Log("Standard Turret Purchased");
        buildMaster.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileTurret() {
        Debug.Log("Missile Turret Purchased");
        buildMaster.SelectTurretToBuild(MissileTurret);
    }
}
