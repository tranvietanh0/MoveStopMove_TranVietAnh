using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IState<Player>
{
    public void OnEnter(Player t)
    {
        t.ChangeAnim(Const.RUN_ANIM);
        t.IsMove = false;
    }

    public void OnExecute(Player t)
    {
        // t.Move();
        if (!t.IsMoving)
        {
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
