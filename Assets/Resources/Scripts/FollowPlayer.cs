using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject _player = null;

    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerControls>().gameObject;
        _offset = gameObject.transform.position - _player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_player)
        {
            gameObject.transform.position = new Vector3(_player.transform.position.x, 0, _player.transform.position.z) + new Vector3(_offset.x, 0, _offset.z);
        }
        
    }
}
