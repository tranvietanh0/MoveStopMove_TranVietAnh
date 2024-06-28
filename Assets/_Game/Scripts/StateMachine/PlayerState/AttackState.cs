using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState<Player>
{
    private float attackeDelayTime;
    public void OnEnter(Player t)
    {
        t.IsAttack = true;
        attackeDelayTime = 3f;
        t.ChangeAnim(Const.ATTACK_ANIM);
        t.Attack();
    }

    public void OnExecute(Player t)
    {
        if (t.IsMoving)
        {
            t.IsAttack = false;
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
    }

    public void OnExit(Player t)
    {
        
    }
}
