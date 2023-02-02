using UnityEngine;

namespace Animations.Fabric.Configs
{
    [CreateAssetMenu(fileName = "RotateAnimation", menuName = "Animations/RotateAnimation")]
    public class RotateAnimationConfig : AnimationFabric
    {
        [SerializeField] private RotateDirection rotateDirection;
        [SerializeField] private Vector2 speedRange;

        public override IAnimation Generate()
        {
            var animation = new RotateAnimation();

            bool clockwise = false;
            switch (rotateDirection)
            {
                case RotateDirection.Clockwise:
                    clockwise = true;
                    break;
                case RotateDirection.AntiClockwise:
                    clockwise = false;
                    break;
                case RotateDirection.Random:
                    clockwise = Random.Range(0, 2) > 0;
                    break;
            }
            
            animation.SetUp(clockwise,
                Random.Range(speedRange.x, speedRange.y));

            return animation;
        }
    }

    public enum RotateDirection
    {
        AntiClockwise,
        Clockwise,
        Random,
    }
}