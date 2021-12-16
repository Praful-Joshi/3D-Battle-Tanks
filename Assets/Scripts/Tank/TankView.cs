using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    //other script declaration
    private TankModel tankModel;
    
    //component declaration
    public Joystick joystick;
    private Rigidbody rb;

    //variable declaration
    private float movementInput;
    private float turnInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        getInput();
    }

    private void FixedUpdate()
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
        Vector3 movement = transform.forward * movementInput * tankModel.moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void turn()
    {
        float turn = turnInput * tankModel.moveSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
