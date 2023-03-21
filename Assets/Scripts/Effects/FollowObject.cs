using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;
    [SerializeField] Vector2 deltaPosition;
    [SerializeField] bool rotateWithObject;
    [SerializeField] float deltaRotation;

    [SerializeField] bool spriteAlwaysBelow;
    // Start is called before the first frame update
    void Start()
    {
        if (spriteAlwaysBelow)
        {
            SpriteRenderer objectToFollowRenderer = objectToFollow.GetComponent<SpriteRenderer>();
            SpriteRenderer myRenderer = GetComponent<SpriteRenderer>();
            if (objectToFollowRenderer)
            {
                myRenderer.sortingOrder = objectToFollowRenderer.sortingOrder - 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        UpdateRotation();
    }

    private void UpdatePosition()
    {
        transform.position = new Vector2(objectToFollow.transform.position.x, objectToFollow.transform.position.y) + deltaPosition;
    }
    private void UpdateRotation()
    {
        if (rotateWithObject)
        {
            transform.rotation = Quaternion.Euler(0,0, objectToFollow.transform.rotation.z + deltaRotation);
        }
    }
}
