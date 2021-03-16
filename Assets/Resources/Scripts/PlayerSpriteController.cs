using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{
    private PlayerControls _playerControls = null;

    private SpriteRenderer _spriteRenderer = null;

    // Start is called before the first frame update
    private void Awake()
    {
        _playerControls = GetComponent<PlayerControls>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerSpriteFlip();
    }

    private void PlayerSpriteFlip()
    {
        if (_playerControls.ReadControls().x < -0.1f)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_playerControls.ReadControls().x > 0.1f)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
