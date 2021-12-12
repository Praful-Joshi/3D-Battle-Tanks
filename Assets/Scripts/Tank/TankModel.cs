using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    private int speed { get; }
    private float health { get; }

    public TankModel(int speed, float health)
    {
        this.speed = speed;
        this.health = health;
    }
}
