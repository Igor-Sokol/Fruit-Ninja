using System;
using System.Collections.Generic;
using UnityEngine;

namespace HealthSystem
{
    public class HealthView : MonoBehaviour
    {
        private List<Heart> _hearts;

        [SerializeField] private HealthService healthService;
        [SerializeField] private ObjectPool<Heart> heartPool;
        [SerializeField] private Transform container;
            
        private void Start()
        {
            _hearts = new List<Heart>(healthService.MaxHealth);
            
            AddHeart(healthService.StartHealth);
        }

        public void Clear()
        {
            foreach (var heart in _hearts)
            {
                heartPool.Return(heart);
            }
            
            AddHeart(healthService.StartHealth);
        }

        private void AddHeart(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var heart = heartPool.Get();
                heart.transform.SetParent(container);
                _hearts.Add(heart);
                heart.Appear();
            }
        }
        
        private void RemoveHeart(int count)
        {
            for (int i = 0; i < count && _hearts.Count > 0; i++)
            {
                var heart = _hearts[_hearts.Count - 1];
                _hearts.RemoveAt(_hearts.Count - 1);

                heart.OnDisappeared += ReturnHeart;
                heart.Disappear();
            }
        }

        private void ReturnHeart(Heart heart)
        {
            heart.OnDisappeared -= ReturnHeart;
            heartPool.Return(heart);
        }
        
        private void OnEnable()
        {
            healthService.HealthIncreased += AddHeart;
            healthService.HealthDecreased += RemoveHeart;
        }

        private void OnDisable()
        {
            healthService.HealthIncreased -= AddHeart;
            healthService.HealthDecreased -= RemoveHeart;
        }
    }
}