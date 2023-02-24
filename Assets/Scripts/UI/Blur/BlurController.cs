using Blur.Contracts;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Blur
{
    public class BlurController : MonoBehaviour
    {
        [SerializeField] private BlurSetting blurSetting;
        [SerializeField] private Image image;
        [SerializeField] private float blur;
        [SerializeField] private bool autoUpdate;

        public float Blur
        {
            get => blur;
            set
            {
                blur = value;
                blurSetting.Blur = blur;
            }
        }

        public bool AutoUpdate { get => autoUpdate; set => autoUpdate = value; }

        private void Awake()
        {
            blurSetting.Image = image;
            blurSetting.Blur = blur;
        }

        private void Update()
        {
            if (autoUpdate)
            {
                blurSetting.Blur = blur;
            }
        }
        
        
        #region Editor
#if UNITY_EDITOR
        private void OnValidate()
        {
            UpdateBlurInEditor();
        }

        private void UpdateBlurInEditor()
        {
            blurSetting.Image = image;
            blurSetting.Blur = blur;

            EditorUtility.SetDirty(image.material);
        }
#endif
        #endregion
    }
}
