using System;
using UnityEngine;

namespace HealthSystem
{
    public class HealthService : MonoBehaviour
    {
        private int _currentHealth;
        
        [SerializeField] private int maxHealth;
        [SerializeField] private int startHealth;

        public int Health => _currentHealth;
        public int StartHealth => startHealth;
        public int MaxHealth => maxHealth;
        public event Action OnPlayerLose;
        public event Action<int> HealthIncreased;
        public event Action<int> HealthDecreased;
        
        private void Start()
        {
            Clear();
        }

        public void Clear()
        {
            _currentHealth = startHealth;
        }
        
        public void AddHealth(int value)
        {
            _currentHealth = _currentHealth + value > maxHealth ? maxHealth : _currentHealth + value;
            
            HealthIncreased?.Invoke(value);
        }
        
        public void RemoveHealth(int value)
        {
            _currentHealth -= value;

            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                OnPlayerLose?.Invoke();
            }
            
            HealthDecreased?.Invoke(value);
        }
    }
}