using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    // EVENTS of GameObject
    public delegate void EnemyDeath(int score, Transform position);

    public static event EnemyDeath OnEnemyDeath;


    // Properties of GameObject
    public float speed = 3f;
    public int health = 3;
    // private bool isMoving = true;


    private Transform target;
    private Rigidbody2D Enemyrb;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("SpaceShip").transform;
        Enemyrb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 direction;
        if(target != null) {
            direction = (target.position - transform.position).normalized;
        }
        else {
            Debug.Log("No target found");
            direction = new(0,0,0);
        }
        Enemyrb.velocity = direction * speed;
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
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Enemy collided with "+other);
    }
}
