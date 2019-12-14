using System.Collections;
using UnityEngine;

// 시리얼 없으면 유니티가 못 읽음.
[System.Serializable]
public class TurretBluePrint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradePrefab;
    public int upgradeCost;

    public int sellCost;

}
