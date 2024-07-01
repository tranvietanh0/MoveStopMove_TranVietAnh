using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cache 
{
    private static Dictionary<Collider, Weapon> weapons = new Dictionary<Collider, Weapon>();

    public static Weapon GetWeapon(Collider collider)
    {
        if (!weapons.ContainsKey(collider))
        {
            var weapon = collider.GetComponent<Weapon>();
            if (weapon == null)
            {
                Debug.LogError($"Collider {collider.name} does not have a Character component.");
                return null;
            }
            weapons.Add(collider, weapon);
        }

        return weapons[collider];
    } 
    
    private static Dictionary<Collider, Bot> bots = new Dictionary<Collider, Bot>();

    public static Bot GetBot(Collider collider)
    {
        if (!bots.ContainsKey(collider))
        {
            var bot = collider.GetComponent<Bot>();
            if (bot == null)
            {
                Debug.LogError($"Collider {collider.name} does not have a Bot component.");
                return null;
            }
            bots.Add(collider, bot);
        }

        return bots[collider];
    }  
    
    private static Dictionary<Collider, Player> players = new Dictionary<Collider, Player>();

    public static Player GetPlayer(Collider collider)
    {
        if (!players.ContainsKey(collider))
        {
            var player = collider.GetComponent<Player>();
            if (player == null)
            {
                Debug.LogError($"Collider {collider.name} does not have a Player component.");
                return null;
            }
            players.Add(collider, player);
        }

        return players[collider];
    }
}
