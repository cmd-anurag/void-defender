using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // TODO - Implement object pooling for bullets
    public float speed = 30f;
    private Vector2 direction;
    private Rigidbody2D rb;
    public void Initialize(Vector2 dir) {
        this.direction = dir.normalized;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;
        Destroy(gameObject, 5f);
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("EnemySpaceShip")) {
            other.GetComponent<EnemyScript>().TakeUnitDamage();
        }
        Destroy(gameObject, 0.01f);
    }
}
