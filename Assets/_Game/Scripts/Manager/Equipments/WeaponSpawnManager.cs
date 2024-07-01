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
        Debug.Log("Spawn");
        SOWeapon weaponModelOnPlayer = GetCurrentWeapon(id);
        Vector3 localPos = weaponModelOnPlayer.weaponModel.transform.localPosition;
        Quaternion localRos = weaponModelOnPlayer.weaponModel.transform.localRotation;
        WeaponModel weaponModel = SimplePool.Spawn<WeaponModel>(weaponModelOnPlayer.weaponModel, Vector3.zero, Quaternion.identity);
        weaponModel.gameObject.transform.SetParent(weaponHand);
        weaponModel.gameObject.transform.localPosition = localPos;
        weaponModel.gameObject.transform.localRotation = localRos;
    }
    
    // public WeaponModel SpawnWeaponModel(Transform weaponHand, int id)
    // {
    //     SOWeapon weaponModelOnPlayer = GetCurrentWeapon(id);
    //     Debug.Log(id);
    //     WeaponModel weaponModel = SimplePool.Spawn<WeaponModel>(weaponModelOnPlayer.weaponModel, weaponHand.position, Quaternion.identity);
    //     weaponModel.gameObject.transform.SetParent(weaponHand);
    //     return weaponModel;
    // }

    public Weapon SpawnWeaponToAttack(Transform targetPos, int id, Transform weapondHand)
    {
        Weapon weapon = SimplePool.Spawn<Weapon>(GetCurrentWeapon(id).weaponPrefab, weapondHand.position,
            Quaternion.identity);
        weapon.SetTargetPos(targetPos);
        return weapon;
    }
    public Weapon ESpawnWeaponToAttack(Transform targetPos, int id, Transform weapondHand)
    {
        Weapon weapon = SimplePool.Spawn<Weapon>(GetCurrentWeapon(id).weaponPrefab, weapondHand.position,
            Quaternion.identity);
        weapon.SetTargetPos(targetPos);
        return weapon;
    }
    private void ClearPastWeapon(Transform parent)
    {
        if (!parent || parent.childCount <= 0)
        {
            return;
        }

        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);

            if (child)
            {
                Destroy(child.gameObject);
            }
        }
    }
    
}
