using System;

namespace CutSystem
{
    [Flags]
    public enum CuttingServiceType
    {
        PartsCutter = 1,
        BlotParticle = 2,
        ScoreIncrease = 4,
    }
}