using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : GameUnit
{
    [SerializeField] protected Animator   anim;
    [SerializeField] protected GameObject body;
    [SerializeField] protected float      radius = 5f;

    protected bool  isMoving;
    protected float currentSize;
    protected float newSize;
    
    private IState<Character> currentState;
    private string            currentAnim;

    public virtual void OnInit()
    {
        this.isMoving = false;
    }

    private void Start()
    {
        ChangeState(new IdleState());
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
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

    public void ChangeState(IState<Character> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
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
