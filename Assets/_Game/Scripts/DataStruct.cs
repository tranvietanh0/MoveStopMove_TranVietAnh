using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Const
{
    public const string IDLE_ANIM = "Idle";
    public const string RUN_ANIM = "Run";
    public const string ATTACK_ANIM = "Attack";
    public const string DANCE_ANIM = "Dance";
    public const string DEAD_ANIM = "Dead";
}
public enum GameState
{
    None = 0,
    MainMenu = 1,
    GamePlay = 2,
    Pause = 3
}
