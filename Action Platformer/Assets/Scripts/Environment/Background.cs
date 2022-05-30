using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBG();
    }

    void MoveBG()
    {
        transform.position = new Vector2(target.transform.position.x, transform.position.y);
    }
}
