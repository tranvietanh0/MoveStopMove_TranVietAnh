using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDeadState : IState<Bot>
{
    private float timer;
    public void OnEnter(Bot t)
    {
        timer = 0f;
        t.ChangeAnim(Const.DEAD_ANIM);
    }

    public void OnExecute(Bot t)
    {
        if (t.IsDead)
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                t.OnDespawn();
            }
        }
    }

    public void OnExit(Bot t)
    {
    }
}
