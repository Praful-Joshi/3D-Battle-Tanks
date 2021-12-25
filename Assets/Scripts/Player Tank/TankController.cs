using UnityEngine;

public class TankController
{
    //other scripts declaration
    private TankModel model;
    private TankView view;
    private TankService service;

    //component declaration
    private Joystick leftJoystick;
    private Rigidbody rb;

    //variable declaration
    private float movementInput;
    private float turnInput;

    public TankController(TankModel tankModel, TankView tankView)
    {
        model = tankModel;
        view = tankView;
    }

    internal void startTankController()
    {
        rb = view.GetComponent<Rigidbody>();
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

    internal void setJoystickRef(Joystick leftJoystick)
    {
        this.leftJoystick = leftJoystick;
    }

    private void getInput()
    {
        movementInput = leftJoystick.Vertical;
        turnInput = leftJoystick.Horizontal;
    }

    private void move()
    {
        Vector3 movement = view.transform.forward * movementInput * model.moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void turn()
    {
        float turn = turnInput * model.turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
