using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float health;

    public Slider HealthSlider;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }


    public void TakeEnemyDamage(float damage)
    {
        health -= damage;
        HealthSlider.value = health / maxHealth;
    }
}
