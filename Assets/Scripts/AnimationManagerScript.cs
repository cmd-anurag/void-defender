using UnityEngine;

public class AnimationManagerScript : MonoBehaviour
{
    [SerializeField]private GameObject ObjectPools;
    private ObjectPoolsScript objectPoolsScript;

    private void OnEnable() {
        EnemyScript.OnEnemyDeath += DeathExplosion;
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
    
}