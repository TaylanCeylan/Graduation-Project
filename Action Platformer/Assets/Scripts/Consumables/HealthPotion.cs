using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] GameObject particle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.CompareTag("Player"))
            {
                Instantiate(particle, transform.position, transform.rotation);
                Destroy(gameObject);
            }
    }
}
