using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawnManager : Singleton<WeaponSpawnManager>
{

    public SOWeapon GetCurrentWeapon(int id)
    {
        for (int i = 0; i < ManagerSO.Ins.SOWeaponLists.Count; i++)
        {
            if (ManagerSO.Ins.SOWeaponLists[i].id == id)
            {
                return ManagerSO.Ins.SOWeaponLists[i];
            }
        }

        return ManagerSO.Ins.SOWeaponLists[0];
    }

    public void SpawnPlayerWeaponModel(Transform weaponHand, int id)
    {
        SOWeapon weaponModelOnPlayer = GetCurrentWeapon(id);
        WeaponModel weaponModel = SimplePool.Spawn<WeaponModel>(weaponModelOnPlayer.weaponModel, weaponHand.position, Quaternion.identity);
        weaponModel.gameObject.transform.SetParent(weaponHand);
    }
    
    
}
