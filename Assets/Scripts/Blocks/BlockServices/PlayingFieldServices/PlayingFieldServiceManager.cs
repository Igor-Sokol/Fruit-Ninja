using System.Collections.Generic;
using BlockComponents;
using UnityEngine;

namespace PlayingFieldServices
{
    public class PlayingFieldServiceManager : MonoBehaviour, IOnPlayingField
    {
        private Block _block;
        private List<IPlayingFieldService> _playingFieldService;

        private void Awake()
        {
            _playingFieldService = new List<IPlayingFieldService>();
        }

        public void Init(Block block, IEnumerable<IPlayingFieldService> services)
        {
            Clear();
            
            _block = block;
            
            if (services != null)
            {
                _playingFieldService.AddRange(services);
            }
        }

        public void Clear()
        {
            _playingFieldService.Clear();
        }

        public void AddService(IPlayingFieldService service)
        {
            _playingFieldService.Add(service);
        }

        public void RemoveService(IPlayingFieldService service)
        {
            _playingFieldService.Remove(service);
        }

        public void OnPlayingField()
        {
            foreach (var service in _playingFieldService)
            {
                service.OnPlayingField(_block);
            }
        }
    }
}