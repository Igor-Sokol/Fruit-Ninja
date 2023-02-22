using System.Collections.Generic;
using Blocks.BlockComponents;
using UnityEngine;

namespace Blocks.BlockServices.PlayingFieldServices
{
    public class PlayingFieldServiceManager : MonoBehaviour, IOnPlayingField
    {
        private Block _block;
        private List<IPlayingFieldService> _playingFieldService;
        private List<IPlayingFieldService> _tempServices;

        public IEnumerable<IPlayingFieldService> Services => _playingFieldService;

        private void Awake()
        {
            _playingFieldService = new List<IPlayingFieldService>();
            _tempServices = new List<IPlayingFieldService>();
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
            _tempServices.AddRange(_playingFieldService);
            foreach (var service in _tempServices)
            {
                service.OnPlayingField(_block);
            }
            _tempServices.Clear();
        }
    }
}