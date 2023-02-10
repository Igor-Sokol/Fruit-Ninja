using System.Collections;
using Managers;
using PlayingFieldComponents;
using UnityEngine;

namespace UI.Game
{
    public class ComboRenderer : MonoBehaviour
    {
        private Coroutine _comboAnimationHandler;
        private float _timer;
    
        [SerializeField] private ComboManager comboManager;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private PlayingField playingField;
        [SerializeField] private TextValue[] textValues;
        [SerializeField] private int comboValueToShow;

        private void OnEnable()
        {
            comboManager.OnComboIncreased += ShowCombo;
        }

        private void OnDisable()
        {
            comboManager.OnComboIncreased -= ShowCombo;
        }

        public void SetPosition(Vector3 position)
        {
            RectTransform rect = transform as RectTransform;
            
            if (!rect) return;

            float xPosition = Mathf.Clamp(position.x, 0, playingField.Resolution.x - rect.rect.width);
            float yPosition = Mathf.Clamp(position.y, 0, playingField.Resolution.y - rect.rect.height);

            transform.position = new Vector2(xPosition, yPosition);
        }
        
        private void ShowCombo()
        {
            if (comboManager.CurrentCombo >= comboValueToShow)
            {
                _timer = 0;
        
                foreach (var textValue in textValues)
                {
                    textValue.ForceSetValue(comboManager.CurrentCombo);
                }

                _comboAnimationHandler ??= StartCoroutine(ComboAnimation());
            }
        }

        private IEnumerator ComboAnimation()
        {
            while (_timer < comboManager.ComboShowTime)
            {
                _timer += Time.deltaTime;
            
                canvasGroup.alpha = Mathf.Lerp(1, 0, _timer / comboManager.ComboShowTime);

                yield return null;
            }

            _comboAnimationHandler = null;
        }
    }
}