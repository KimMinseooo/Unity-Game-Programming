﻿using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    private Node target;

    public void SetTarget(Node _target){
        target = _target;

        transform.position = target.GetBuildPosition();
        ui.SetActive(true);
    }

    public void Hide() {
        ui.SetActive(false);
    }

    public void Upgrade() {
        target.UpgradeTureet();
        BuildMaster.instance.DeselectNode();
    }

    public void Sell() {
        target.SellTurret();
        BuildMaster.instance.DeselectNode();
    }
}
