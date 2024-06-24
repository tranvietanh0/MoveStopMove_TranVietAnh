using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bot : Character
{
    [SerializeField] private Transform weaponHand;
    [SerializeField] private Transform shieldHand;
    [SerializeField] private Transform hairPos;
    [SerializeField] private SkinnedMeshRenderer pantSkin;
    private IState<Bot> currentState;

    private void Start()
    {
        // OnWeapon();
    }
    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }

    public void OnInit()
    {
        // currentState = new EIdleState();
        // OnWeapon();
    }
    private void OnWeapon()
    {
        int idOfWeapon = Random.Range(0, ManagerSO.Ins.SOWeaponLists.Count);
        int idOfShield = Random.Range(0, ManagerSO.Ins.SOShieldLists.Count);
        int idOfHair = Random.Range(0, ManagerSO.Ins.SOHairLists.Count);
        int idOfPant = Random.Range(0, ManagerSO.Ins.SOPantLists.Count);
        WeaponSpawnManager.Ins.SpawnPlayerWeaponModel(weaponHand, idOfWeapon);
        SkinSpawnManager.Ins.SpawnShieldOfPlayer(shieldHand, idOfShield);
        SkinSpawnManager.Ins.SpawnHairOfPlayer(hairPos, idOfHair);
        SkinSpawnManager.Ins.SetPantOfPlayer(pantSkin, idOfPant);
        Debug.Log("on goe pon");
    }
    
    public void ChangeState(IState<Bot> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
}
