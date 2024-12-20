using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefeb;

    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;

    private float spawnTime;
    private float randomSpawn;

    private void Awake()
    {
        SetTimeSpawn();
        SetRandomSpawn();
    }

    private void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
            if (randomSpawn <= 2)
            {
                SetSpawn(0);
            }
            else if (randomSpawn == 3)
            {
                SetSpawn(1);
            }
            SetTimeSpawn();
        }

        Debug.Log(randomSpawn);
    }

    private void SetSpawn(int e)
    {
        Instantiate(enemyPrefeb[e], transform.position, Quaternion.identity);
        SetRandomSpawn();
    }

    private void SetRandomSpawn()
    {
        randomSpawn = Random.Range(1, 4);
    }

    private void SetTimeSpawn()
    {
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
