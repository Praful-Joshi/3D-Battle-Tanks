using UnityEngine;

public class EnemyPatrollingState : EnemyBaseState
{
    private EnemyController controller;

    internal EnemyPatrollingState(EnemyController controller)
    {
        this.controller = controller;
    }

    public override void enterState(EnemyStateManager enemy)
    {
        Debug.Log("Hello from the patrolling state");
        //set enemy patrol path
        controller.setPatrolPath();
    }

    public override void updateState(EnemyStateManager enemy)
    {
        //make the enemy patrol on that path
        controller.patrolOnPath();

        //if the player tank is in sight switch to chasing state
        if(controller.isPlayerInSight())
        {
            //enemy.switchState(enemy.chasing);
        }

        //check for death
        if (controller.isDead())
        {
            //enemy.switchState(enemy.dead);
        }
    }

    public override void onCollisionEnter(EnemyStateManager enemy)
    {

    }
}