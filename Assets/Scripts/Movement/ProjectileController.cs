using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField][Tooltip("The maximum velocity in units per second")] float velocity;

    private const int DESTROY_DELAY_MILIS = 5000;
    private CancellationTokenSource cancellationTokenSource;

    // Start is called before the first frame update
    void Start()
    {
        SetDestroyDelay();
    }

    private void OnDestroy()
    {
        cancellationTokenSource?.Cancel();
    }

    private async void SetDestroyDelay()
    {
        cancellationTokenSource = new CancellationTokenSource();
        try
        {
            await Task.Delay(DESTROY_DELAY_MILIS, cancellationTokenSource.Token);
        }
        catch
        {
            return;
        }
        finally
        {
            cancellationTokenSource.Dispose();
            cancellationTokenSource = null;
        }
        Destroy(gameObject);
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
