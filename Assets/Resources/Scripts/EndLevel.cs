using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControls>())
        {
            if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
