using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : GenericSingleton<TankService>
{
    //other scripts ref
    internal static TankModel model;
    internal static TankController tankController;
    private TankView view;
    public TankScriptableObject[] tankSO;
    private TankScriptableObject tankScriptableObject;

    //declaring components
    public Joystick leftJoystick;

    //declaring variables
    public static GameObject createdTank;

    protected override void Awake()
    {
        base.Awake();                                                           
        createNewTank();                                                        
    }

    private void Start()
    {
        tankController.start();
    }

    private void Update()
    {
        tankController.update();
    }

    private void FixedUpdate()
    {
        tankController.fixedUpdate();   
    }

    private void createNewTank()
    {
        tankScriptableObject = tankSO[Random.Range(0, 3)];
        model = new TankModel(tankScriptableObject);
        view = model.tankPrefab.GetComponent<TankView>();
        tankController = new TankController(model, view);
        Debug.Log(model.color + " tank created");
    }

    public GameObject getTankControllerRef()
    {
        return TankController.tankGameobject;
    }
}
