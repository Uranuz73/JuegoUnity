using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUIScript : MonoBehaviour
{

    public GameObject UI;
    private Node target;
    public Text upgradeCost;
    public Button upgradeButton;
    public Text sellCost;


    public void SetTarget(Node _target) {

        

        this.target = _target;

        transform.position = target.GetBuildPosition();

        

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$ " + target.turretBlueprint.cost;
            upgradeButton.interactable = true;
            sellCost.text = "$ " + target.turretBlueprint.GetSellPrice().ToString();
        }
        else{
            upgradeCost.text = "MAXED OUT";
            upgradeButton.interactable = false;
            sellCost.text = "$ " + target.turretBlueprint.GetUpgradedSellPrice().ToString();
        }

        

        UI.SetActive(true);


    }

    public void Hide() {
        UI.SetActive(false);
    
    }


    public void Upgrade() {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
