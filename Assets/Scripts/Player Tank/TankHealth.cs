using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    private void Start()
    {
    }

    private void Update()
    {
        
    }

    public void takeDamage(float damage, int sourceId)
    {
        if(sourceId == 1) //bullet coming from an enemy tank
        {
            TankService.model.health -= damage;
            Debug.Log("Player tank remaining health - " + TankService.model.health);
            if (TankService.model.health <= 0)
            {
                Debug.Log("player tank died");
            }
        }
        else
        {
            EnemyService.enemyModel.health -= damage;
            Debug.Log("Enemy tank remaining health - " + EnemyService.enemyModel.health);
            if(EnemyService.enemyModel.health <= 0)
            {
                Debug.Log("Enemy tank died");
            }
        }

        
    }
}