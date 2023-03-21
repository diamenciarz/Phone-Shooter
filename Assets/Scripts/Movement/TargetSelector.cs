using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelector : MonoBehaviour
{
    [SerializeField] float searchDelay = 0.05f;
    [SerializeField] bool followMouse;
    [SerializeField] List<TargetReceiver> targetReceivers = new List<TargetReceiver>();





    private void Start()
    {
        StartCoroutine(SelectTargets());
    }

    private IEnumerator SelectTargets()
    {
        while (true)
        {
            Vector2 targetPosition = Vector2.zero;
            if (followMouse)
            {
                targetPosition = HelperMethods.VectorUtils.TranslatedMousePosition();
            }

            foreach (TargetReceiver targetReceiver in targetReceivers)
            {
                targetReceiver.GiveTarget(targetPosition);
            }

            yield return new WaitForSeconds(searchDelay);
        }

    }
}
