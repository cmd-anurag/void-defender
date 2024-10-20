using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class FollowSpaceshipScript : MonoBehaviour
{


    // REFERENCES
    public Transform spaceship;


    // Camera Properties
    public Vector3 offset;
    [SerializeField]private float smoothSpeed;
    [SerializeField]private Vector3 velocity = Vector3.zero;

    
    private void OnEnable() {
        SpaceshipControllerScript.OnSpaceShipDeath += HandleSpaceShipDeath;
    }

    private void OnDisable() {
        SpaceshipControllerScript.OnSpaceShipDeath -= HandleSpaceShipDeath;
    }

    void Start()
    {
        offset = new(0,0,-10);
    }

    void LateUpdate() {
        if(spaceship) {
            Vector3 targetPos = spaceship.position + offset;
            Vector3 smoothedPos = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothSpeed);
            transform.position = smoothedPos;
        }
    }

    void HandleSpaceShipDeath(Transform position) {
        spaceship = null;
    }

}
