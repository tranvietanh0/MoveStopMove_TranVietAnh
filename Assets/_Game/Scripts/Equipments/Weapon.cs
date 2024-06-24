using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : GameUnit
{
    [SerializeField] private float speed = 100f;

    private bool isFire = false;
    private Vector3 targetPos;

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
}
