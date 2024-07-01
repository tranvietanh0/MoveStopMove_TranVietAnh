using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSpawnManager : Singleton<SkinSpawnManager>
{
    public SOShield GetCurrentShield(int id)
    {
        for (int i = 0; i < ManagerSO.Ins.SOShieldLists.Count; i++)
        {
            if (ManagerSO.Ins.SOShieldLists[i].id == id)
            {
                return ManagerSO.Ins.SOShieldLists[i];
            }
        }

        return ManagerSO.Ins.SOShieldLists[0];
    }

    public SOHair GetCurrentHair(int id)
    {
        for (int i = 0; i < ManagerSO.Ins.SOHairLists.Count; i++)
        {
            if (id == ManagerSO.Ins.SOHairLists[i].id)
            {
                return ManagerSO.Ins.SOHairLists[i];
            }
        }

        return ManagerSO.Ins.SOHairLists[0];
    }

    public SOPant GetCurrentPant(int id)
    {
        for (int i = 0; i < ManagerSO.Ins.SOPantLists.Count; i++)
        {
            if (id == ManagerSO.Ins.SOPantLists[i].id)
            {
                return ManagerSO.Ins.SOPantLists[i];
            }
        }

        return ManagerSO.Ins.SOPantLists[0];
    }
    public void SpawnShieldOfPlayer(Transform shieldHand, int id)
    {
        SOShield shieldOfPlayer = GetCurrentShield(id);
        Skin shieldModelOfPlayer = SimplePool.Spawn<Skin>(shieldOfPlayer.shieldPrefab, shieldHand.position, Quaternion.identity);
        shieldModelOfPlayer.gameObject.transform.SetParent(shieldHand);
    }

    public void SpawnHairOfPlayer(Transform hairPos, int id)
    {
        SOHair hairOfPlayer = GetCurrentHair(id);
        Skin hairModelOfPlayer = SimplePool.Spawn<Skin>(hairOfPlayer.hairPrefab, hairPos.position, Quaternion.identity);
        hairModelOfPlayer.gameObject.transform.SetParent(hairPos);
    }

    public void SetPantOfPlayer(SkinnedMeshRenderer skin, int id)
    {
        skin.material = GetCurrentPant(id).pantPrefab;
    }
}
