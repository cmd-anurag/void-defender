using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SpaceshipControllerScript : MonoBehaviour
{

    // EVENTS 
    public delegate void SpaceShipDeath();
    public static event SpaceShipDeath OnSpaceShipDeath; 

    // REFERENCES
    private PlayerInputActions playerInputActions;
    private Camera mainCamera;
    [SerializeField]private GameObject ObjectPool;
    private ObjectPoolsScript objectPoolsScript;

    public Transform bulletSpawnPoint;
    private Rigidbody2D spaceshiprb;


    public AudioSource shootAudio;

    // Spaceship Properties
    public float recoilForce = 0.5f;
    private readonly float rotationSpeed = 360f;
    

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

    void Start() {
        spaceshiprb = GetComponent<Rigidbody2D>();
        objectPoolsScript = ObjectPool.GetComponent<ObjectPoolsScript>();
    }

    // using fixedupdate here since rigid body is being changed
    void FixedUpdate()
    {
        Vector2 userMouseposition = playerInputActions.Spaceship.Look.ReadValue<Vector2>();
        RotateTowardsMouse(userMouseposition);
    }

    // A function which rotates the GameObject (Spaceship) towards the mouse given the mouse position.
    void RotateTowardsMouse(Vector2 userMouseposition) {
        // user mouse pos to world mouse pos
        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(new Vector3(userMouseposition.x, userMouseposition.y, Camera.main.nearClipPlane));

        // direction of mouse from spaceship
        Vector3 direction = (worldMousePosition - transform.position).normalized;

        // cakculate angle and rotate
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    // The event function which is called when 'Shoot' Input Action is performed.
    void OnShoot(InputAction.CallbackContext context) {

        shootAudio.Play();
        
        // get a bullet from the bullet pool
        GameObject bullet = objectPoolsScript.GetBullet(bulletSpawnPoint);
        BulletScript bulletScript = bullet.GetComponent<BulletScript>();


        // set the bullet's movement direction
        bulletScript.InitializeBullet(transform.up);

        // apply recoil on spaceship
        Vector3 recoilDirection = -transform.up;
        GetComponent<Rigidbody2D>().AddForce(recoilDirection * recoilForce, ForceMode2D.Impulse);
    }
    
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("EnemySpaceShip") || other.CompareTag("Asteroid")) {
            OnSpaceShipDeath.Invoke();
            Destroy(gameObject);
        }
    }
    
}
