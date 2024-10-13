using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    private Transform SpaceShip;


    // Start is called before the first frame update
    void Start()
    {
        SpaceShip = GameObject.FindGameObjectWithTag("SpaceShip").transform;
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    void SpawnEnemy() {
        // Randomly choose X and Y values ensuring minimum distance from the spaceship
        float spawnX = SpaceShip.position.x + (UnityEngine.Random.Range(10f, 20f) * (UnityEngine.Random.value > 0.5f ? 1 : -1));
        float spawnY = SpaceShip.position.y + (UnityEngine.Random.Range(5f, 15f) * (UnityEngine.Random.value > 0.5f ? 1 : -1));

        // Create the spawn position
        Vector2 randomSpawn = new Vector2(spawnX, spawnY);

        // Spawn the enemy at the calculated position
        Instantiate(enemyPrefab, randomSpawn, Quaternion.identity);
}


}
