using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController
{
    //other scripts declaration
    internal EnemyModel enemyModel;
    private EnemyAI enemyAI;

    //declaring components
    private GameObject enemyInstance;

    //declaring variables
    internal Vector3 spawnLocation;

    public EnemyController(EnemyModel enemyModel)
    {
        this.enemyModel = enemyModel;
        generateSpawnLocation();
        enemyInstance = GameObject.Instantiate(enemyModel.enemyPrefab, spawnLocation, Quaternion.identity);

        enemyAI = enemyInstance.GetComponent<EnemyAI>();
        setEnemyAIref();
    }

    private void generateSpawnLocation()
    {
        float x = enemyModel.spawnLocations[Random.Range(0, 5)].transform.position.x;
        float y = enemyModel.spawnLocations[Random.Range(0, 5)].transform.position.y;
        float z = enemyModel.spawnLocations[Random.Range(0, 5)].transform.position.z;
        spawnLocation = new Vector3(x, y, z);
    }

    private void setEnemyAIref()
    {
        if(this != null)
        {
            enemyAI.setControllerRef(this);
        }
    }
}
