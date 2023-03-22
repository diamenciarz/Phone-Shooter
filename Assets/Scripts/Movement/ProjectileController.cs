using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField][Tooltip("The maximum velocity in units per second")] float velocity;

    private const int DESTROY_DELAY = 5;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DESTROY_DELAY);
    }

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
