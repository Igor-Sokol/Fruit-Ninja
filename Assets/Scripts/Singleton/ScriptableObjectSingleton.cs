using UnityEngine;

namespace Singleton
{
    public class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObject
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (!_instance)
                {
                    T[] instances = Resources.FindObjectsOfTypeAll<T>();

                    if (instances.Length == 1)
                    {
                        _instance = instances[0];
                        _instance.hideFlags = HideFlags.DontUnloadUnusedAsset;
                    }
                    else
                    {
                        return null;
                    }
                }

                return _instance;
            }
        }
    }
}