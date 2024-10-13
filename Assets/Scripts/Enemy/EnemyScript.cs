using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    // EVENTS of GameObject
    public delegate void EnemyDeath(int score, Transform position);

    public static event EnemyDeath OnEnemyDeath;


    // Properties of GameObject
    public float speed = 3f;
    public int health = 3;
    private bool isMoving = true;


    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("SpaceShip").transform;
    }

    void Update()
    {
        if(target && isMoving) {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += speed * Time.deltaTime * direction;
        }
    }

    public void TakeUnitDamage() {
        if(health <= 0) return;
        Transform heart = transform.GetChild(0);
        Destroy(heart.gameObject);
        health -= 1;
        if(health == 0) {
            HandleEnemyDeath();
        }
    }
    private void HandleEnemyDeath() {
        OnEnemyDeath?.Invoke(1, gameObject.transform);
        isMoving = false;  
        Destroy(gameObject);
    }
}
