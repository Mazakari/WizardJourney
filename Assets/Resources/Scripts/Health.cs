using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;

    [SerializeField] private Slider _playerHealthBar = null;

    [SerializeField] private Health _playerHealth = null;

    public float MaxHealth { get { return _maxHealth; } }

    private float _currentHealth;

    private bool _isAlive = true;

    private Animator _animator = null;

    public event EventHandler OnPlayerDeath;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _currentHealth = _maxHealth;
        _isAlive = true;

        if (gameObject.GetComponent<PlayerControls>())
        {
            _playerHealthBar.maxValue = _playerHealth.MaxHealth;
            _playerHealthBar.value = _playerHealthBar.maxValue;
        }
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (gameObject.GetComponent<PlayerControls>())
        {
            _playerHealthBar.value -= damage;
        }
        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if (_currentHealth <= 0.001f)
        {
            _currentHealth = 0;
            _isAlive = false;
            _animator.SetBool("isAlive", _isAlive);
            if (gameObject.GetComponent<PlayerControls>())
            {
                OnPlayerDeath?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
