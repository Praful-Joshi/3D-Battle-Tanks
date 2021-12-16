using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tankPrefabs = new GameObject[3];
    [SerializeField]
    private GameObject spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    private void spawn()
    {
        Instantiate(tankPrefabs[Random.Range(0, 3)], spawnPosition.transform.position, transform.rotation);
    }
}
