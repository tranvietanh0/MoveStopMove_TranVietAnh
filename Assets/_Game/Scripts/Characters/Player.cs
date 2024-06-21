using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Player : Character
{
    [SerializeField] private VariableJoystick variableJoystick;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private Transform shieldHand;
    [SerializeField] private Transform weaponHand;
    [SerializeField] private Transform hairPos;
    [SerializeField] private SkinnedMeshRenderer pantSkin;

    private IState<Player> currentState;
    private float m_horizontal;
    private float m_vertical;
    private bool isMoving = false;

    public bool IsMoving
    {
        get => isMoving;
        set => isMoving = value;
    }

    private void Start()
    {
        currentState = new IdleState();
        this.OnWeapon();
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
        Move();
    }

    private void Move()
    {
        m_horizontal = variableJoystick.Horizontal;
        m_vertical = variableJoystick.Vertical;
        Vector3 direction = new Vector3(m_horizontal, 0, m_vertical).normalized;
        if (Mathf.Abs(m_horizontal) > 0.1f || Mathf.Abs(m_vertical) > 0.1f)
        {
            isMoving = true;
            characterController.Move(direction * moveSpeed * Time.deltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            TF.rotation = Quaternion.Slerp(TF.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            
        }
        else
        {
            isMoving = false;
        }
        
    }

    public void OnWeapon()
    {
        WeaponSpawnManager.Ins.SpawnPlayerWeaponModel(weaponHand, 0);
        Debug.Log(shieldHand);
        SkinSpawnManager.Ins.SpawnShieldOfPlayer(shieldHand, 0);
        SkinSpawnManager.Ins.SpawnHairOfPlayer(hairPos, 0);
        SkinSpawnManager.Ins.SetPantOfPlayer(pantSkin, 0);
    }
    public void ChangeState(IState<Player> state)
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
