using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3f;
    public int health = 3;
    public ScoreManagerScript scoreManagerScript;
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
        transform.position += speed * Time.deltaTime * direction;
    }
    public void TakeUnitDamage() {
        Transform heart = transform.GetChild(0);
        Destroy(heart.gameObject);
        health -= 1;
        if(health == 0) {
            HandleEnemyDeath();
        }
    }
    private void HandleEnemyDeath() {
        audioSource.Play();
        ps.Play();
        GetComponent<SpriteRenderer>().enabled = false;
        ScoreManagerScript.Instance.AddUnitScore();
        Destroy(gameObject, audioSource.clip.length);
    }
}
