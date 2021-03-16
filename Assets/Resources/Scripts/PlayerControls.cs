using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private float _moveHorizontal;
    private float _moveVertical;

    private Vector2 _movement;


    // Update is called once per frame
    private void Update()
    {
        _moveHorizontal = Input.GetAxisRaw("Horizontal");
        _moveVertical = Input.GetAxisRaw("Vertical");

        ReadControls();
        ReadJumping();
    }

    public Vector2 ReadControls()
    {
        return _movement = new Vector2(_moveHorizontal, _moveVertical);
    }

    public bool ReadJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }

        return false;
    }
}
