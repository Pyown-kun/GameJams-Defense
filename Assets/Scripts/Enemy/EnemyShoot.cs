using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefeb;
    [SerializeField] private float timeDelay;

    private float fireRate;

    private void Awake()
    {
        fireRate = timeDelay;
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        fireRate -= Time.deltaTime;
        if (fireRate <= 0)
        {
            Instantiate(bulletPrefeb, transform.position, Quaternion.identity);
            fireRate = timeDelay;
        }
    }
}
