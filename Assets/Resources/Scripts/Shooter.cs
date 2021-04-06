using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _bullet = null;
    [SerializeField] private float _fireSpeed;
    [SerializeField] private Transform _shootSource = null;

    public void Shoot(bool direction)
    {
        GameObject currentBullet = Instantiate(_bullet, _shootSource.position, Quaternion.identity, _shootSource);
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
        if (!direction)
        {
            currentBulletVelocity.velocity = new Vector2(_fireSpeed * 1, currentBulletVelocity.velocity.y);
        }
        else
        {
            currentBulletVelocity.velocity = new Vector2(_fireSpeed * -1, currentBulletVelocity.velocity.y);
        }
    }
}
