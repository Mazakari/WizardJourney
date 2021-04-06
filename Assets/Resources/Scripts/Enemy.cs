using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _enemyDamage;

    private float _pushForce = 1.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControls>())
        {
            Vector2 pushDirection = ((gameObject.transform.position - collision.gameObject.transform.position).normalized) * -1;
            collision.gameObject.GetComponent<Health>().TakeDamage(_enemyDamage);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection * _pushForce, ForceMode2D.Impulse);
        }
    }
}
