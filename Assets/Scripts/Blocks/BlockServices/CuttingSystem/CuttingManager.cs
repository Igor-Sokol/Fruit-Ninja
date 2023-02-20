using System.Collections.Generic;
using BlockComponents;
using UnityEngine;

namespace CuttingSystem
{
    public class CuttingManager : MonoBehaviour, ICutting
    {
        private Block _block;
        private List<ICuttingService> _addCuttingServices;
        private List<ICuttingService> _deleteCuttingServices;
        private List<ICuttingService> _cuttingServices;
        private bool _state;

        private void Awake()
        {
            _cuttingServices = new List<ICuttingService>();
            _addCuttingServices = new List<ICuttingService>();
            _deleteCuttingServices = new List<ICuttingService>();
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
            _addCuttingServices.Add(service);
        }

        public void RemoveService(ICuttingService service)
        {
            _deleteCuttingServices.Add(service);
        }

        public void Cut(Vector2 bladeVector)
        {
            if (_state)
            {
                foreach (var service in _cuttingServices)
                {
                    service.Cut(_block, bladeVector);
                }

                _cuttingServices.AddRange(_addCuttingServices);
                _addCuttingServices.Clear();

                foreach (var deleteService in _deleteCuttingServices)
                {
                    _cuttingServices.Remove(deleteService);
                }
                _deleteCuttingServices.Clear();
            }
        }
    }
}