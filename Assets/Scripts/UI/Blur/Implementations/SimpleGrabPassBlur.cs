using Blur.Contracts;
using UnityEngine;
using UnityEngine.UI;

namespace Blur.Implementations
{
    public class SimpleGrabPassBlur : BlurSetting
    {
        private static readonly int BlurId = Shader.PropertyToID("_Size");

        private float _blur;

        public override Image Image { get; set; }
        public override float Blur { get => _blur; set { _blur = value; UpdateBlur(); } }

        private void UpdateBlur()
        {
            Image.material.SetFloat(BlurId, Blur);
        }
    }
}
