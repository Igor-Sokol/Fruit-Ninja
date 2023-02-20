using System.Linq;
using UnityEngine;

namespace Models.Singleton
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
                    _instance = Resources.LoadAll<T>(string.Empty).FirstOrDefault();
                }

                return _instance;
            }
        }
    }
}