using System.Collections.Generic;
using BlockComponents;
using PlayingFieldServices;
using TimerSystem;
using UnityEngine;

namespace TimerActions
{
    public class InvulnerableTimeAction : ITimerAction
    {
        private readonly Block _block;
        private readonly IPlayingFieldService[] _playingFieldServices;
        private readonly ParticleSystem[] _particlePrefabs;
        private List<ParticleSystem> _particles;

        public InvulnerableTimeAction(Block block, IPlayingFieldService[] playingFieldServices, ParticleSystem[] particlePrefabs)
        {
            _block = block;
            _playingFieldServices = playingFieldServices;
            _particlePrefabs = particlePrefabs;
        }

        public void OnBegin(float secondsLeft)
        {
            _block.BlockPhysic.enabled = false;

            if (_playingFieldServices != null)
            {
                foreach (var service in _playingFieldServices)
                {
                    _block.PlayingFieldServiceManager.AddService(service);
                }
            }

            _particles = new List<ParticleSystem>();
            if (_particlePrefabs != null)
            {
                foreach (var particlePrefab in _particlePrefabs)
                {
                    var instance = Object.Instantiate(particlePrefab, _block.transform.position, Quaternion.identity);
                    _particles.Add(instance);
                }
            }
        }

        public void OnUpdate(float secondsLeft)
        {
        }

        public void OnComplete()
        {
            _block.BlockPhysic.enabled = true;

            foreach (var particle in _particles)
            {
                Object.Destroy(particle.gameObject);
            }

            foreach (var service in _playingFieldServices)
            {
                _block.PlayingFieldServiceManager.RemoveService(service);
            }
        }
    }
}