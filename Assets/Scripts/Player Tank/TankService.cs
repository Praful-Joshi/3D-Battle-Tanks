using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : GenericSingleton<TankService>
{
    //other scripts declaration
    internal TankModel model;
    private TankController tank;
    private TankView view;
    public TankScriptableObject[] tankSO;
    private CameraControl cameraControl;

    //component declaration
    public Joystick leftJoystick;
    public GameObject tankPrefab;

    //declaring variables
    private TankScriptableObject tankScriptableObject;

    protected override void Awake()
    {
        base.Awake();
        createNewTank();
    }

    private void Start()
    {
        tank.startTankController();
        setPlayerTankControllerRef();
        tankPrefab.SetActive(true);
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
        view = tankPrefab.GetComponent<TankView>();
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
