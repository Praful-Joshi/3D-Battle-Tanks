using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //other script ref
    private EnemyController controller;

    //declaring components
    private NavMeshAgent agent;
    private Transform target;

    //declaring variables
    private float lookRadius = 10f;
    public Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        target = TankService.tank.tank.transform;
        Debug.Log(target);

        setDestination();
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, this.transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            if(distance <= agent.stoppingDistance)
            {
                //attack the target
                //face the target
                faceTarget();
            }
        }
    }

    private void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10);
    }

    private void setDestination()
    {
        if(destination != null)
        {
            agent.SetDestination(destination.transform.position);
        }
    }

    internal void setControllerRef(EnemyController controller)
    {
        this.controller = controller;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, lookRadius);
    }
}
