using TMPro;
using UnityEngine;

namespace Particles
{
    public class TextParticle : MonoBehaviour
    {
        [SerializeField] private TMP_Text tmpText;

        public void SetText(string text)
        {
            tmpText.text = text;
        }
    
        public void SetText(string text, Color color)
        {
            tmpText.text = text;
            tmpText.color = color;
        }

        private void DestroyCallback()
        {
            Destroy(gameObject);
        }
    }
}
