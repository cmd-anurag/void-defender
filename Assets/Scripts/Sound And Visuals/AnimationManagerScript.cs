using UnityEngine;

public class AnimationManagerScript : MonoBehaviour
{
    [SerializeField]private GameObject spaceshipExplosionPrefab;
    [SerializeField]private GameObject ObjectPools;
    private ObjectPoolsScript objectPoolsScript;

    private void OnEnable() {
        EnemyScript.OnEnemyDeath += DeathExplosion;
        SpaceshipControllerScript.OnSpaceShipDeath += SpaceShipDeathExplosion;
    }
    private void OnDisable() {
        EnemyScript.OnEnemyDeath -= DeathExplosion;

    }

    void Start() {
        objectPoolsScript = ObjectPools.GetComponent<ObjectPoolsScript>();
    }

    private void DeathExplosion(int s, Transform transform) {
        objectPoolsScript.GetExplosion(transform.position);
    }

    private void SpaceShipDeathExplosion(Transform spaceshipTransform) {
        GameObject explosion = Instantiate(spaceshipExplosionPrefab, spaceshipTransform.position, Quaternion.identity);
        Destroy(explosion, 1.1f);
    }
    
}
