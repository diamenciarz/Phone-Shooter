using System;
using UnityEngine;

[Serializable]
public abstract class TargetReceiver: MonoBehaviour
{
    public abstract void GiveTarget(Vector2 position);
}
