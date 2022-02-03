using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Bullet Scriptable Object", menuName = "New Bullet")]
public class BulletSO : ScriptableObject
{
    public int source;
    public float speed;
    public int damage;
}
