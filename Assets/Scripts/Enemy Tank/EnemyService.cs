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
    private GameObject enemy;

    //variable declaration
    public EnemySO[] enemySO;
    private EnemySO enemyScriptableObject;

    protected override void Awake()
    {
        base.Awake();
        createNewEnemyTank();
        enemyController.controllerAwake();
    }

    private void Start()
    {
        
    }

    private void createNewEnemyTank()
    {
        enemyScriptableObject = enemySO[0];
        enemyModel = new EnemyModel(enemyScriptableObject);
        enemyView = enemyModel.enemyPrefab.GetComponent<EnemyView>();
        enemyController = new EnemyController(enemyModel, enemyView);
    }
}
