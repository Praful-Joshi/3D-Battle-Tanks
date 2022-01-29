using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController
{
    //other scripts declaration
    private EnemyModel enemyModel;
    private EnemyView enemyView;
    private EnemyAI enemyAI;

    private GameObject enemy;
    private GameObject player;

    internal Vector3 spawnLocation;

    public EnemyController(EnemyModel enemyModel, EnemyView enemyView)
    {
        this.enemyModel = enemyModel;
        generateSpawnLocation();
        this.enemyView = GameObject.Instantiate<EnemyView>(enemyView, spawnLocation, Quaternion.identity);
        enemy = this.enemyView.gameObject;
    }

    internal void controllerAwake()
    {
        enemyAI = enemy.GetComponent<EnemyAI>();
        setEnemyAIControllerRef();
    }

    internal void controllerStart()
    {

    }

    private void generateSpawnLocation()
    {
        float x = enemyModel.spawnLocations[Random.Range(0, 5)].transform.position.x;
        float y = enemyModel.spawnLocations[Random.Range(0, 5)].transform.position.y;
        float z = enemyModel.spawnLocations[Random.Range(0, 5)].transform.position.z;
        spawnLocation = new Vector3(x, y, z);
    }

    private void setEnemyAIControllerRef()
    {
        if (this != null)
        {
            enemyAI.setControllerRef(this);
        }
    }
}
