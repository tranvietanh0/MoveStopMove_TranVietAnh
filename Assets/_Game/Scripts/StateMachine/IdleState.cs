using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Player>
{
    public void OnEnter(Player t)
    {
        t.ChangeAnim(Const.IDLE_ANIM);
    }

    public void OnExecute(Player t)
    {

    }

    public void OnExit(Player t)
    {

    }

}
