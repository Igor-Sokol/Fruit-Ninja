using UnityEngine;

namespace Extensions
{
    public static class VectorExtension
    {
        public static Vector3 Rotate(this Vector3 direction, float degree)
        {
            var cos = Mathf.Cos(-degree * Mathf.Deg2Rad);
            var sin = Mathf.Sin(-degree * Mathf.Deg2Rad);
            var rotatedVector = new Vector3(
                direction.x * cos - direction.y * sin,
                direction.x * sin + direction.y * cos
            );

            return rotatedVector;
        }
    }
}