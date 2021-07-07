using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _jumpForse = 0.7f;

    private SpriteRenderer _sprite;
    private Rigidbody2D _rigitBody;
    private bool _isGrounded;

    private void Start()
    {
        _rigitBody = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
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
            MakeMovement(false);
        if (Input.GetKey(KeyCode.A))
            MakeMovement(true);
        if (Input.GetKey(KeyCode.W) && _isGrounded)
            _rigitBody.AddForce(Vector2.up * _jumpForse, ForceMode2D.Impulse);
    }

    private void MakeMovement(bool isSideLeft)
    {
        transform.Translate((isSideLeft? Vector3.left: Vector3.right) * Time.deltaTime * _speed);
        _sprite.flipX = isSideLeft;
    }
}
