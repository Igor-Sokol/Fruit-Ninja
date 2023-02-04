using System;
using System.Collections.Generic;
using UnityEngine;

namespace HealthSystem
{
    public class HealthBar : MonoBehaviour
    {
        private List<Heart> _hearts;
        private int _currentHealth;
    
        [SerializeField] private Heart prefab;
        [SerializeField] private Transform container;
        [SerializeField] private int maxHealth;
        [SerializeField] private int startHealth;

        public int Health => _currentHealth;
        public event Action OnPlayerLose;

        private void Start()
        {
            _hearts = new List<Heart>(maxHealth);

            CreateHealth();
        }

        public void AddHeart(int count)
        {
            if (_currentHealth >= maxHealth) return;
            
            for (int i = 0; i < count && _currentHealth < maxHealth; i++)
            {
                _hearts[_currentHealth].Appear();
                _currentHealth++;
            }
        }

        public void RemoveHeart(int count)
        {
            if (_currentHealth <= 0) return;
            
            for (int i = 0; i < count; i++)
            {
                _hearts[_currentHealth - 1].Disappear();
                _currentHealth--;
                
                if (_currentHealth <= 0)
                {
                    OnPlayerLose?.Invoke();
                    return;
                }
            }
        }

        public void Init()
        {
            for (int i = 0; i < maxHealth; i++)
            {
                var heart = _hearts[i];

                if (i >= startHealth)
                {
                    heart.gameObject.SetActive(false);
                }
                else
                {
                    heart.Appear();
                }
            }

            _currentHealth = startHealth > maxHealth ? maxHealth : startHealth;
        }
        
        private void CreateHealth()
        {
            for (int i = 0; i < maxHealth; i++)
            {
                var heart = Instantiate(prefab, container);
                _hearts.Add(heart);
            }
            
            Init();
        }
    }
}