using System.Collections;
using System.Collections.Generic;
using BlockComponents;
using UnityEngine;

namespace CuttingSystem
{
    public class CuttingManager : MonoBehaviour, ICutting
    {
        private Block _block;
        private List<ICuttingService> _cuttingServices;
        private Coroutine _switchTimerHandler;
        private bool _state;
        private float _stateTimeLeft;

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

            if (_switchTimerHandler != null)
            {
                StopCoroutine(_switchTimerHandler);
            }
        }

        public void Clear()
        {
            _state = true;
            _stateTimeLeft = 0;
            
            _cuttingServices.Clear();
            if (_switchTimerHandler != null)
            {
                StopCoroutine(_switchTimerHandler);
            }
        }
        
        public void SwitchState(bool state)
        {
            if (_switchTimerHandler != null)
            {
                StopCoroutine(_switchTimerHandler);
            }

            _state = state;
            _stateTimeLeft = 0;
        }
        
        public void SwitchState(bool state, float time)
        {
            _state = state;
            _stateTimeLeft = time;
            _switchTimerHandler ??= StartCoroutine(SwitchTimer());
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

        private IEnumerator SwitchTimer()
        {
            while (_stateTimeLeft > 0)
            {
                _stateTimeLeft -= Time.deltaTime;

                yield return null;
            }

            _state = !_state;
            _switchTimerHandler = null;
        }
    }
}