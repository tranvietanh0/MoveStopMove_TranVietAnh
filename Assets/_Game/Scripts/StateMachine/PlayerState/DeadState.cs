using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState<Player>
{
    public void OnEnter(Player t)
    {
        t.ChangeAnim(Const.DEAD_ANIM);
        t.IsMove = true;
    }

    public void OnExecute(Player t)
    {
    }

    public void OnExit(Player t)
    {
    }
}
