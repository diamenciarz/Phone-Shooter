using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Wave", menuName = "Scriptable Objects/Wave")]
public class Wave : ScriptableObject
{
    public List<GameObject> enemies = new List<GameObject>();
}
