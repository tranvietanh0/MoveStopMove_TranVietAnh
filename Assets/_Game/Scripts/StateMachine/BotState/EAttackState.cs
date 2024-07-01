using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAttackState : IState<Bot>
{
    private float timeAttack;
    public void OnEnter(Bot t)
    {
        timeAttack = 1f;
        t.IsAttack = true;
        t.ChangeAnim(Const.ATTACK_ANIM);
        t.Attack();
        t.agent.isStopped = true;
    }

    public void OnExecute(Bot t)
    {
        timeAttack -= Time.deltaTime;
        if (timeAttack > 0)
        {
            return;
        }

        t.IsAttack = false;
        t.ChangeState(new EIdleState());
        if (t.IsDead)
        {
            t.ChangeState(new EDeadState());
        }
    }

    public void OnExit(Bot t)
    {

    }

}
