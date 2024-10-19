using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{

    // REFERENCES
    public GameObject enemyPrefab;
    private Transform SpaceShip;

    // Properties
    public float spawnInterval = 2f;

    void Start()
    {
        SpaceShip = GameObject.FindGameObjectWithTag("SpaceShip").transform;
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    void OnEnable() {
        SpaceshipControllerScript.OnSpaceShipDeath += HandleSpaceShipDeath;
    }

    void OnDisable() {
        SpaceshipControllerScript.OnSpaceShipDeath -= HandleSpaceShipDeath;
    }

    void SpawnEnemy() {
        if(!SpaceShip) return;

        // transition to polar coordinates
        float spawnX = SpaceShip.position.x + (UnityEngine.Random.Range(10f, 20f) * (UnityEngine.Random.value > 0.5f ? 1 : -1));
        float spawnY = SpaceShip.position.y + (UnityEngine.Random.Range(5f, 15f) * (UnityEngine.Random.value > 0.5f ? 1 : -1));
        
        Vector2 randomSpawn = new Vector2(spawnX, spawnY);

        Instantiate(enemyPrefab, randomSpawn, Quaternion.identity);
    }

    void HandleSpaceShipDeath() {
        SpaceShip = null;
    }
}
