using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    internal int health { get; }
    internal int damage { get; }
    internal int moveSpeed { get; }
    internal TankTypes tankType { get; }
    
    public TankModel(TankScriptableObject tankSO)
    {
        health = tankSO.health;
        damage = tankSO.damage;
        moveSpeed = tankSO.moveSpeed;
        tankType = tankSO.tankType;
    }

}
