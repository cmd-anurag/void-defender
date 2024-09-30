using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
        other.GetComponent<EnemyScript>().TakeUnitDamage();
    }
}
