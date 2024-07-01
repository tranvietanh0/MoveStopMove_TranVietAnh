using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Bot : Character
{
    [SerializeField] private Transform weaponHand;
    [SerializeField] private Transform shieldHand;
    [SerializeField] private Transform hairPos;
    [SerializeField] private SkinnedMeshRenderer pantSkin;
    [SerializeField] private float wanderRadius = 5f;
    [SerializeField] private float wanderInterval = 10f;
    [SerializeField] private float mapRad;
    [SerializeField] private Vector3 center;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private WeaponModel _weaponModel;
    public NavMeshAgent agent;

    private List<Weapon> weapons = new List<Weapon>();
    private Transform targetPosition;
    private Vector3 newPos;
    private IState<Bot> currentState;
    private bool isAttack = false;
    private float timer = 0;
    private bool isDead = false;
    [SerializeField] private int idWeapon;
    public bool IsDead
    {
        get => isDead;
        set => isDead = value;
    }


    public Transform TargetPosition
    {
        get => targetPosition;
        set => targetPosition = value;
    }

    public bool IsAttack
    {
        get => isAttack;
        set => isAttack = value;
    }

    private void Start()
    {
        currentState = new EIdleState();
        // OnWeapon();
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
        // FindRandomPos();
    }

    public bool IsNewPos()
    {
        return Vector3.Distance(this.TF.position, newPos) <= 0.1f;
    }

    public void FindRandomPos()
    {

        newPos = RandomNavSphere(transform.position, wanderRadius, -1);
        if (newPos != Vector3.zero && IsPositionOnNavMesh(newPos, mapRad))
        {
            agent.SetDestination(newPos);
        }
    }

    public Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        bool hasPosition = NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return hasPosition ? navHit.position : Vector3.zero;
    }

    private bool IsPositionOnNavMesh(Vector3 position, float distance)
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition(position, out hit, distance, NavMesh.AllAreas);
    }

    public void OnInit()
    {
        // currentState = new EIdleState();
         // OnWeapon();
    }

    public void OnWeapon()
    {
        idWeapon = Random.Range(0, ManagerSO.Ins.SOWeaponLists.Count);
        int idOfShield = Random.Range(0, ManagerSO.Ins.SOShieldLists.Count);
        int idOfHair = Random.Range(0, ManagerSO.Ins.SOHairLists.Count);
        int idOfPant = Random.Range(0, ManagerSO.Ins.SOPantLists.Count);
        // WeaponSpawnManager.Ins.SpawnBotWeaponModel(weaponHand, idWeapon);
        WeaponSpawnManager.Ins.SpawnPlayerWeaponModel(weaponHand, idWeapon);
        SkinSpawnManager.Ins.SpawnShieldOfPlayer(shieldHand, idOfShield);
        SkinSpawnManager.Ins.SpawnHairOfPlayer(hairPos, idOfHair);
        SkinSpawnManager.Ins.SetPantOfPlayer(pantSkin, idOfPant);
        // Debug.Log("on goe pon");
        // Debug.Log("idWeapon" + idWeapon + "idOfShield: " + idOfShield);
    }

    public void Attack()
    {
        ChangeRotation(targetPosition, rotationSpeed);
        Weapon attackWeapon = WeaponSpawnManager.Ins.ESpawnWeaponToAttack(targetPosition, idWeapon, weaponHand);
        weapons.Add(attackWeapon);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.WEAPON_TAG))
        {
            Weapon weaponAttack = Cache.GetWeapon(other);
            if (!weapons.Contains(weaponAttack))
            {
                isDead = true;
            }
        }
    }
}