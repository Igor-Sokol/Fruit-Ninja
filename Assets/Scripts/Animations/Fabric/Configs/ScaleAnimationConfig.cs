using UnityEngine;

namespace Animations.Fabric.Configs
{
    [CreateAssetMenu(fileName = "ScaleAnimation", menuName = "Animations/ScaleAnimation")]
    public class ScaleAnimationConfig : AnimationFabric
    {
        [SerializeField] private Vector2 scaleRange;
        [SerializeField] private Vector2 speedRange;

        public override IAnimation Generate()
        {
            var animation = new ScaleAnimation();
            animation.SetUp(
                Random.Range(scaleRange.x, scaleRange.y), 
                Random.Range(speedRange.x, speedRange.y));

            return animation;
        }
    }
}