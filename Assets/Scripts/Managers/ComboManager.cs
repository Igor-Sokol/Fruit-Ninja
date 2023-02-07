using System;
using System.Collections;
using UnityEngine;

namespace Managers
{
    public class ComboManager : MonoBehaviour
    {
        private Coroutine _comboTimer;
        private int _currentCombo;
        private float _timer;
        
        [SerializeField] private int maxCombo;
        [SerializeField] private float comboShowTime;

        public int CurrentCombo => _currentCombo;
        public float ComboShowTime => comboShowTime;
        public event Action OnComboIncreased;

        public void IncreaseCombo()
        {
            if (_currentCombo <= maxCombo)
            {
                _currentCombo = _currentCombo == maxCombo ? maxCombo : _currentCombo + 1;
                _timer = comboShowTime;

                if (_comboTimer == null)
                {
                    _comboTimer = StartCoroutine(ComboTimer());
                }
                
                OnComboIncreased?.Invoke();
            }
        }

        private IEnumerator ComboTimer()
        {
            while (_timer > 0)
            {
                _timer -= Time.deltaTime;
                yield return null;
            }

            _currentCombo = 0;
            _comboTimer = null;
        }
    }
}