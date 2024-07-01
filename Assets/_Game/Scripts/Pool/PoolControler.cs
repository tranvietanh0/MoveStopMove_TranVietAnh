using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PoolControler : MonoBehaviour
{
    [Header("---- POOL CONTROLER TO INIT POOL ----")]
    //[Header("Put object pool to list Pool or Resources/Pool")]
    //[Header("Preload: Init Poll")]
    //[Header("Spawn: Take object from pool")]
    //[Header("Despawn: return object to pool")]
    //[Header("Collect: return objects type to pool")]
    //[Header("CollectAll: return all objects to pool")]

    [Space]
    [Header("Pool")]
    public List<PoolAmount> Pool;

    [Header("Particle")]
    public ParticleAmount[] Particle;


    public void Awake()
    {
        for (int i = 0; i < Pool.Count; i++)
        {
            SimplePool.Preload(Pool[i].prefab, Pool[i].amount, Pool[i].root, Pool[i].collect);
        }

        for (int i = 0; i < Particle.Length; i++)
        {
            ParticlePool.Preload(Particle[i].prefab, Particle[i].amount, Particle[i].root);
            ParticlePool.Shortcut(Particle[i].particleType, Particle[i].prefab);
        }
    }
}

#if UNITY_EDITOR

[CustomEditor(typeof(PoolControler))]
public class PoolControlerEditor : Editor
{
    PoolControler pool;

    private void OnEnable()
    {
        pool = (PoolControler)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Create Quick Root"))
        {
            for (int i = 0; i < pool.Pool.Count; i++)
            {
                if (pool.Pool[i].root == null)
                {
                    Transform tf = new GameObject(pool.Pool[i].prefab.poolType.ToString()).transform;
                    tf.parent = pool.transform;
                    pool.Pool[i].root = tf; 
                }
            }
            
            for (int i = 0; i < pool.Particle.Length; i++)
            {
                if (pool.Particle[i].root == null)
                {
                    Transform tf = new GameObject(pool.Particle[i].particleType.ToString()).transform;
                    tf.parent = pool.transform;
                    pool.Particle[i].root = tf; 
                }
            }
        }

        if (GUILayout.Button("Get Prefab Resource"))
        {
            GameUnit[] resources = Resources.LoadAll<GameUnit>("Pool");

            for (int i = 0; i < resources.Length; i++)
            {
                bool isDuplicate = false;
                for (int j = 0; j < pool.Pool.Count; j++)
                {
                    if (resources[i].poolType == pool.Pool[j].prefab.poolType)
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    Transform root = new GameObject(resources[i].name).transform;

                    PoolAmount newPool = new PoolAmount(root, resources[i], SimplePool.DEFAULT_POOL_SIZE, true);

                    pool.Pool.Add(newPool);
                }
            }
        }
    }
}

#endif

[System.Serializable]
public class PoolAmount
{
    [Header("-- Pool Amount --")]
    public Transform root;
    public GameUnit prefab;
    public int amount;
    public bool collect;

    public PoolAmount (Transform root, GameUnit prefab, int amount, bool collect)
    {
        this.root = root;
        this.prefab = prefab;
        this.amount = amount;
        this.collect = collect;
    }
}


[System.Serializable]
public class ParticleAmount
{
    public Transform root;
    public ParticleType particleType;
    public ParticleSystem prefab;
    public int amount;
}


public enum ParticleType
{
    Hit
}

public enum PoolType
{
    None = 0,
    Weapon = 1,
    Bot = 2,
    Skin = 3,
    Shield = 4,
    WeaponModel = 5,
    WeaponArrow = 6,
    WeaponAxe0 = 7,
    WeaponAxe1 = 8,
    WeaponBoomerang = 9,
    WeaponCandy0 = 10,
    WeaponCandy1 = 11,
    WeaponCandy2 = 12,
    WeaponCandy4 = 13,
    WeaponHammer = 14,
    WeaponKnife = 15,
    WeaponUzi = 16,
    WeaponZ = 17,
    Shield1 = 18,
    Shield2 = 19,
    AtkWeaponArrow = 20,
    AtkWeaponAxe0 = 21,
    AtkWeaponAxe1 = 22,
    AtkWeaponBoomerang = 23,
    AtkWeaponCandy0 = 24,
    AtkWeaponCandy1 = 25,
    AtkWeaponCandy2 = 26,
    AtkWeaponCandy4 = 27,
    AtkWeaponHammer = 28,
    AtkWeaponKnife = 29,
    AtkWeaponUzi = 30,
    AtkWeaponZ = 31,
    HairArrow = 32,
    HairCowboy = 33,
    HairCrown = 34,
    HairEar = 35,
    HairHat = 36,
    HairHatCap = 37,
    HairHatYellow = 38,
    HairHeadphone = 39,
    HairHorn = 40,
    HairRau = 41

}


