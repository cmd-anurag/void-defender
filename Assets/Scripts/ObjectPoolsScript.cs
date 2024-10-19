using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolsScript : MonoBehaviour
{
    // OBJECT POOLS
    private Queue<GameObject> explosionPool = new();
    private Queue<GameObject> bulletPool = new();


    // OBJECT PREFABS
    [SerializeField]private GameObject explosionPrefab;
    [SerializeField]private GameObject bulletPrefab;

    
    // Pool Sizes
    private int explosionPoolSize = 5;
    private int bulletPoolSize = 20;

    void Start()
    {
        // initialize the explosion pool
        for(int i = 0; i < explosionPoolSize; ++i) {
            GameObject explosion = Instantiate(explosionPrefab);
            explosion.SetActive(false);
            explosionPool.Enqueue(explosion);
        }

        // initialize the bullet pool
        for(int i = 0; i < bulletPoolSize; ++i) {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    // Getter for explosion gameobject
    public void GetExplosion(Vector3 position) {
        if(explosionPool.Count <= 0) {
            
            ExpandBulletPool();
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



    // getter for bullet gameobject
    public GameObject GetBullet(Transform BulletSpawn) {
        if(bulletPool.Count < 1) {
            // expand the pool
            return null;
        }
        GameObject bullet = bulletPool.Dequeue();
        bullet.transform.SetPositionAndRotation(BulletSpawn.position, BulletSpawn.rotation);
        bullet.SetActive(true);

        StartCoroutine(ReturnBulletAfterDelay(bullet, 4f));
        return bullet;
    }

    private IEnumerator ReturnBulletAfterDelay(GameObject bullet, float delay) {
        yield return new WaitForSeconds(delay);
        ReturnBulletToPool(bullet);
    }

    private void ReturnBulletToPool(GameObject bullet) {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }

    private void ExpandBulletPool() {
        for(int i = 0; i < 10; ++i) {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }
}
