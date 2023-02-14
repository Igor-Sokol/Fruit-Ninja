using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneChangeSystem
{
    public class SceneChanger : Singleton<SceneChanger>
    {
        private float _timer;
        private AsyncOperation _sceneLoadHandler;

        private LoadingUI _loadingUI;
        private float _secondBeforeLoading;
        private float _secondAfterLoading;

        public event Action OnSceneLoaded;

        private void Awake()
        {
            if (SceneChanger.IsValid)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _secondBeforeLoading = SceneLoaderConfig.Instance.SecondBeforeLoading;
                _secondAfterLoading = SceneLoaderConfig.Instance.SecondAfterLoading;
                
                _loadingUI = Instantiate(SceneLoaderConfig.Instance.LoadingUIPrefab, transform);

                DontDestroyOnLoad(this);
            }
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadNewScene(sceneName));
        }

        private IEnumerator LoadNewScene(string sceneName)
        {
            _loadingUI.Enable();
            
            _timer = _secondBeforeLoading;
            while (_timer > 0)
            {
                _timer -= Time.deltaTime;
                yield return null;
            }
            
            _sceneLoadHandler = SceneManager.LoadSceneAsync(sceneName);
            yield return _sceneLoadHandler;
            _loadingUI.Disable();
            
            _timer = _secondAfterLoading;
            while (_timer > 0)
            {
                _timer -= Time.deltaTime;
                yield return null;
            }
            
            OnSceneLoaded?.Invoke();
        }
    }
}