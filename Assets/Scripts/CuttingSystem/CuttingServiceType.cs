using System;

namespace CuttingSystem
{
    [Flags]
    public enum CuttingServiceType
    {
        PartsCutter = 1,
        BlotParticle = 2,
        ScoreIncrease = 4,
    }
}