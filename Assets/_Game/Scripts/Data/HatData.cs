using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="HatData", menuName ="LocalData/HatData", order = 1)]
public class HatData : ScriptableObject
{
    public List<HatItem> hatList;

    public Hair GetHat(HairType hatType)
    {
        return hatList[(int)hatType].hair;
    }
}

[System.Serializable]
public class HatItem
{
    public HairType hatType;
    public Hair    hair;
    // public Sprite  hatSprite;
    // public int     hatPrice;
    // public string  hatProperty;
}
