using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    PlayerInputHandler inputHandler;

    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;

    private void Awake()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputHandler.IsShooting)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        inputHandler.IsShooting = false;
    }
}
