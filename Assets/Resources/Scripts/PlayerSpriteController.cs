using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{
    private PlayerControls _playerControls = null;

    private SpriteRenderer _spriteRenderer = null;

    [SerializeField] private Transform _shootSource = null;

    // Start is called before the first frame update
    private void Awake()
    {
        _playerControls = GetComponent<PlayerControls>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        FlipPlayerSprite();
        FlipShootObject();
    }

    private void FlipPlayerSprite()
    {
        if (_playerControls.ReadInput().x < -0.1f)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_playerControls.ReadInput().x > 0.1f)
        {
            _spriteRenderer.flipX = false;
        }
    }

    private void FlipShootObject()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _shootSource.transform.localPosition = new Vector3(Mathf.Abs(_shootSource.transform.localPosition.x), _shootSource.transform.localPosition.y);
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            _shootSource.transform.localPosition = new Vector3(_shootSource.transform.localPosition.x * -1, _shootSource.transform.localPosition.y);
        }
       
    }
}
