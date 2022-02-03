using System;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    //other scripts ref
    internal TankModel model;
    internal TankView view;
    internal TankService service;

    //declaring components
    internal Rigidbody rb;
    public static GameObject tankGameobject;
    public AudioSource movementAudioSource;         // Reference to the audio source used to play engine sounds. NB: different to the shooting audio source.

    //declaring variables
    private float movementInput;
    private float turnInput; 
    public float audioPitchRange = 0.2f;           // The amount by which the pitch of the engine noises can vary.
    private float originalAudioPitch;              // The pitch of the audio source at the start of the scene.

    public TankController(TankModel tankModel, TankView tankView)
    {
        model = tankModel;
        view = GameObject.Instantiate<TankView>(tankView);
        tankGameobject = view.gameObject;

        rb = tankGameobject.GetComponent<Rigidbody>();
        movementAudioSource = tankGameobject.GetComponent<AudioSource>();
        originalAudioPitch = movementAudioSource.pitch;
    }

    public void start()
    {

    }

    public void update()
    {
        getInput();
/*        engineAudio();*/
    }

    public void fixedUpdate()
    {
        move();
        turn();
    }

    //Tank Movement Code
    internal void getInput()
    {
        movementInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");
    }

    internal void move()
    {
        Vector3 movement = view.transform.forward * movementInput * model.moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    internal void turn()
    {
        float turn = turnInput * model.turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    //Tank Audio code
    private void engineAudio()
    {
        if (Mathf.Abs(movementInput) < 0.1f && Mathf.Abs(turnInput) < 0.1f)
        {
   
            /*if(movementAudioSource == model.drivingClip)
            {
                movementAudioSource.clip = model.idlingClip;
                movementAudioSource.pitch = UnityEngine.Random.Range(originalAudioPitch - audioPitchRange, originalAudioPitch + audioPitchRange);
            }*/
        }
        else
        {
            /*if(movementAudioSource == model.idlingClip)
            movementAudioSource.clip = model.drivingClip;
            movementAudioSource.pitch = UnityEngine.Random.Range(originalAudioPitch - audioPitchRange, originalAudioPitch + audioPitchRange);*/
        }
        movementAudioSource.Play();
    }

    internal float setMaxHealth()
    {
        return model.health;
    }
}
