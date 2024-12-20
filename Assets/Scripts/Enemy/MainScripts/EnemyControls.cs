using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform target;

    private float distance;

    private void Awake()
    {
        target = GameObject.Find("Main Building").transform;
    }

    private void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, target.position);
        Vector2 directiion = target.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, target.position, moveSpeed* Time.fixedDeltaTime);
    }

}
