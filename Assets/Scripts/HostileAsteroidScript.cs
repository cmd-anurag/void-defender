using UnityEngine;

public class HostileAsteroidScript : MonoBehaviour
{
    // REFERENCES
    private GameObject SpaceShip;
    [SerializeField]GameObject[] asteroidPrefabs;


    // Asteroid Properties
    [SerializeField]private float spawnInterval = 15f;
    [SerializeField]private int radius = 15;
    private float AsteroidSpeed;

    
    void Start()
    {
        SpaceShip = GameObject.FindGameObjectWithTag("SpaceShip");
        InvokeRepeating(nameof(SpawnHostileAsteroid), 10f, spawnInterval);
    }

    void OnEnable() {
        SpaceshipControllerScript.OnSpaceShipDeath += HandleSpaceShipDeath;
    }

    void OnDisable() {
        SpaceshipControllerScript.OnSpaceShipDeath -= HandleSpaceShipDeath;
    }
    
    void SpawnHostileAsteroid() {
        if(!SpaceShip) return;

        
        Vector3 spawnPosition;
        float randomAngle = UnityEngine.Random.Range(0, 360) * Mathf.Deg2Rad;

        spawnPosition.x = (SpaceShip.transform.position.x + radius) * Mathf.Sin(randomAngle);
        spawnPosition.y = (SpaceShip.transform.position.x + radius) * Mathf.Cos(randomAngle);
        spawnPosition.z = 0;

        GameObject Asteroid = Instantiate(GetRandomAsteroid(), spawnPosition, Quaternion.identity);

        float scale = UnityEngine.Random.Range(1.5f, 2.0f);
        Asteroid.transform.localScale = new(scale, scale);
        AsteroidSpeed = UnityEngine.Random.Range(3f, 4f);

        Vector2 directionToPLayer = SpaceShip.transform.position - spawnPosition;
        Asteroid.GetComponent<Rigidbody2D>().velocity = directionToPLayer.normalized * AsteroidSpeed;
        Destroy(Asteroid, 20f);
    }

    GameObject GetRandomAsteroid() {
        int randomIndex = UnityEngine.Random.Range(0, asteroidPrefabs.Length);
        return asteroidPrefabs[randomIndex];
    }

    void HandleSpaceShipDeath() {
        SpaceShip = null;
    }
}
