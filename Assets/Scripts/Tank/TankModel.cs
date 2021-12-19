using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    internal int health { get; }
    internal int damage { get; }
    internal float moveSpeed { get; }
    internal float turnSpeed { get; }
    internal string color { get; }
    internal TankTypes tankType { get; }
    internal GameObject tankPrefab;
    
    public TankModel(TankScriptableObject tankSO)
    {
        health = tankSO.health;
        damage = tankSO.damage;
        moveSpeed = tankSO.moveSpeed;
        turnSpeed = tankSO.turnSpeed;
        color = tankSO.color;
        tankType = tankSO.tankType;
        tankPrefab = tankSO.tankPrefab;
    }
}
