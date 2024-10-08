using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnTime = 2f;
    private float elapseTime = 0f;

    void Update()
    {
        SpawnLoop();
    }

    void SpawnLoop()
    {
        this.elapseTime += Time.deltaTime;
        if (elapseTime >= spawnTime)
        {
            Spawn();
            this.elapseTime = 0;
        }
    }

    void Spawn()
    {
        GameObject obstacle = ObstaclePool.SharedInstance.GetPooledObject();
        if (obstacle != null)
        {
            obstacle.SetActive(true);
        }
    }
}
