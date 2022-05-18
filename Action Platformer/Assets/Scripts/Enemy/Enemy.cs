using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{   
    [SerializeField] int health;
    [SerializeField] float speed;

    Transform target;

    void Start()
    {
        health = 100;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            health = health - 20;
        }

        if (health == 0 || health < 0)
        {
            Destroy(gameObject);
        }
    }
}
