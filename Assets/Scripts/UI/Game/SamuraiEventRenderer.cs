using UnityEngine;

namespace UI.Game
{
    public class SamuraiEventRenderer : MonoBehaviour
    {
        [SerializeField] private Animation animationRenderer;
        [SerializeField] private string enableAnimation;
        [SerializeField] private string disableAnimation;
        [SerializeField] private TextValue timerRenderer;

        public TextValue TimerRenderer => timerRenderer;

        public void Enable()
        {
            animationRenderer.Play(enableAnimation);
        }

        public void Disable()
        {
            animationRenderer.Play(disableAnimation);
        }
    }
}