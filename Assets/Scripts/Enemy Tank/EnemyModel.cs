using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    internal GameObject enemyPrefab;
    internal int health { get; }
    internal int damage { get; }
    internal float moveSpeed { get; }
    internal float turnSpeed { get; }
    internal string color { get; }
    internal List<Transform> spawnLocations { get; }

    public EnemyModel(EnemySO enemySO)
    {
        enemyPrefab = enemySO.enemyPrefab;
        health = enemySO.health;
        damage = enemySO.damage;
        moveSpeed = enemySO.moveSpeed;
        turnSpeed = enemySO.turnSpeed;
        color = enemySO.color;
        spawnLocations = enemySO.spawnLocations;
    }
}
