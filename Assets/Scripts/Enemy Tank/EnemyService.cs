using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : GenericSingleton<EnemyService>
{
    //other scripts declaration
    internal EnemyModel enemyModel;
    private EnemyController enemyController;
    private EnemyView enemyView;
    private EnemySO enemyScriptableObject;
    public EnemySO[] enemySO;
    private List<EnemyController> createdEnemyControllers;
    
    protected override void Awake()
    {
        base.Awake();
        createNewEnemyTank();
        enemyController.controllerAwake();    
    }

    private void Start()
    { 
        enemyController.controllerStart();
    }

    private EnemyController createNewEnemyTank()
    {
        enemyScriptableObject = enemySO[0];
        enemyModel = new EnemyModel(enemyScriptableObject);
        enemyView = enemyModel.enemyPrefab.GetComponent<EnemyView>();
        enemyController = new EnemyController(enemyModel, enemyView);
        return enemyController;
    }
}
