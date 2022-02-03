using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Tank Scriptable Objects", menuName = "Scriptable Objects/New Tank")]
public class TankScriptableObject : ScriptableObject
{
    public GameObject tankPrefab;
    public TankTypes tankType;
    public float health;
    public int damage;
    public float moveSpeed;
    public float turnSpeed;
    public string color;
    public AudioClip idlingClip;
    public AudioClip drivingClip;
}
