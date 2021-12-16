using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : GenericSingleton<TankService>
{
    //other scripts declaration
    private TankModel model;
    private TankController tank;
    private TankView view;
    private TankTypes tankTypes;
    private TankScriptableObject[] tankConfigurations;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        createNewTank();
    }

    private TankController createNewTank()
    {
        TankScriptableObject tankScriptableObject = tankConfigurations[Random.Range(0, 3)];
        model = new TankModel(tankScriptableObject);
        tank = new TankController(model, view);
        return tank;
    }
}
