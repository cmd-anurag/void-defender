using UnityEngine;

public class FollowSpaceshipScript : MonoBehaviour
{

    public Transform spaceship;
    public Vector3 offset;
    
    private Vector3 velocity = Vector3.zero;
    
    void Start()
    {
        offset = new(0,0,-10);
    }

    void LateUpdate() {
        Vector3 targetPos = spaceship.position + offset;
        Vector3 smoothedPos = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 0);
        transform.position = smoothedPos;
    }
}
