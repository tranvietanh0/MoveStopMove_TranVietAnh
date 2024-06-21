using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjectDatas/SOPant", order = 1)]
public class SOPant : ScriptableObject
{
    public int id;
    public Material pantPrefab;
}
