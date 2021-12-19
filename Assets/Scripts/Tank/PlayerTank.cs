using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : GenericSingleton<PlayerTank>
{
    public int m_PlayerNumber = 1;
    public float m_Speed = 12f;
    public float m_TurnSpeed = 180f;
    public Joystick joystick;

    private Rigidbody m_rb;
    private float m_MovementInputValue;
    private float m_TurnInputValue;

    protected override void Awake()
    {
        base.Awake();
        m_rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        m_rb.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }

    private void OnDisable()
    {
        m_rb.isKinematic = true;
    }


    private void Update()
    {
        m_MovementInputValue = joystick.Vertical;
        m_TurnInputValue = joystick.Horizontal;
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;
        m_rb.MovePosition(m_rb.position + movement);
    }

    private void Turn()
    {
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        m_rb.MoveRotation(m_rb.rotation * turnRotation);
    }
}
