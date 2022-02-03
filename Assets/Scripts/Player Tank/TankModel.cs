using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    internal GameObject tankPrefab;
    internal float health { get; set; }
    internal int damage { get; }
    internal float moveSpeed { get; }
    internal float turnSpeed { get; }
    internal string color { get; }
    internal TankTypes tankType { get; }
    internal AudioClip idlingClip;
    internal AudioClip drivingClip;

    public TankModel(TankScriptableObject tankSO)
    {
        tankPrefab = tankSO.tankPrefab;
        health = tankSO.health;
        damage = tankSO.damage;
        moveSpeed = tankSO.moveSpeed;
        turnSpeed = tankSO.turnSpeed;
        color = tankSO.color;
        tankType = tankSO.tankType;
        idlingClip = tankSO.idlingClip;
        drivingClip = tankSO.drivingClip;
    }
}
