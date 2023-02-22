using System.Linq;
using Blocks.BlockComponents;
using Blocks.BlockServices.PlayingFieldServices.Implementations;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem.Implementations
{
    public class DisableMimic : ICuttingService
    {
        public void Cut(Block block, Vector2 bladeVector)
        {
            var services = block.PlayingFieldServiceManager.Services
                .Where(s => s.GetType() == typeof(Mimic)).ToArray();
            
            foreach (var service in services)
            {
                block.PlayingFieldServiceManager.RemoveService(service);
            }
            
            block.CuttingManager.RemoveService(this);
            
            MimicEffects mimicEffects = (MimicEffects)block.PlayingFieldServiceManager.Services
                .FirstOrDefault(s => s.GetType() == typeof(MimicEffects));

            if (mimicEffects != null)
            {
                mimicEffects.DisableEffects();
                block.PlayingFieldServiceManager.RemoveService(mimicEffects);
            }
        }
    }
}