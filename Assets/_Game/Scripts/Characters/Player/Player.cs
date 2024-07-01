using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private Weapon weapon;
    
    private Transform targetPosition;
    private IState<Player> currentState;
    private float m_horizontal;
    private float m_vertical;
    private bool isMoving = false;
    private bool isAttack = false;
    private bool isDead = false;
    private List<Weapon> weapons = new List<Weapon>();
    private bool isMove = false;

    public bool IsMove { get => isMove; set => isMove = value; } 
    public bool IsDead { get => isDead; set => isDead = value; } public Transform TargetPosition { get => targetPosition; set => targetPosition = value; }
    public bool IsAttack { get => isAttack; set => isAttack = value; }
    public bool IsMoving { get => isMoving; set => isMoving = value; }
    

    private void Start()
    {
        currentState = new IdleState();
        OnWeapon();
    }
    private void OnDestroy()
    {
        if (weapon != null)
        {
            weapon.OnWeaponHit -= HandleWeaponHit;
        }
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
        Move();
    }

    public void HandleWeaponHit()
    {
        this.transform.localScale *= 1.1f;
    }

    public void Move()
    {
        if (!isMove)
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
    }

    public void OnWeapon()
    {
        WeaponSpawnManager.Ins.SpawnPlayerWeaponModel(weaponHand, 3);
        SkinSpawnManager.Ins.SpawnShieldOfPlayer(shieldHand, 3);
        SkinSpawnManager.Ins.SpawnHairOfPlayer(hairPos, 3);
        SkinSpawnManager.Ins.SetPantOfPlayer(pantSkin, 3);
    }

    public void Attack()
    {
        ChangeRotation(targetPosition, rotationSpeed);
        Weapon weaponAttack = WeaponSpawnManager.Ins.SpawnWeaponToAttack(targetPosition, 3, weaponHand);
        weapons.Add(weaponAttack);
        if (weaponAttack != null)
        {
            Debug.Log("Assign");
            weaponAttack.OnWeaponHit += HandleWeaponHit;
        }
    }

    public void ChangeScale()
    {
        Vector3 scaleChange = new Vector3(1.2f, 1.2f, 1.2f);
        this.transform.localScale = Vector3.Scale(transform.localScale, scaleChange);
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Const.WEAPON_TAG))
        {
            Weapon weaponAttack = Cache.GetWeapon(other);
            if (!weapons.Contains(weaponAttack))
            {
                isDead = true;
            }
        }
    }
}
