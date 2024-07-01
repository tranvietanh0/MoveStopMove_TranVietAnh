using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : GameUnit
{
    [SerializeField] private float speed = 100f;
    public Action OnWeaponHit;

    private bool isFire = false;
    private Vector3 targetPos;
    private bool isAttackToBot = false;

    public bool IsAttackToBot
    {
        get => isAttackToBot;
        set => isAttackToBot = value;
    }

    private void Update()
    {
        MoveWeaponToTarget();
    }

    public void SetTargetPos(Transform targetPosition)
    {
        isFire = true;
        this.targetPos = targetPosition.position;
    }

    public void MoveWeaponToTarget()
    {
        if (isFire)
        {
            transform.position = Vector3.MoveTowards(transform.position,  targetPos + Vector3.up, speed * Time.deltaTime);
        }
    }

    
    // public void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag(Const.BOT_TAG))
    //     {
    //         OnWeaponHit?.Invoke();
    //     }
    // }
}
