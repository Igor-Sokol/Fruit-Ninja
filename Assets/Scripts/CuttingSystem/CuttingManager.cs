using System.Collections.Generic;
using BlockComponents;
using UnityEngine;

namespace CuttingSystem
{
    public class CuttingManager : MonoBehaviour, ICutting
    {
        private Block _block;
        private List<ICuttingService> _cuttingServices;
        private bool _state;

        private void Awake()
        {
            _cuttingServices = new List<ICuttingService>();
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
                for (int i = 0; i < _cuttingServices.Count; i++)
                {
                    var result = _cuttingServices[i].Cut(_block, bladeVector);

                    switch (result)
                    {
                        case ServiceCallbackAction.Delete:
                        {
                            _cuttingServices.RemoveAt(i);
                            i--;
                            break;
                        }
                    }
                }
            }
        }
    }
}