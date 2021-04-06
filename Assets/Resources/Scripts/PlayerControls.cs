using UnityEngine;

[RequireComponent(typeof(Shooter))]

public class PlayerControls : MonoBehaviour
{
    private float _moveHorizontal;

    private Vector2 _movement;

    private Shooter _shooter = null;

    private SpriteRenderer _spriteRenderer = null;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _shooter = GetComponent<Shooter>();
    }

    // Update is called once per frame
    private void Update()
    {
        _moveHorizontal = Input.GetAxisRaw("Horizontal");
        _movement = new Vector2(_moveHorizontal, 0);
    }

    public Vector2 ReadInput()
    {
        return _movement;
    }

    public bool ReadShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _shooter.Shoot(_spriteRenderer.flipX);
            return true;
        }

        return false;
    }
}
