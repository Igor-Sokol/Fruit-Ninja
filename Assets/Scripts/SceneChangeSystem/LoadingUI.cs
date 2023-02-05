using UnityEngine;

namespace SceneChangeSystem
{
    public class LoadingUI : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] particles;

        public void Enable()
        {
            foreach (var particle in particles)
            {
                particle.Play();
            }
        }
        
        public void Disable()
        {
            foreach (var particle in particles)
            {
                particle.Stop();
            }
        }
    }
}