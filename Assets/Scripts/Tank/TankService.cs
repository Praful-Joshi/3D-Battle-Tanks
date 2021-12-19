using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : GenericSingleton<TankService>
{
    //other scripts declaration
    private TankModel model;
    private TankController tank;
    private TankView view;
    public TankScriptableObject[] tankSO;

    //component declaration
    public Joystick leftJoystick;

    //declaring variables
    private TankScriptableObject tankScriptableObject;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        createNewTank();
        tank.startTankController();
        setPlayerTankControllerRef();
    }

    private void Update()
    {
        tank.updateTankController();
    }

    private void FixedUpdate()
    {
        tank.fixedUpdateTankController();
    }

    private void createNewTank()
    {
        tankScriptableObject = tankSO[Random.Range(0, 3)];
        model = new TankModel(tankScriptableObject);
        view = tankScriptableObject.tankPrefab.GetComponent<TankView>();
        tank = new TankController(model, view);
        Debug.Log(model.color + " tank created");
    }

    private void setPlayerTankControllerRef()
    {
        if(tank != null)
        {
            tank.setJoystickRef(leftJoystick);
        }
    }
}
