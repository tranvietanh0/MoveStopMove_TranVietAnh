using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Const
{
    public const string ANIM_RUN    = "run";
    public const string ANIM_IDLE   = "idle";
    public const string ANIM_DEAD   = "dead";
    public const string ANIM_ATTACK = "attack";
    
    public const float MIN_SIZE      = 0.8f;
    public const float MAX_SIZE      = 1.3f;
    public const float UP_SIZE       = 0.05f;
    public const float RATIO         = 0.17f;
    public const float ORIGINAL_SIZE = 1f;
}
public enum ColorType
{
    None     = 0,
    Color_1  = 1,
    Color_2  = 2,
    Color_3  = 3,
    Color_4  = 4,
    Color_5  = 5,
    Color_6  = 6,
    Color_7  = 7,
    Color_8  = 8,
    Color_9  = 9,
    Color_10 = 10
}
public enum WeaponType
{
    Arrow = 0,
    Axe_0 = 1,
    Axe_1 = 2,
    Boomerang = 3,
    Candy_0 = 4,
    Candy_1 = 5,
    Candy_2 = 6,
    Candy_4 = 7,
    Hammer = 8,
    Knife = 9,
    Uzi = 10,
    Z = 11
}

public enum CameraState
{
    MainMenu = 0,
    GamePlay = 1,
    Shop     = 2,
    Victory  = 3
}

public enum HairType
{
    Arrow = 0,
    Cowboy = 1,
    Crown = 2,
    Ear = 3,
    Hat = 4,
    Hat_Cap = 5,
    Hat_Yellow = 6,
    Headphone = 7,
    Horn = 8,
    Rau = 9,
    None = 10
}

public enum PantType
{
    Batman = 0,
    Chambi = 1,
    Comy = 2,
    Dabao = 3,
    Onion = 4,
    Pokemon = 5,
    Rainbow = 6,
    Skull = 7,
    Vantim = 8,
    None = 9
}

public enum ShieldType
{
    Shield_1 = 0,
    Shield_2 = 1,
    None = 2
}