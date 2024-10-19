using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Bullet Properties
    [SerializeField] private float speed = 40f;
    
    // References
    private Rigidbody2D rb;

    void OnEnable() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void InitializeBullet(Vector3 travelDirection) {
        rb.velocity = speed * travelDirection.normalized;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // try decoupling it
        if(other.CompareTag("EnemySpaceShip")) {
            gameObject.SetActive(false);
            other.GetComponent<EnemyScript>().TakeUnitDamage();
        }
    }
}
