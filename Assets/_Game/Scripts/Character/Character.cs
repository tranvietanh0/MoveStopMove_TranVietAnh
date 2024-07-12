using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : GameUnit
{
    [SerializeField] protected Animator            anim;
    [SerializeField] protected GameObject          body;
    [SerializeField] protected float               radius = 5f;
    [SerializeField] protected SkinnedMeshRenderer skinnedMeshRenderer;
    
    [SerializeField] private Weapon     currentWeapon;
    [SerializeField] private Transform  rightHand;
    [SerializeField] private Transform  leftHand;
    [SerializeField] private Transform  head;
    [SerializeField] private HatData    hatData;
    [SerializeField] private ShieldData shieldData;
    [SerializeField] private WeaponData weaponData;
    [SerializeField] private Hair       currentHat;
    [SerializeField] private Pant       currentPant;
    [SerializeField] private Shield     currentShield;
    
    

    protected bool  isMoving;
    protected float currentSize;
    protected float newSize;
    
    private string currentAnim;
    
    

    public virtual void OnInit()
    {
        this.isMoving = false;
    }
    
    public void ChangeWeapon(WeaponType weaponType)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon.gameObject);
        }
        Weapon newWeapon = Instantiate(weaponData.GetWeapon(weaponType), rightHand);
        currentWeapon = newWeapon;
    }
    public void ChangeHat(HairType hatType)
    {
        if (currentHat != null)
        {
            Destroy(currentHat.gameObject);
            currentHat = null;
        }

        if (hatType != HairType.None)
        {
            Hair newHat = Instantiate(hatData.GetHat(hatType), head);
            currentHat = newHat;
        }
    }
    
    public void ChangePant(PantType pantType)
    {
        if (currentPant != null)
        {
            if (pantType != PantType.None)
            {
                currentPant.ChangeMaterialPant(pantType);
            }
            else
            {
                currentPant.ResetMaterial();
            }
        }
    }
    
    public void ChangeShield(ShieldType shieldType)
    {
        if (currentShield != null)
        {
            Destroy(currentShield.gameObject);
            currentShield = null;
        }

        if (shieldType != ShieldType.None)
        {
            Shield newShield = Instantiate(shieldData.GetShield(shieldType), leftHand);
            currentShield = newShield;
        }
    }
    public virtual void UpSize(float value)
    {
        newSize = currentSize + value;
        SetSize(newSize);
        currentSize = newSize;
    }
    
    public void SetSize(float newSize)
    {
        currentSize               = Mathf.Clamp(newSize, Const.MIN_SIZE, Const.MAX_SIZE);
        body.transform.localScale = currentSize * Vector3.one;
        radius                    = currentSize / Const.RATIO;
    }
    
    public void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            if (currentAnim != null)
            {
                anim.ResetTrigger(currentAnim);
            }
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }
    }

}
