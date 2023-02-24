using System.Collections;
using Blur;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class FilterRenderer : MonoBehaviour
    {
        private Coroutine _showTimerHandler;
        private float _timer;
        private float _waitTime;
        
        [SerializeField] private Image image;
        [SerializeField] private BlurController uiBlur;
        [SerializeField] private float intensity;
        [SerializeField][Range(0, 1)] private float showTiming;
        [SerializeField][Range(0, 1)] private float enableAlpha;
        [SerializeField][Range(0, 1)] private float disableAlpha;

        public void Show(float waitTime)
        {
            _timer = 0;
            _waitTime = waitTime;
            _showTimerHandler ??= StartCoroutine(ShowTimer());
        }

        private IEnumerator ShowTimer()
        {
            while (_timer < _waitTime * showTiming)
            {
                _timer += Time.deltaTime;
                
                var color = image.color;
                color.a = Mathf.Lerp(disableAlpha, enableAlpha, _timer / _waitTime / showTiming);
                uiBlur.Blur = Mathf.Lerp(0, intensity, _timer / _waitTime / showTiming);
                image.color = color;
                
                yield return null;
            }
            
            while (_timer < _waitTime * (1 - showTiming))
            {
                _timer += Time.deltaTime;

                yield return null;
            }

            while (_timer < _waitTime)
            {
                _timer += Time.deltaTime;

                var t = (_timer - _waitTime * (1 - showTiming)) / (_waitTime * showTiming);
                
                var color = image.color;
                color.a = Mathf.Lerp(enableAlpha, disableAlpha, t);
                uiBlur.Blur = Mathf.Lerp(intensity, 0, t);
                image.color = color;
                
                yield return null;
            }

            _showTimerHandler = null;
        }
    }
}