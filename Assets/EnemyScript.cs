using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.01f;
    public int health = 3;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("SpaceShip").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if(!target) {
            Debug.Log("Target not found");
            return;
        }
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += speed * Time.deltaTime * direction * 0.5f;
    }
    public void TakeUnitDamage() {
        health -= 1;
        if(health <= 0) {
            Destroy(gameObject);
        }
    }
}
