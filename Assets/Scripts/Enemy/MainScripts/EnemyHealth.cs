using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Image HealthBar;

    [SerializeField] private float maxHealth;
    [SerializeField] private float health;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        HealthBar.fillAmount = health/maxHealth;
    }
}
