using UnityEngine;

namespace BlockStackSystem.Restrictions
{
    public abstract class Restriction : MonoBehaviour, IRestriction
    {
        public abstract bool IsRestricted();
    }
}