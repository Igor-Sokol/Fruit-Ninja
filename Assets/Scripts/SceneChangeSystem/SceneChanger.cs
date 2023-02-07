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

        [SerializeField] private LoadingUI loadingUI;
        [SerializeField] private float secondBeforeLoading;
        [SerializeField] private float secondAfterLoading;

        public event Action OnSceneLoaded;

        private void Awake()
        {
            if (SceneChanger.IsValid)
            {
                Destroy(this.gameObject);
            }
            else
            {
                loadingUI.gameObject.SetActive(true);
                DontDestroyOnLoad(this);
            }
        }

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
            
            OnSceneLoaded?.Invoke();
        }
    }
}