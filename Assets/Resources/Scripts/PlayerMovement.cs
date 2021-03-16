using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    private float _maxSpeed = 4f;
    [SerializeField] private float _jumpForce = 5f;

    private bool _isJumping = false;

    private Rigidbody2D _rigidbody2D = null;

    private PlayerControls _playerControls = null;

    private Animator _animator = null;

    // Start is called before the first frame update
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerControls = GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MovePlayer();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isJumping = false;
            _animator.SetBool("isJumping", _isJumping);
        }
    }

    private void MovePlayer()
    {
        _rigidbody2D.AddForce(_playerControls.ReadControls() * _moveSpeed);
        if (_rigidbody2D.velocity.magnitude > _maxSpeed)
        {
            _rigidbody2D.velocity = Vector2.ClampMagnitude(_rigidbody2D.velocity, _maxSpeed);
        }
        _animator.SetFloat("Speed", _rigidbody2D.velocity.magnitude);
    }

    private void Jump()
    {
        if (_playerControls.ReadJumping() && !_isJumping)
        {
            _isJumping = true;
            _animator.SetBool("isJumping", _isJumping);
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
