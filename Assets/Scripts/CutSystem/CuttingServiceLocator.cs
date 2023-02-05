using System;
using System.Collections.Generic;
using System.Linq;
using CutSystem.CuttingServices;
using UnityEngine;

namespace CutSystem
{
    public class CuttingServiceLocator : Singleton<CuttingServiceLocator>
    {
        private List<Type> _cuttingServiceTypes;

        [SerializeField] private CuttingService[] cuttingServices;

        private void Awake()
        {
            CreateServiceTypeList();
        }

        public List<CuttingService> GetServices(CuttingServiceType serviceType)
        {
            var services = new List<CuttingService>();

            if ((int)serviceType < 0)
            {
                services.AddRange(cuttingServices);
                return services;
            }
            
            for (int i = 1; i <= (int)serviceType; i <<= 1)
            {
                if (((int)serviceType & 1) > 0)
                {
                    Type type = _cuttingServiceTypes[(int)Mathf.Sqrt(i)];
                    var service = cuttingServices.FirstOrDefault(s => s.GetType() == type);
                    services.Add(service);
                }
            }

            return services;
        }

        private void CreateServiceTypeList()
        {
            _cuttingServiceTypes = new List<Type>()
            {
                { typeof(PartsCutter) },
                { typeof(BlotParticle) },
                { typeof(ScoreIncrease) }
            };
        }
    }
}