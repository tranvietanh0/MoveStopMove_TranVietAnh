using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Player>
{
    public void OnEnter(Player t)
    {
        t.IsMoving = false;
        t.ChangeAnim(Const.IDLE_ANIM);
    }

    public void OnExecute(Player t)
    {
        Debug.Log(t.IsMoving);
        if (t.IsMoving)
        {
            t.ChangeState(new RunState());
        }

        if (t.IsAttack)
        {
            // t.IsMoving = false;
            t.ChangeState(new AttackState());
        }
    }

    public void OnExit(Player t)
    {

    }

}
