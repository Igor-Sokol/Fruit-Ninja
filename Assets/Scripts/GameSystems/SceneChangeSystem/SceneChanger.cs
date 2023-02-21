using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSystems.SceneChangeSystem
{
    public class SceneChanger : MonoBehaviour
    {
        private float _timer;
        private AsyncOperation _sceneLoadHandler;

        [SerializeField] private LoadingUI loadingUI;
        [SerializeField] private float secondBeforeLoading;
        [SerializeField] private float secondAfterLoading;

        public event Action OnSceneLoaded;
        public bool SceneLoaded => _sceneLoadHandler == null;

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadNewScene(sceneName));
        }

        private IEnumerator LoadNewScene(string sceneName)
        {
            loadingUI.Enable();
            
            _timer = secondBeforeLoading;
            while (_timer > 0)
            {
                _timer -= Time.deltaTime;
                yield return null;
            }
            
            _sceneLoadHandler = SceneManager.LoadSceneAsync(sceneName);
            yield return _sceneLoadHandler;
            loadingUI.Disable();
            
            _timer = secondAfterLoading;
            while (_timer > 0)
            {
                _timer -= Time.deltaTime;
                yield return null;
            }
            
            _sceneLoadHandler = null;
            OnSceneLoaded?.Invoke();
        }
    }
}