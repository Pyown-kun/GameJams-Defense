using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int damage;

    [SerializeField] private Material SlashMaterial;

    private EnemyControls enemyControls;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        enemyControls = GetComponent<EnemyControls>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MainBuilding")
        {
            StartCoroutine(ChangeMaterialDie());

            MainBuilding mainBuilding = collision.gameObject.GetComponent<MainBuilding>();
            mainBuilding.TakeDamage(damage);
        }
    }

    private IEnumerator ChangeMaterialDie()
    {
        spriteRenderer.material = SlashMaterial;
        enemyControls.MoveSpeed = 0;

        yield return new WaitForSeconds(0.2f);

        Destroy(gameObject);
    }

}
