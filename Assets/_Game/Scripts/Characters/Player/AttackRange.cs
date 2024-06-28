using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    [SerializeField] private Player player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.BOT_TAG))
        {
            player.IsAttack = true;
            player.TargetPosition = other.transform;
        }
    }
}
