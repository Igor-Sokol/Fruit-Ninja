using System.Collections.Generic;
using Blocks.BlockComponents;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem
{
    public class CuttingManager : MonoBehaviour, ICutting
    {
        private Block _block;
        private List<ICuttingService> _tempCuttingServices;
        private List<ICuttingService> _cuttingServices;
        private bool _state;

        public List<ICuttingService> CuttingServices => _cuttingServices;

        private void Awake()
        {
            _cuttingServices = new List<ICuttingService>();
            _tempCuttingServices = new List<ICuttingService>();
        }

        public void Init(Block block, IEnumerable<ICuttingService> services)
        {
            Clear();
            
            _block = block;
            
            if (services != null)
            {
                _cuttingServices.AddRange(services);
            }
        }

        public void Clear()
        {
            _state = true;
            _cuttingServices.Clear();
        }
        
        public void SwitchState(bool state)
        {
            _state = state;
        }

        public void AddService(ICuttingService service)
        {
            _cuttingServices.Add(service);
        }

        public void RemoveService(ICuttingService service)
        {
            _cuttingServices.Remove(service);
        }

        public void Cut(Vector2 bladeVector)
        {
            if (_state)
            {
                _tempCuttingServices.AddRange(_cuttingServices);
                foreach (var service in _tempCuttingServices)
                {
                    service.Cut(_block, bladeVector);
                }
                _tempCuttingServices.Clear();
            }
        }
    }
}