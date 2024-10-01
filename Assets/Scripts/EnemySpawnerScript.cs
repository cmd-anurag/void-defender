using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float spawnInterval = 2f;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy() {
        Vector2 randomSpawn1 = new(UnityEngine.Random.Range(-10f, 10f), 5f);
        Vector2 randomSpawn2 = new(UnityEngine.Random.Range(-10f, 10f), -5f);
        Vector2 randomSpawn3 = new(10f, UnityEngine.Random.Range(-5f, 5f));
        Vector2 randomSpawn4 = new(-10f, UnityEngine.Random.Range(-5f, 5f));

        Vector2[] spawnPoints = { randomSpawn1, randomSpawn2, randomSpawn3, randomSpawn4 };
        Vector2 randomSpawn = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];

        Instantiate(enemyPrefab, randomSpawn, quaternion.identity);
    }
}
