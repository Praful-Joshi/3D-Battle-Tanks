using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
    private EnemyController controller;

    internal EnemyChasingState(EnemyController controller)
    {
        this.controller = controller;
    }

    public override void enterState(EnemyStateManager enemy)
    {
        Debug.Log("Hello from the chasing state");
    }

    public override void updateState(EnemyStateManager enemy)
    {
        //follow the tank till it is in the straight line of sight
        controller.chaseTank();

        //if the tank is in the attacking distance switch to attacking state
        if(controller.checkAttackingDist())
        {
            //enemy.switchState(enemy.attacking);
        }

        //if player goes out of sight switch to patrolling
        if(!controller.isPlayerInSight())
        {
            enemy.switchState(enemy.patrolling);
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
