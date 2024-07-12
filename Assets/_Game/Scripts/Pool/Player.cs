using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : Character
{
    [SerializeField] private FloatingJoystick    joystick;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float               speed;
    [SerializeField] private float               rotationSpeed;
    
    private float horizontal;
    private float vertical;

    private void Start()
    {
        this.OnInit();
    }
    private void Update()
    {
        this.Move();
    }

    public override void OnInit()
    {
        this.speed         = 10f;
        this.rotationSpeed = 100f;
    }
    
    public void Move()
    {
        horizontal = joystick.Horizontal;
        vertical   = joystick.Vertical;
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
        {
            characterController.Move(direction * speed * Time.deltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            this.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            ChangeAnim(Const.ANIM_RUN);
        }
        else
        {
            ChangeAnim(Const.ANIM_IDLE);
        }
    }
}
