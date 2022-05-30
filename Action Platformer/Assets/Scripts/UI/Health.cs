using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public Player player;
    public TMP_Text text;

    // Update is called once per frame
    void Update()
    {
            text.text = player.currentHealth.ToString();
    }
}
