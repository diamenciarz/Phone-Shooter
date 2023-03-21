using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPosition : MonoBehaviour
{
    [SerializeField][Tooltip("The maximum turn speed in degrees per second")] float turnSpeed = 180;

    private Vector2 rotateTowards;

    private void Start()
    {
        rotateTowards = Vector2.zero;
    }
    public void SetNewPosition(Vector2 newPosition)
    {
        rotateTowards = newPosition;
    }

    private void Update()
    {
        float deltaAngleToTarget = CalculateDeltaRotation();
        float moveThisFrame = Mathf.Clamp(deltaAngleToTarget, -turnSpeed * Time.deltaTime, turnSpeed *Time.deltaTime);
        RotateBy(moveThisFrame);
    }

    private float CalculateDeltaRotation()
    {
        Vector2 deltaPositionToTarget = rotateTowards - (Vector2) transform.position;
        float deltaAngleToTarget = Mathf.Atan2(deltaPositionToTarget.y, deltaPositionToTarget.x) * Mathf.Rad2Deg;

        return deltaAngleToTarget;

    }

    private void RotateBy(float rotation)
    {
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + rotation);
    }
}
