using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    public void OnEnter(Enemy t)
    {
        t.ChangeAnim(Constants.ANIM_RUN);
        Vector3 destination = t.GetRandomPoint();
        t.SetDestination(destination);
    }

    public void OnExecute(Enemy t)
    {
        if (t.IsDead)
        {
            return;
        }

        if (t.IsDestination)
        {
            t.IsMoving = false;
            t.ChangeState(new IdleState());
        }
    }

    public void OnExit(Enemy t)
    {
        
    }
}
