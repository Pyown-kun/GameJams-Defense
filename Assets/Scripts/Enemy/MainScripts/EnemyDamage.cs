using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MainBuilding")
        {
            Destroy(gameObject);

            MainBuilding mainBuilding = collision.gameObject.GetComponent<MainBuilding>();
            mainBuilding.TakeDamage(damage);
        }
    }

}
