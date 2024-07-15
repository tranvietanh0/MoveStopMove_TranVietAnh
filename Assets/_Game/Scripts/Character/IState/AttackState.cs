using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private Character target;
    private float     timer;
    private float     delayTime;

    public void OnEnter(Enemy t)
    {
        t.ChangeAnim(Constants.ANIM_ATTACK);
        target = t.GetTarget(); //lay muc tieu
        timer = 0;
        delayTime = Random.Range(1, 4);
    }

    public void OnExecute(Enemy t)
    {
        if (t.IsDead)
        {
            return;
        }

        timer += Time.deltaTime;

        if (target != null)
        {
            t.Attack(target);
        }

        if (timer >= delayTime)
        {
            t.IsMoving = true;
            t.ChangeState(new PatrolState());
        }
    }

    public void OnExit(Enemy t)
    {

    }
}
