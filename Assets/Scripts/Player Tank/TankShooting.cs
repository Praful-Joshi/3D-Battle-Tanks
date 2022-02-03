using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public GameObject firePosition;
    public AudioSource shootingAudio;
    public AudioClip chargingClip;
    public AudioClip shootingClip;
    public float minLaunchForce = 15f;
    public float maxLaunchForce = 30f;
    public float maxChargeTime = 0.75f;

    private float currentLaunchForce;
    private float chargeSpeed;
    private bool isFired;

    // Start is called before the first frame update
    void Start()
    {
        currentLaunchForce = minLaunchForce;
        chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentLaunchForce >= maxLaunchForce && !isFired)
        {
            currentLaunchForce = maxLaunchForce;
            fire();
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            isFired = false;
            currentLaunchForce = minLaunchForce;
            shootingAudio.clip = chargingClip;
            shootingAudio.Play();
        }
        else if(Input.GetKey(KeyCode.Mouse0) && !isFired)
        {
            currentLaunchForce += chargeSpeed * Time.deltaTime;
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0) && !isFired)
        {
            fire();
        }
    }

    private void fire()
    {
        isFired = true;
        GameObject bullet = Instantiate(BulletPool.instance.getBullet(), firePosition.transform.position, firePosition.transform.rotation);
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        bulletRB.velocity = currentLaunchForce * firePosition.transform.forward;

        shootingAudio.clip = shootingClip;
        shootingAudio.Play();
        currentLaunchForce = minLaunchForce;
    }
}
