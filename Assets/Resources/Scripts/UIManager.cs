using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPopup = null;

    [SerializeField] private Health _playerHealth = null;


    private void Start()
    {
        _gameOverPopup.SetActive(false);
        _playerHealth.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnPlayerDeath(object sender, System.EventArgs e)
    {
        _gameOverPopup.SetActive(true);
        _playerHealth.OnPlayerDeath -= OnPlayerDeath;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
