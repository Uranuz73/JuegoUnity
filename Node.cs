using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color NoMoneyColor;
    private Renderer rend;
    private Color startColor;
    public Vector3 positionOffset;
    [Header("Opcional")]
    public GameObject turret;
    public TurretBlueprint turretBlueprint;
    public bool isUpgraded = false;
    BuildManager buildManager;

    private float a = 0;
    private float b = 0;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }



    public Vector3 GetBuildPosition() {
        return transform.position + positionOffset;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {

            return;
        }

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
            
        }

        BuildTurret(buildManager.getTurretToBuild());
    }


    void BuildTurret(TurretBlueprint blueprint) {

        if (Stats.Money < blueprint.cost)
        {

            Debug.Log("Not enough money!");

            return;
        }
        Stats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;


    }
    public void UpgradeTurret() {

        if (Stats.Money < turretBlueprint.upgradeCost)
        {

            Debug.Log("Not enough money!");

            return;
        }
        Stats.Money -= turretBlueprint.upgradeCost;
        

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        isUpgraded = true;

    }

    public void SellTurret()
    {
        
        

        if (isUpgraded)
        {
            Stats.Money += turretBlueprint.GetUpgradedSellPrice();
            Destroy(turret);
            turretBlueprint = null;
        }
        else {
            Stats.Money += turretBlueprint.GetSellPrice();
            Destroy(turret);
            turretBlueprint = null;
        }
        
        

    }



    void OnMouseEnter()
    {

        if (EventSystem.current.IsPointerOverGameObject()) {

            return;
        }



        if (!buildManager.CanBuild)
        {
            return;
        }


        if (buildManager.HasMoney) {
            rend.material.color = hoverColor;
        }
        else { rend.material.color = NoMoneyColor; }

        


    }


    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
