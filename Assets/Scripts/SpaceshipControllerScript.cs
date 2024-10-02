using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipControllerScript : MonoBehaviour
{

    private PlayerInputActions playerInputActions;
    private Camera mainCamera;

    public GameObject bulletPrefab;
    public float recoilForce = 0.5f;
    public Transform bulletSpawnPoint;
    private AudioSource audioSource;

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

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 userMouseposition = playerInputActions.Spaceship.Look.ReadValue<Vector2>();
        RotateTowardsMouse(userMouseposition);
        // KeepWithinBounds();
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

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        BulletScript bulletScript = bullet.GetComponent<BulletScript>();
        audioSource.Play();
        
        bulletScript.Initialize(transform.up);

        Vector3 recoilDirection = -transform.up;
        GetComponent<Rigidbody2D>().AddForce(recoilDirection * recoilForce, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("EnemySpaceShip")) Debug.Log("Game Over");
    }
    // 
    // private void KeepWithinBounds()
    // {
    //     Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

    //     Vector3 clampedPosition = transform.position;
    //     clampedPosition.x = Mathf.Clamp(clampedPosition.x, -screenBounds.x, screenBounds.x);
    //     clampedPosition.y = Mathf.Clamp(clampedPosition.y, -screenBounds.y, screenBounds.y);

    //     transform.position = clampedPosition;
    // }
}
