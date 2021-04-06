using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    private float _maxSpeed = 3f;
    [SerializeField] private float _jumpForce = 5f;

    private bool _isShooting = false;

    [SerializeField] private LayerMask _groundLayerMask;

    private Rigidbody2D _rigidbody2D = null;

    private CapsuleCollider2D _capsuleCollider2D = null;

    private PlayerControls _playerControls = null;

    private Animator _animator = null;

    private Vector2 _movement;
    

    // Start is called before the first frame update
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerControls = GetComponent<PlayerControls>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        _movement = _playerControls.ReadInput();
        Jump();

        _isShooting = _playerControls.ReadShooting();
        ShootAnimation();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (_rigidbody2D.velocity.magnitude > _maxSpeed)
        {
            _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * _maxSpeed;
        }

        MovePlayer();
    }

    private void MovePlayer()
    {
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        _rigidbody2D.AddForce(_movement * _moveSpeed);
        _animator.SetFloat("Speed", _rigidbody2D.velocity.magnitude * Mathf.Abs(_movement.x));
    }

    private void Jump()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _animator.SetBool("isJumping", true);
        }
    }

    private void ShootAnimation()
    {
       _animator.SetBool("isShooting", _isShooting);
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(_capsuleCollider2D.bounds.center, _capsuleCollider2D.bounds.size, 0, Vector2.down, 0.01f, _groundLayerMask.value);
        if (raycastHit2D.collider)
        {
            _animator.SetBool("isJumping", false);
            return true;
        }

        return false;
    }
}
