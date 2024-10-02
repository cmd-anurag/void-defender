using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.01f;
    public int health = 3;
    private AudioSource audioSource;
    private ParticleSystem ps;
    private Transform target;

    void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
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
        Transform heart = transform.GetChild(0);
        Destroy(heart.gameObject);
        health -= 1;
        if(health <= 0) {
            audioSource.Play();
            ps.Play();
            // fix this
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
