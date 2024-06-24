using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EIdleState : IState<Bot>
{
    public void OnEnter(Bot t)
    {
        t.ChangeAnim(Const.IDLE_ANIM);
    }

    public void OnExecute(Bot t)
    {
    }

    public void OnExit(Bot t)
    {
        throw new System.NotImplementedException();
    }
}
