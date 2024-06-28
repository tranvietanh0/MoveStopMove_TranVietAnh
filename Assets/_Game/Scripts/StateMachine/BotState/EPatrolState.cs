using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EPatrolState : IState<Bot>
{
    private float wanderRadius;
    private float wanderInterval;
    private float timer = 0f;
    private Vector3 newPos;
    public void OnEnter(Bot t)
    {
        wanderRadius = 10f;
        wanderInterval = 5f;
        t.ChangeAnim(Const.RUN_ANIM);
        t.FindRandomPos();
    }

    public void OnExecute(Bot t)
    {
        if (t.IsNewPos())
        {
            t.ChangeState(new EIdleState());
        }

        if (t.IsAttack)
        {
            t.ChangeState(new EAttackState());
        }
    }

    public void OnExit(Bot t)
    {
        
    }

    
}
