using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider HealthSlider;
    [SerializeField] private float maxHealth;
    [SerializeField] private float health;

    [SerializeField] private Material takeDamageMaterial;
    [SerializeField] private float duration;

    private SpriteRenderer spriteRenderer;
    private Material defaultMaterial;

    private void Start()
    {
        health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMaterial = spriteRenderer.material;
    }

    private void Update()
    {
        if (health <= 0)
        {
            AudioManager.Instance.GamePlayBGM.Stop();
            AudioManager.Instance.GameOverBGM.Play();
            SceneManager.LoadScene(2);
        }
    }


    public void TakeEnemyDamage(float damage)
    {
        health -= damage;
        HealthSlider.value = health / maxHealth;
        StartCoroutine(ChangeMaterial());
    }

    private IEnumerator ChangeMaterial()
    {
        spriteRenderer.material = takeDamageMaterial;

        AudioManager.Instance.PlayerHit.Play();

        yield return new WaitForSeconds(duration);

        spriteRenderer.material = defaultMaterial;
    }
}
