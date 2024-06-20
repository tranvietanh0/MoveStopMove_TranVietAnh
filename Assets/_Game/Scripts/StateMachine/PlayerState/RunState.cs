using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IState<Player>
{
    public void OnEnter(Player t)
    {
        t.ChangeAnim(Const.RUN_ANIM);
    }

    public void OnExecute(Player t)
    {
        if (!t.IsMoving)
        {
            t.ChangeState(new IdleState());
        }
    }

    public void OnExit(Player t)
    {

    }

}
