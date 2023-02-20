using UnityEngine;

namespace Animations.Fabric.Configs
{
    [CreateAssetMenu(fileName = "ScaleAnimation", menuName = "Animations/ScaleAnimation")]
    public class ScaleAnimationConfig : AnimationFactory
    {
        [SerializeField] private Vector2 minScaleRange;
        [SerializeField] private Vector2 maxScaleRange;
        [SerializeField] private Vector2 speedRange;

        public override IAnimation Generate()
        {
            var animation = new ScaleAnimation();
            animation.SetUp(new Vector2(Random.Range(minScaleRange.x, minScaleRange.y),
                Random.Range(maxScaleRange.x, maxScaleRange.y)), Random.Range(speedRange.x, speedRange.y));

            return animation;
        }
    }
}