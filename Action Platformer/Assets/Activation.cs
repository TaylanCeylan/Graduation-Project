using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    [SerializeField] GameObject shop;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            shop.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            shop.SetActive(true);
        }
    }
}
