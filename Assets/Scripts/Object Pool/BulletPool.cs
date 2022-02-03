using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instance;
    public Bullet bulletPrefab;
    public int initialSize = 50;

    internal Queue<GameObject> bulletPool = new Queue<GameObject>();

    private void Start()
    {
        instance = this;
        initiateBulletPool();
    }

    public void initiateBulletPool()
    {
        for(int i=0; i<initialSize; i++)
        {
            bulletPool.Enqueue(bulletPrefab.gameObject);
        }
    }

    public GameObject getBullet()
    {
        GameObject bullet = bulletPool.Dequeue();
        bullet.SetActive(true);
        return bullet;
    }

    public void returnBullet(GameObject bullet)
    {
        bullet.gameObject.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}
