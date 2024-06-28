using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAttackRange : MonoBehaviour
{
    [SerializeField] private Bot bot;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.BOT_TAG) || other.CompareTag(Const.PLAYER_TAG))
        {
            bot.IsAttack = true;
            bot.TargetPosition = other.transform;
        }
    }
}
