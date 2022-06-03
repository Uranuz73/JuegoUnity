using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public float cost;

    public GameObject upgradedPrefab;
    public float upgradeCost;


    public float GetSellPrice() {
        return cost * 0.7f;
    }

    public float GetUpgradedSellPrice() {

        return (cost + upgradeCost) * 0.7f;
    }
}
