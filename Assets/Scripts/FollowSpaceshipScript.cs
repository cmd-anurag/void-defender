using UnityEngine;

public class FollowSpaceshipScript : MonoBehaviour
{

    public Transform spaceship;
    public Vector3 offset;
    [SerializeField]private float smoothSpeed = 0.125f;
    [SerializeField]private Vector3 velocity = Vector3.zero;
    
    void Start()
    {
        offset = new(0,0,-10);
    }

    void LateUpdate() {
        Vector3 targetPos = spaceship.position + offset;
        Vector3 smoothedPos = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothSpeed);
        transform.position = smoothedPos;
    }
}
