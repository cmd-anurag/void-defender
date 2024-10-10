using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileAsteroidScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]GameObject[] asteroidPrefabs;
    [SerializeField]private float spawnInterval = 15f;
    [SerializeField]private int radius = 10;
    private GameObject spaceship;

    
    private float AsteroidSpeed;
    int offsetFromOrigin;
    void Start()
    {
        spaceship = GameObject.FindGameObjectWithTag("SpaceShip");
        InvokeRepeating(nameof(SpawnHostileAsteroid), 10f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnHostileAsteroid() {
        Vector3 spawnPosition;
        float randomAngle = UnityEngine.Random.Range(0, 360) * Mathf.Deg2Rad;

        spawnPosition.x = (spaceship.transform.position.x + radius) * Mathf.Sin(randomAngle);
        spawnPosition.y = (spaceship.transform.position.x + radius) * Mathf.Cos(randomAngle);
        spawnPosition.z = 0;

        GameObject Asteroid = Instantiate(GetRandomAsteroid(), spawnPosition, Quaternion.identity);

        float scale = UnityEngine.Random.Range(1.5f, 2.0f);
        Asteroid.transform.localScale = new(scale, scale);
        AsteroidSpeed = UnityEngine.Random.Range(1f, 3f);
        offsetFromOrigin = UnityEngine.Random.Range(-4, 4);

        Vector2 directionToPLayer = spaceship.transform.position - spawnPosition;
        Asteroid.GetComponent<Rigidbody2D>().velocity = directionToPLayer.normalized * AsteroidSpeed;
        Destroy(Asteroid, spawnInterval);
    }

    GameObject GetRandomAsteroid() {
        int randomIndex = UnityEngine.Random.Range(0, asteroidPrefabs.Length);
        return asteroidPrefabs[randomIndex];
    }
}
