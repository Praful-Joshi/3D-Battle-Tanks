using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    internal EnemyController controller;

    EnemyBaseState currentState;
    public EnemyPatrollingState patrolling;
    public EnemyChasingState chasing;
    public EnemyAttackingState attacking;
    public EnemyDeadState dead;

    // Start is called before the first frame update
    void Start()
    {
        createStateObjects();
        currentState = patrolling;
        currentState.enterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.updateState(this);
    }

    public void switchState(EnemyBaseState state)
    {
        currentState = state;
        currentState.enterState(this);
    }

    private void createStateObjects()
    { 
        patrolling = new EnemyPatrollingState(controller);
        chasing = new EnemyChasingState(controller);
        attacking = new EnemyAttackingState(controller);
        dead = new EnemyDeadState(controller);
    }
}
