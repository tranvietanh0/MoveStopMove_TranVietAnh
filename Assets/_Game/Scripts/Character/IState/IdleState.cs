using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private float randomTime;
    private float timer;

    public void OnEnter(Enemy t)
    {
        t.ChangeAnim(Constants.ANIM_IDLE);
        randomTime = Random.Range(1, 4);
        timer = 0f;
    }

    public void OnExecute(Enemy t)
    {
        timer += Time.deltaTime;
        if (t.IsDead)
        {
            return;
        }

        if (t.GetTarget() != null && !t.IsOutOfAttackRange(t.GetTarget()))
        {
            t.ChangeState(new AttackState());

        }

        else if (timer >= randomTime)
        {
            t.ChangeState(new PatrolState());

        }
    }

    public void OnExit(Enemy t)
    {

    }
}
