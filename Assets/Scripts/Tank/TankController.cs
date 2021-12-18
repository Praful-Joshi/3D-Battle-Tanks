using UnityEngine;

public class TankController
{
    //other scripts declaration
    private TankModel model;
    private TankView view;
    private TankService service;

    //component declaration
    private Joystick joystick;
    private Rigidbody rb;

    //variable declaration
    private float movementInput;
    private float turnInput;

    public TankController(TankModel tankModel, TankView tankView)
    {
        model = tankModel;
        view = GameObject.Instantiate<TankView>(tankView);
    }

    internal void startTankController()
    {
        rb = model.tankPrefab.GetComponent<Rigidbody>();
        joystick = service.joystick;
    }

    internal void updateTankController()
    {
        getInput();
    }

    internal void fixedUpdateTankController()
    {
        move();
        turn();
    }

    private void getInput()
    {
        movementInput = joystick.Vertical;
        turnInput = joystick.Horizontal;
    }

    private void move()
    {
        Vector3 movement = model.tankPrefab.transform.forward * movementInput * model.moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void turn()
    {
        float turn = turnInput * model.moveSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
