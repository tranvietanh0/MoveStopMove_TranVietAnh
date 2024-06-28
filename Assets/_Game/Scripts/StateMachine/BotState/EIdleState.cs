using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EIdleState : IState<Bot>
{
    private float timer;
    private float delayTime = 3f;
    public void OnEnter(Bot t)
    {
        t.ChangeAnim(Const.IDLE_ANIM);
        timer = 0f;
        delayTime = 3f;
    }

    public void OnExecute(Bot t)
    {
        // Debug.Log("vl");
        timer += Time.deltaTime;
        // Debug.Log(timer);
        // Debug.Log(delayTime);
        // Debug.Log(Mathf.Abs(timer - delayTime));
        if (Mathf.Abs(timer - delayTime) <= 0.1f)
        {
            t.ChangeState(new EPatrolState());
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
