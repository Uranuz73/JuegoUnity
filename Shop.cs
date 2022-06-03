using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint turret1;
    public TurretBlueprint turret2;
    public TurretBlueprint turret3;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectTurret1() {

        buildManager.SelectTurretToBuild(turret1);
    }

    public void SelectTurret2()
    {

        buildManager.SelectTurretToBuild(turret2);
    }


    public void SelectTurret3()
    {

        buildManager.SelectTurretToBuild(turret3);
    }


}
