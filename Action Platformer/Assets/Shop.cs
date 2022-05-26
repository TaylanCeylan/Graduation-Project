using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] public Player player;

     public bool isBought;

    public void BuyHealthPotion()
    {
        player.playerCoins += 50;
        isBought = true;
    }
}
