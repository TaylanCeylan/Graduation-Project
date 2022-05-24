using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public Player player;
    public TMP_Text coinText;

    // Update is called once per frame
    void Update()
    {
        coinText.text = player.playerCoins.ToString();
    }
}
