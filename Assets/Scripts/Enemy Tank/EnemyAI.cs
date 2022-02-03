using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private enum state
    {
        patrolling,
        chasing,
        dead
    }
    //other script ref
    private EnemyController controller;

    //declaring components
    private NavMeshAgent agent;
    private Transform target;

    //declaring variables
    private float distanceToPlayer, chasingDistance = 10f, attackingDistance = 5f;
    private Transform destination;
    private state currentState;
    private Transform targetWaypoint;
    private int waypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        target = TankController.tankGameobject.transform;

        distanceToPlayer = Vector3.Distance(this.transform.position, target.position);

        //patrol initiation
        waypointIndex = UnityEngine.Random.Range(0, 5);
        targetWaypoint = controller.enemyModel.waypoints[waypointIndex].transform;
        setDestination(targetWaypoint);

        //state initiation
        currentState = state.patrolling;
    }

    private void Update()
    {
        switch(currentState)
        {
            default:
            case state.patrolling:
                patrol();
                break;
            case state.chasing:
                chase();
                break;
            case state.dead:
                dead();
                break;
        }
        updateDistance();
    }

    private void updateDistance()
    {
        distanceToPlayer = Vector3.Distance(target.position, this.transform.position);
    }

    private void dead()
    {
        Debug.Log("enemy dead");
    }

    private void attack()
    {
        Debug.Log("enemy attacking");
    }

    private void chase()
    {
        Debug.Log("enemy chasing");
        agent.SetDestination(target.position);
        if(distanceToPlayer <= attackingDistance)
        {
            attack();
            faceTarget();
        }
        if (distanceToPlayer > chasingDistance)
        {
            changeState(state.patrolling);
        }
    }

    private void patrol()
    {
        setDestination(targetWaypoint);
        if (Vector3.Distance(this.transform.position, targetWaypoint.position) < 1)
        {
            iterateWayPointIndex();
            targetWaypoint = controller.enemyModel.waypoints[waypointIndex].transform;
            setDestination(targetWaypoint);
        }
        if (distanceToPlayer <= chasingDistance)
        {
            changeState(state.chasing);
        }
    }

    private void changeState(state newState)
    {
        currentState = newState;
    }

    private void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10);
    }

    private void setDestination(Transform destination)
    {
        if(destination != null)
        {
            agent.SetDestination(destination.transform.position);
        }
    }

    private void iterateWayPointIndex()
    {
        waypointIndex++;
        Debug.Log(waypointIndex);
        if(waypointIndex == controller.enemyModel.waypoints.Count)
        {
            waypointIndex = 0;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, chasingDistance);
    }

    internal void setControllerRef(EnemyController controller)
    {
        this.controller = controller;
    }
}
