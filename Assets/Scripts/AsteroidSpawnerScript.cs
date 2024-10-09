using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AsteroidSpawnerScript : MonoBehaviour
{
    [SerializeField]private Sprite[] AsteroidSprites;
    [SerializeField]private GameObject AsteroidPrefab;

    [SerializeField]private float spawnInterval = 10f;
    [SerializeField]private int radius = 5;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroid), 0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAsteroid() {
        float randomAngle = UnityEngine.Random.Range(0,359) * Mathf.Deg2Rad;
        Vector2 spawnPosition;
        spawnPosition.x = radius * Mathf.Sin(randomAngle);
        spawnPosition.y = radius * Mathf.Cos(randomAngle);

        GameObject Asteroid = Instantiate(AsteroidPrefab, spawnPosition, Quaternion.identity);

        float scale = UnityEngine.Random.Range(1.0f, 1.8f);
        Asteroid.transform.localScale = new(scale, scale);
        Asteroid.GetComponent<SpriteRenderer>().sprite = GetRandomSprite();
        Vector2 directionToOrigin = new(-spawnPosition.x, -spawnPosition.y);
        Asteroid.GetComponent<Rigidbody2D>().velocity = directionToOrigin.normalized;
    }

    Sprite GetRandomSprite() {
        int randomIndex = UnityEngine.Random.Range(0, AsteroidSprites.Length);
        return AsteroidSprites[randomIndex];
    }
}
