using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSpaceshipScript : MonoBehaviour
{

    public Transform spaceship;
    public Vector3 offset;
    
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        offset = new(0,0,-10);
    }

    void LateUpdate() {
        Vector3 targetPos = spaceship.position + offset;
        Vector3 smoothedPos = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 0);
        transform.position = smoothedPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
