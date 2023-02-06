using UnityEngine;

namespace SceneChangeSystem
{
    public class LoadingUI : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] particles;
        [SerializeField] private Canvas canvas;

        public void Enable()
        {
            canvas.gameObject.SetActive(true);
            foreach (var particle in particles)
            {
                particle.Play();
            }
        }
        
        public void Disable()
        {
            canvas.gameObject.SetActive(false);
            foreach (var particle in particles)
            {
                particle.Stop();
            }
        }
    }
}