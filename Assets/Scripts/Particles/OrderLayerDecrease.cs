using UnityEngine;

namespace Particles
{
    public class OrderLayerDecrease : MonoBehaviour
    {
        private ParticleSystemRenderer _particleRenderer;

        [SerializeField] private ParticleSystem particle;

        private void Awake()
        {
            _particleRenderer = particle.GetComponent<ParticleSystemRenderer>();
        }

        private void Update()
        {
            if (_particleRenderer.sortingOrder > int.MinValue)
            {
                _particleRenderer.sortingOrder -= 1;
            }
        }
    }
}
