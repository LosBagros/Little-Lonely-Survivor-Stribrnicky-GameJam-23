using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawningObjects : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] objectToSpawn;

    void Start()
    {
        List<Transform> availableSpawnPoints = new List<Transform>(spawnPoints);
        for (int i = 0; i < 3; i++)
        {
            int randomIndex = Random.Range(0, availableSpawnPoints.Count);
            Transform spawnPoint = availableSpawnPoints[randomIndex];
            Instantiate(objectToSpawn[i], spawnPoint.position, spawnPoint.rotation).transform.localScale = Vector3.one * 50;
            availableSpawnPoints.RemoveAt(randomIndex);
        }
    }
}