using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjectDatas/SOHair", order = 1)]
public class SOHair : ScriptableObject
{
    public Skin hairPrefab;
    public int id;
}
