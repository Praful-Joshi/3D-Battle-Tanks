using UnityEngine;

public class EnemyAttackingState : EnemyBaseState
{
    private EnemyController controller;

    internal EnemyAttackingState(EnemyController controller)
    {
        this.controller = controller;
    }

    public override void enterState(EnemyStateManager enemy)
    {
        Debug.Log("Hello from the attacking state");
        //attack player
        controller.attackPlayer();
    }

    public override void updateState(EnemyStateManager enemy)
    {
        //attack player
        controller.attackPlayer();

        //if player goes out of attacking distance switch to chasing
        if(!controller.checkAttackingDist())
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
