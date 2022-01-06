using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void enterState(EnemyStateManager enemy);
    public abstract void updateState(EnemyStateManager enemy);
    public abstract void onCollisionEnter(EnemyStateManager enemy);
}
