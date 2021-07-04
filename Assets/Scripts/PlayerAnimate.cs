using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class PlayerAnimate : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyMover enemyMover))
            _animator.SetTrigger("Hit");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
            _animator.SetBool("IsWalk", true);
        if (Input.GetKey(KeyCode.E))
            _animator.SetTrigger("Attack");
        if (Input.GetKey(KeyCode.A))
            _animator.SetBool("IsWalk", true);
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            _animator.SetBool("IsWalk", false);
    }
}
