using System;
using System.Collections.Generic;
using System.Linq;
using CutSystem.CuttingServices;
using UnityEngine;

namespace CutSystem
{
    public class CuttingServiceLocator : Singleton<CuttingServiceLocator>
    {
        private Dictionary<int, Type> cuttingServiceTypes;

        [SerializeField] private CuttingService[] cuttingServices;

        private void Awake()
        {
            CreateServiceTypeDictionary();
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
                    Type type = cuttingServiceTypes[i];
                    var service = cuttingServices.FirstOrDefault(s => s.GetType() == type);
                    services.Add(service);
                }
            }

            return services;
        }

        private void CreateServiceTypeDictionary()
        {
            cuttingServiceTypes = new Dictionary<int, Type>
            {
                { 1 << 0, typeof(PartsCutter) },
                { 1 << 1, typeof(BlotParticle) },
                { 1 << 2, typeof(ScoreIncrease) }
            };
        }
    }
}