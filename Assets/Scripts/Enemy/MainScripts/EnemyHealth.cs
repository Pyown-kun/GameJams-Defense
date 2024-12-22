using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Image HealthBar;

    [SerializeField] private Material SlashMaterial;

    [SerializeField] private float maxHealth;
    [SerializeField] private float health;
    [SerializeField] private float slashDuration;

    private EnemyControls enemyControls;
    private SpriteRenderer spriteRenderer;
    private Material defaultMaterial;


    private void Start()
    {
        health = maxHealth;

        enemyControls = GetComponent<EnemyControls>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMaterial = spriteRenderer.material;
    }

    private void Update()
    {
        if (health < 0)
        {
            StartCoroutine(ChangeMaterialDie());
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        HealthBar.fillAmount = health/maxHealth;
        StartCoroutine(ChangeMaterial());
    }

    private IEnumerator ChangeMaterial()
    {
        spriteRenderer.material = SlashMaterial;

        AudioManager.Instance.EnemyHit.Play();

        yield return new WaitForSeconds(slashDuration);

        spriteRenderer.material = defaultMaterial;
    }
    
    private IEnumerator ChangeMaterialDie()
    {
        spriteRenderer.material = SlashMaterial;
        enemyControls.MoveSpeed = 0;

        yield return new WaitForSeconds(slashDuration);

        Destroy(gameObject);
    }
}
