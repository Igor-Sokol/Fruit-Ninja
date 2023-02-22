using System.Linq;
using Blocks.BlockComponents;
using Blocks.BlockServices.PlayingFieldServices.Implementations;

namespace Blocks.BlockServices.BeyondZoneSystem.Implementations
{
    public class DisableMimicEffects : IBeyondService
    {
        public void BeyondZoneAction(Block block)
        {
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