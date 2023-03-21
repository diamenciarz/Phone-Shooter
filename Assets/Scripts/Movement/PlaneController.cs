using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{

    [SerializeField][Tooltip("The maximum velocity in units per second")] float velocity;
    [SerializeField][Tooltip("The maximum turn speed in degrees per second")] float turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlane();
    }

    private void MovePlane()
    {
        Vector3 deltaMovement = transform.right * velocity;
        transform.position += deltaMovement * Time.deltaTime;
    }
}
