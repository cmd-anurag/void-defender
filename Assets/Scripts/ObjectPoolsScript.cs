using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolsScript : MonoBehaviour
{
    // OBJECT POOLS
    private Queue<GameObject> explosionPool = new();


    // OBJECT PREFABS
    [SerializeField]private GameObject explosionPrefab;

    private int poolSize = 10;

    void Start()
    {
        for(int i = 0; i < poolSize; ++i) {
            GameObject explosion = Instantiate(explosionPrefab);
            explosion.SetActive(false);
            explosionPool.Enqueue(explosion);
        }
    }

    // Getter for explosion gameobject
    public void GetExplosion(Vector3 position) {
        if(explosionPool.Count <= 0) {
            return;
        }
        GameObject explosion = explosionPool.Dequeue();
        explosion.transform.position = position;
        explosion.SetActive(true);
        
        // return this gameobject after a delay 
        StartCoroutine(ReturnExplosionAfterDelay(explosion, 1f));
    }


    private IEnumerator ReturnExplosionAfterDelay(GameObject explosion, float delay) {
        yield return new WaitForSeconds(delay);
        ReturnExplosionToPool(explosion);
    }


    // return the explosion object and enqueue it back to object pool
    private void ReturnExplosionToPool(GameObject explosion) {
        explosion.SetActive(false);
        explosionPool.Enqueue(explosion);
    }
}
