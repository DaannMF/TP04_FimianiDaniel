using System;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {
    [SerializeField] private GameObject[] obstaclePrefabs;

    private List<GameObject> obstaclePool;
    private static ObstaclePool instance;

    public static ObstaclePool SharedInstance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<ObstaclePool>();
            }
            return instance;
        }
    }

    private void Start() {
        LoadPool();
    }

    private void LoadPool() {
        this.obstaclePool = new List<GameObject>(obstaclePrefabs.Length);
        for (int i = 0; i < this.obstaclePrefabs.Length; i++) {
            GameObject obstacle = Instantiate(obstaclePrefabs[i]);
            obstacle.SetActive(false);
            this.obstaclePool.Add(obstacle);
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < this.obstaclePrefabs.Length; i++) {
            if (!this.obstaclePool[i].activeInHierarchy) {
                return this.obstaclePool[i];
            }
        }
        return null;
    }

    public void DeactivateInstances() {
        if (this.obstaclePool is not null) {
            for (int i = 0; i < this.obstaclePrefabs.Length; i++) {
                this.obstaclePool[i].SetActive(false);
            }
        }
    }
}
