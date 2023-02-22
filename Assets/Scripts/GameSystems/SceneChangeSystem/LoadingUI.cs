using UnityEngine;

namespace GameSystems.SceneChangeSystem
{
    public class LoadingUI : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] particles;
        [SerializeField] private Canvas canvas;

        public void EnableUI() => canvas.gameObject.SetActive(true);

        public void DisableUI() => canvas.gameObject.SetActive(false);
        
        public void EnableParticles()
        {
            foreach (var particle in particles)
            {
                particle.Play();
            }
        }

        public void DisableParticles()
        {
            foreach (var particle in particles)
            {
                particle.Stop();
            }
        }
    }
}