using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    //other scripts ref
    internal TankModel model;
    internal TankView view;
    internal TankService service;

    //declaring components
    private Joystick leftJoystick;
    private Rigidbody rb;
    internal GameObject tank;

    //declaring variables
    private float movementInput;
    private float turnInput;

    public TankController(TankModel tankModel, TankView tankView)
    {
        model = tankModel;
        view = GameObject.Instantiate<TankView>(tankView);
        tank = view.gameObject;
    }

    internal void awakeTankController()
    {

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

    //Tank Movement Code

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

    //Tank Movement Code

    //Tank Health Code

    internal float setMaxHealth()
    {
        return model.health;
    }
}
