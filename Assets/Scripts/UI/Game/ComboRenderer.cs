using System.Collections;
using Managers;
using PlayingFieldComponents;
using UnityEngine;

namespace UI.Game
{
    public class ComboRenderer : MonoBehaviour
    {
        private Coroutine _moveToPositionHandler;
        private Vector2 _newPosition;
        private Coroutine _comboAnimationHandler;
        private float _timer;
    
        [SerializeField] private ComboManager comboManager;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private PlayingField playingField;
        [SerializeField] private TextValue[] textValues;
        [SerializeField] private int comboValueToShow;
        [SerializeField] private float moveSpeed;

        private void OnEnable()
        {
            comboManager.OnComboIncreased += ShowCombo;
        }

        private void OnDisable()
        {
            comboManager.OnComboIncreased -= ShowCombo;
        }

        public void SetPosition(Vector3 wordPosition)
        {
            RectTransform rect = transform as RectTransform;
            if (!rect) return;

            Vector2 pointPosition = playingField.WorldToScreenPoint(wordPosition);
            float xPosition = Mathf.Clamp(pointPosition.x, 0, playingField.Resolution.x - rect.rect.width);
            float yPosition = Mathf.Clamp(pointPosition.y, 0, playingField.Resolution.y - rect.rect.height);

            _newPosition = playingField.ScreenToWorldPoint(new Vector2(xPosition, yPosition));
            _moveToPositionHandler ??= StartCoroutine(MoveToPositionHandler());
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

        private IEnumerator MoveToPositionHandler()
        {
            while (((Vector2)transform.position - _newPosition).magnitude > 0.1f)
            {
                transform.position = Vector2.Lerp(transform.position, _newPosition, moveSpeed * Time.deltaTime);
                
                yield return null;
            }

            _moveToPositionHandler = null;
        }
    }
}