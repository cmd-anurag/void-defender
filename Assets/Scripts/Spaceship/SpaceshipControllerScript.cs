using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SpaceshipControllerScript : MonoBehaviour
{

    private PlayerInputActions playerInputActions;
    private Camera mainCamera;

    public float recoilForce = 0.5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public AudioSource shootAudio;
    public AudioSource explodeAudio;
    private ParticleSystem explodePS;

    private void Awake() {
        // initialize input action object
        playerInputActions = new PlayerInputActions();
        mainCamera = Camera.main;
    }

    private void OnEnable() {
        playerInputActions.Enable();
        playerInputActions.Spaceship.Shoot.performed += OnShoot;
    }
    private void OnDisable() {
        playerInputActions.Disable();
        playerInputActions.Spaceship.Shoot.performed -= OnShoot;
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 userMouseposition = playerInputActions.Spaceship.Look.ReadValue<Vector2>();
        RotateTowardsMouse(userMouseposition);
    }
    void RotateTowardsMouse(Vector2 userMouseposition) {
        // user mouse pos to world mouse pos
        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(new Vector3(userMouseposition.x, userMouseposition.y, mainCamera.nearClipPlane));

        // direction of mouse from spaceship
        Vector3 direction = (worldMousePosition - transform.position).normalized;

        // cakculate angle and rotate
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= 90f;

        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
    }

    void OnShoot(InputAction.CallbackContext context) {

        shootAudio.Play();
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        BulletScript bulletScript = bullet.GetComponent<BulletScript>();
        
        bulletScript.Initialize(transform.up);
        Vector3 recoilDirection = -transform.up;
        GetComponent<Rigidbody2D>().AddForce(recoilDirection * recoilForce, ForceMode2D.Impulse);

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("EnemySpaceShip")) {
            explodeAudio.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            Invoke(nameof(LoadGameOverScreen), 1f);
            Destroy(gameObject, explodeAudio.clip.length);
        }
    }
    private void LoadGameOverScreen() {
        SceneManager.LoadScene("GameOver");
    }
    
}
