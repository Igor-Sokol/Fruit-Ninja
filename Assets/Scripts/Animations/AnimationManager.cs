using System.Collections.Generic;
using System.Linq;
using Animations.Fabric;
using UnityEngine;

namespace Animations
{
    public class AnimationManager : MonoBehaviour
    {
        [SerializeField] private Vector2Int animationCountRange;
        [SerializeField] private AnimationFactory[] animationFabrics;

        public IAnimation[] GetRandomAnimations()
        {
            int animationCount = Random.Range(animationCountRange.x,
                Mathf.Min(animationCountRange.y, animationFabrics.Length) + 1);

            IAnimation[] result = new IAnimation[animationCount];
            
            List<AnimationFactory> fabrics = animationFabrics.ToList();
            for (int i = 0; i < animationCount; i++)
            {
                int fabricIndex = Random.Range(0, fabrics.Count);
                result[i] = fabrics[fabricIndex].Generate();
                fabrics.RemoveAt(fabricIndex);
            }

            return result;
        }
    }
}