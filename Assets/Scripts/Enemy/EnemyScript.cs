using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    // EVENTS of GameObject
    public delegate void EnemyDeath(int score, Transform position);
    public static event EnemyDeath OnEnemyDeath;


    // Properties of GameObject
    public float speed = 3f;
    public int health = 3;

    // References
    private Transform target;
    private Rigidbody2D Enemyrb;

    private void OnEnable() {
        SpaceshipControllerScript.OnSpaceShipDeath += HandleSpaceShipDeath;
    }

    private void OnDisable() {
        SpaceshipControllerScript.OnSpaceShipDeath -= HandleSpaceShipDeath;
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("SpaceShip").transform;
        Enemyrb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 direction = new(1,0,0);
        if(target != null) {
            direction = (target.position - transform.position).normalized;
        }
        Enemyrb.velocity = direction * speed;
    }

    public void TakeUnitDamage() {
        if(health <= 0) return;
        Transform heart = transform.GetChild(0);
        Destroy(heart.gameObject);
        health -= 1;
        if(health == 0) {
            DestroyEnemy();
        }
    }
    private void DestroyEnemy() {
        OnEnemyDeath?.Invoke(1, gameObject.transform);
        Destroy(gameObject);
    }

    private void HandleSpaceShipDeath() {
        target = null;
    }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     Debug.Log("Enemy collided with "+other);
    // }
}
