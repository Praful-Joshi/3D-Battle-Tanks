using UnityEngine;

public class EnemyDeadState : EnemyBaseState
{
    private EnemyController controller;

    internal EnemyDeadState(EnemyController controller)
    {
        this.controller = controller;
    }

    public override void enterState(EnemyStateManager enemy)
    {
        Debug.Log("Hello from the dead state");
        //play death particle effect
        controller.deathParticleEffect();
        //destroy the tank
        controller.destroyEnemy();
    }

    public override void updateState(EnemyStateManager enemy)
    {

    }

    public override void onCollisionEnter(EnemyStateManager enemy)
    {

    }
}
