using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelector : MonoBehaviour
{
    [SerializeField] float searchDelay = 0.1f;
    [SerializeField] bool followMouse;




    private List<ITargetReceiver> targetReceivers = new List<ITargetReceiver>();

    private IEnumerator SelectTargets()
    {
        Vector2 targetPosition = Vector2.zero;
        if (followMouse)
        {
            
        }

        foreach (ITargetReceiver targetReceiver in targetReceivers)
        {
            targetReceiver.GiveTarget(targetPosition);
        }
    }
}
