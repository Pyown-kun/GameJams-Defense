using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    public PauseManager PauseManager;
    public int damage = 80;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform attactCollider;

    private PlayerInputControls playerInputControls;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Vector2 movements;

    private void Awake()
    {
        playerInputControls = new PlayerInputControls();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        playerInputControls.Player.Attack.started += _ => Attack();
    }

    private void OnEnable()
    {
        playerInputControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
        PlayerFacingDirectory();
    }

    private void PlayerInput()
    {
        movements = playerInputControls.Player.Move.ReadValue<Vector2>();

        animator.SetFloat("MoveX", movements.x);
        animator.SetFloat("MoveY", movements.y);
    }

    private void Attack()
    {
        if (!PauseManager.IsPause)
        {
            animator.SetTrigger("IsAttack");
            StartCoroutine(AttackColliderActive());
            //AudioManager.instance.SwordSlash.mute = true;
            AudioManager.Instance.SwordSlash.Play();
        }
    }

    private IEnumerator AttackColliderActive()
    {
        yield return new WaitForSeconds(0.2f);
        attactCollider.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        attactCollider.gameObject.SetActive(false);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movements * (moveSpeed * Time.fixedDeltaTime));
    }

    private void PlayerFacingDirectory()
    {
        if (movements.x < 0)
        {
            spriteRenderer.flipX = true;
            attactCollider.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        }
        else if (movements.x > 0)
        {
            spriteRenderer.flipX = false;
            attactCollider.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

}
