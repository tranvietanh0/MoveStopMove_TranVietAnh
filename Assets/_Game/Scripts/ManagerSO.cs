using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSO : Singleton<ManagerSO>
{
    public List<SOWeapon> SOWeaponLists = new List<SOWeapon>();
    public List<SOShield> SOShieldLists = new List<SOShield>();
}
