using UnityEngine;
using UnityEngine.UI;

namespace Models.Blur.Contracts
{
    public abstract class BlurSetting : MonoBehaviour, IBlurSetting
    {
        public abstract Image Image { get; set; }
        public abstract float Blur { get; set; }
    }
}