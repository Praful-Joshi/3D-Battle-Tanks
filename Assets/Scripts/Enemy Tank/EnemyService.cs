using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : GenericSingleton<EnemyService>
{
    //other scripts declaration
    internal EnemyModel enemyModel;
    private EnemyController enemyController;
    private EnemyView enemyView;

    //component declaration
    public GameObject enemyTankPrefab;
    public GameObject[] spawnLocations;
    private Vector3 spawnLocation;

    //variable declaration
    public EnemySO[] enemySO;
    private EnemySO enemyScriptableObject;


    protected override void Awake()
    {
        base.Awake();
        createNewEnemyTank();
        spawnEnemyPrefab();
    }

    private void createNewEnemyTank()
    {
        enemyScriptableObject = enemySO[0];
        enemyModel = new EnemyModel(enemyScriptableObject);
        enemyView = enemyTankPrefab.GetComponent<EnemyView>();
        enemyController = new EnemyController(enemyModel, enemyView);
    }

    private void spawnEnemyPrefab()
    {
        float x = spawnLocations[Random.Range(0, 5)].transform.position.x;
        float y = spawnLocations[Random.Range(0, 5)].transform.position.y;
        float z = spawnLocations[Random.Range(0, 5)].transform.position.z;
        spawnLocation = new Vector3(x,y,z);
        Instantiate(enemyTankPrefab, spawnLocation, Quaternion.identity);
    }
}
