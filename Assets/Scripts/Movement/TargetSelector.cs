using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelector : MonoBehaviour
{
    enum FollowType
    {
        MOUSE,
        FINGER
    }

    [SerializeField] float searchDelay = 0.05f;
    [SerializeField] FollowType followType;
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
            if (followType == FollowType.FINGER)
            {
                if (Input.touchCount > 0)
                {
                    targetPosition = HelperMethods.VectorUtils.TranslatedTouchPosition();
                }
            }
            else
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
