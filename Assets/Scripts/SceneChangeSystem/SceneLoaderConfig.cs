using Singleton;
using UnityEngine;

namespace SceneChangeSystem
{
    [CreateAssetMenu(menuName = "SceneLoaderConfig")]
    public class SceneLoaderConfig : ScriptableObjectSingleton<SceneLoaderConfig>
    {
        [SerializeField] private LoadingUI loadingUIPrefab;
        [SerializeField] private float secondBeforeLoading;
        [SerializeField] private float secondAfterLoading;

        public LoadingUI LoadingUIPrefab => loadingUIPrefab;
        public float SecondBeforeLoading => secondBeforeLoading;
        public float SecondAfterLoading => secondAfterLoading;
    }
}