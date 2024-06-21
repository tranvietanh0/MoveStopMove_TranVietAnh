using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjectDatas/SOWeapon", order = 1)]
public class SOWeapon : ScriptableObject
{
    public Weapon weaponPrefab;
    public WeaponModel weaponModel;
    public int id;

}
