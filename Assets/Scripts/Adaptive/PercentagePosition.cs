using UnityEngine;

namespace Adaptive
{
    public class PercentagePosition : MonoBehaviour
    {
        [SerializeField] private Vector2 percentagePosition;

        private void Awake()
        {
            transform.position = ScreenManager.Instance.PositionFromPercentage(percentagePosition);
        }
    }
}