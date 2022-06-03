using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null) {
            Debug.Log("More than one BuildManager");
            return;
        }
       instance = this;    
        
    }


    private TurretBlueprint turretToBuild;

    private Node selectedNode;

    public NodeUIScript nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return Stats.Money >= turretToBuild.cost; } }




    public void SelectNode(Node node)
    {
        if (selectedNode == node) {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode() {
        selectedNode = null;
        nodeUI.Hide();

    }

    public void SelectTurretToBuild(TurretBlueprint turret) {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint getTurretToBuild() {

        return turretToBuild;
    }


   
}
