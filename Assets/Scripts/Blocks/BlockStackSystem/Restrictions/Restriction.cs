using UnityEngine;

namespace Blocks.BlockStackSystem.Restrictions
{
    public abstract class Restriction : MonoBehaviour, IRestriction
    {
        public abstract bool IsRestricted();
    }
}