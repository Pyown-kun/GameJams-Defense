using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainBuilding : MonoBehaviour
{
    public Image HealthBar;

    [SerializeField] private float buildingMaxHealth;
    [SerializeField] private float buildingHealth;

    private void Start()
    {
        buildingHealth = buildingMaxHealth;
    }

    private void Update()
    {
        if (buildingHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        buildingHealth -= damageAmount;
        HealthBar.fillAmount = buildingHealth/buildingMaxHealth;
    }

}