using Models.Blur.Contracts;
using UnityEngine;
using UnityEngine.UI;

namespace Models.Blur.Implementations
{
    public class UIBlur : BlurSetting
    {
        private static readonly int BlurId = Shader.PropertyToID("_Intensity");

        private float _blur;

        public override Image Image { get; set; }
        public override float Blur { get => _blur; set { _blur = Mathf.Clamp01(value); UpdateBlur(); } }

        private void UpdateBlur()
        {
            Image.material.SetFloat(BlurId, Blur);
        }
    }
}