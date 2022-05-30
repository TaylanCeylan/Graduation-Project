using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] public Player player;

    public void CheckIfCanBuyHealth()
    {
        if (player.currentHealth < player.health && player.playerCoins >= 50)
        {
            player.playerCoins -= 50;
            player.currentHealth = player.health;
        }
    }

    public void CheckIfCanBuyHealthLevelUp() 
    {
        if (player.playerCoins >= 200)
        {
            player.health = player.health + 100;

            player.currentHealth = player.health;

            player.playerCoins -= 200;
        }
    }
}
