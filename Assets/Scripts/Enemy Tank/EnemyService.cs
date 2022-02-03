using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : GenericSingleton<EnemyService>
{
    //other scripts declaration
    internal static EnemyModel enemyModel;
    private EnemyController enemyController;
    private EnemySO enemyScriptableObject;
    public EnemySO[] enemySO;
    private List<EnemyController> createdEnemyControllers;
    
    protected override void Awake()
    {
        base.Awake();

        createdEnemyControllers = new List<EnemyController>();
        createdEnemyControllers.Add(createNewEnemyTank()); 
    }

    private void Start()
    { 

    }

    private EnemyController createNewEnemyTank()
    {
        enemyScriptableObject = enemySO[0];
        enemyModel = new EnemyModel(enemyScriptableObject);
        enemyController = new EnemyController(enemyModel);
        return enemyController;
    }
}
