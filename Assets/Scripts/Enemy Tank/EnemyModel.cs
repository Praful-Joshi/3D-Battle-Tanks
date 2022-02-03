using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    internal int id;
    internal GameObject enemyPrefab;
    internal float health { get; set; }
    internal int damage { get; }
    internal float moveSpeed { get; }
    internal float turnSpeed { get; }
    internal List<Transform> spawnLocations { get; }
    internal List<Transform> waypoints;

    public EnemyModel(EnemySO enemySO)
    {
        id = enemySO.id;
        enemyPrefab = enemySO.enemyPrefab;
        health = enemySO.health;
        damage = enemySO.damage;
        moveSpeed = enemySO.moveSpeed;
        turnSpeed = enemySO.turnSpeed;
        spawnLocations = enemySO.spawnLocations;
        waypoints = enemySO.waypoints;
    }
}
