using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState<Player>
{
    private float attackeDelayTime;
    private float timer;
    public void OnEnter(Player t)
    {
        t.IsAttack = true;
        attackeDelayTime = 0.6f;
        t.ChangeAnim(Const.ATTACK_ANIM);
        t.Attack();
        t.IsMove = true;
    }

    public void OnExecute(Player t)
    {
        if (t.IsMoving)
        {
            t.IsAttack = false;
            // t.IsMove = true;
            t.ChangeState(new IdleState());
        }
        else
        {
            t.IsMoving = false;
            attackeDelayTime -= Time.deltaTime;
            if (attackeDelayTime > 0)
            {
                return;
            }
            t.IsAttack = false;
            t.ChangeState(new IdleState());
        }

        if (t.IsDead)
        {
            t.ChangeState(new DeadState());
        }
    }

    public void OnExit(Player t)
    {
        
    }
}
