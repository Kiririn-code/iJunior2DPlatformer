using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _jumpForse = 0.8f;

    private SpriteRenderer _sprite;
    private Rigidbody2D _rigitBody;
    private Animator _animator;
    private bool _isGrounded;

    private void Start()
    {
        _rigitBody = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Ground ground))
            _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Ground ground))
            _isGrounded = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _animator.SetBool("IsWalk", true);
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _sprite.flipX = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _animator.SetBool("IsWalk", true);
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _sprite.flipX = true;
        }

        if (Input.GetKey(KeyCode.W) && _isGrounded)
        {
            _rigitBody.AddForce(Vector2.up * _jumpForse, ForceMode2D.Impulse);
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            _animator.SetBool("IsWalk", false);
    }
}
