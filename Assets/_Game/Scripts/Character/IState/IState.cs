using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void OnEnter(Enemy enemy);

    public void OnExecute(Enemy enemy);

    public void OnExit(Enemy enemy);
}
