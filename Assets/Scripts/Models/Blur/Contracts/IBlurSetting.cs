using UnityEngine.UI;

namespace Models.Blur.Contracts
{
    public interface IBlurSetting
    {
        public Image Image { get; set; }
        public float Blur { get; set; }
    }
}