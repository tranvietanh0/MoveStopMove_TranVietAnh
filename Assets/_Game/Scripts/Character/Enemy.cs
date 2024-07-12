using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using Random = UnityEngine.Random;

public class Enemy : Character
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private ColorData    colorData;

    private Vector3   destination;
    private Color     color;
    private ColorType colorType;

    public IState currentState;
    public bool   IsDestination => Vector3.Distance(TF.position, destination + (TF.position.y - destination.y) * Vector3.up) < 0.1f;
    public bool   IsMoving      { get => isMoving; set => isMoving = value; }
    
    
    public override void OnInit()
    {
        base.OnInit();
        ChangeState(new IdleState());
        SetSize(Random.Range(Const.MIN_SIZE, Const.MAX_SIZE));
        // this.Name  = RandomName.GetRandomEnemyName();
        // this.Score = 0;

        int weaponIndex = Random.Range(0, Enum.GetValues(typeof(WeaponType)).Length);
        int hatIndex    = Random.Range(0, Enum.GetValues(typeof(HairType)).Length);
        int panIndex    = Random.Range(0, Enum.GetValues(typeof(PantType)).Length);
        int shieldIndex = Random.Range(0, Enum.GetValues(typeof(ShieldType)).Length);
        int colorIndex  = Random.Range(0, Enum.GetValues(typeof(ColorType)).Length);

        ChangeWeapon((WeaponType)weaponIndex);
        ChangeHat((HairType)hatIndex);
        ChangePant((PantType)panIndex);
        ChangeShield((ShieldType)shieldIndex);
        ChangeColor((ColorType)colorIndex);
    }
    
    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        agent.SetDestination(destination);
    }
    
    //random vi tri
    public Vector3 GetRandomPoint()
    {
        Vector3 point;
        if (NavmeshRandomPoint(TF.position, 20, out point))
        {
            return point;
        }
        return TF.position;
    }
    
    private void ChangeColor(ColorType colorType)
    {
        this.colorType               = colorType;
        skinnedMeshRenderer.material = colorData.GetMaterial(colorType);
        color                        = colorData.GetMaterial(colorType).color;
    }
    private bool NavmeshRandomPoint(Vector3 center, float radius, out Vector3 point)
    {
        Vector3    randomPoint = center + Random.insideUnitSphere * radius;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, radius, NavMesh.AllAreas))
        {
            point = hit.position;
            return true;
        }
        point = Vector3.zero;
        return false;
    }
    
    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
}
