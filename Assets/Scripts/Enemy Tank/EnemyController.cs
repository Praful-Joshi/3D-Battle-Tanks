using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController
{
    //other scripts declaration
    private EnemyModel enemyModel;
    private EnemyView enemyView;
    private EnemyStateManager stateManager;

    private GameObject enemy;

    private Vector3 spawnLocation;

    public EnemyController(EnemyModel enemyModel, EnemyView enemyView)
    {
        this.enemyModel = enemyModel;
        generateSpawnLocation();
        this.enemyView = GameObject.Instantiate<EnemyView>(enemyView, spawnLocation, Quaternion.identity);
        enemy = this.enemyView.gameObject;
    }

    internal void controllerAwake()
    {
        stateManager = enemy.GetComponent<EnemyStateManager>();
        setStateControllerRef();
    }

    internal void controllerStart()
    {
        
    }

    internal void setPatrolPath()
    {
        Debug.Log("Patrol path set");
    }
    
    internal void patrolOnPath()
    {

    }

    internal bool isPlayerInSight()
    {

        return false;
    }

    internal void chaseTank()
    {

    }

    internal bool checkAttackingDist()
    {
        return false;
    }
    
    internal void attackPlayer()
    {

    }

    internal bool isDead()
    {
        return false;
    }

    internal void deathParticleEffect()
    {

    }

    internal void destroyEnemy()
    {

    }

    private void generateSpawnLocation()
    {
        float x = enemyModel.spawnLocations[Random.Range(0, 5)].transform.position.x;
        float y = enemyModel.spawnLocations[Random.Range(0, 5)].transform.position.y;
        float z = enemyModel.spawnLocations[Random.Range(0, 5)].transform.position.z;
        spawnLocation = new Vector3(x, y, z);
    }

    private void setStateControllerRef()
    {
        if (this != null)
        {
            stateManager.controller = this;
        }
    }

}
