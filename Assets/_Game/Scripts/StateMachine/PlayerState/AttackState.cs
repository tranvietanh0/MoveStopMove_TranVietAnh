using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState<Player>
{

    public void OnEnter(Player t)
    {
        t.IsAttack = true;
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
    }

    public void OnExit(Player t)
    {
        
    }
}
