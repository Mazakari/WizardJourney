using System.Collections;
using UnityEngine;

public class Explotion : MonoBehaviour
{
    private CircleCollider2D _circleCollider2D = null;

    private Coroutine _explotionCoroutine = null;

    // Start is called before the first frame update
    void Start()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleCollider2D.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<WheelJoint2D>())
        {
            if (_explotionCoroutine != null)
            {
                StopCoroutine(_explotionCoroutine);
            }

            StartCoroutine(Explode());
        }
    }

    private IEnumerator Explode()
    {
        _circleCollider2D.enabled = true;

        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
    }
}
