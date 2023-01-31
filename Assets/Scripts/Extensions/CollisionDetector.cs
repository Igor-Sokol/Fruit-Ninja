using UnityEngine;

namespace Extensions
{
    public static class CollisionDetector
    {
        public static bool IsCircleCollision(Vector2 center, float radius, Vector2[] shape)
        {
            for (int i = 0; i < shape.Length; i++)
            {
                int previous = i <= 0 ? (shape.Length - 1) : (i - 1);
                
                float aSqr = (shape[previous] - center).sqrMagnitude;
                float bSqr = (shape[i] - center).sqrMagnitude;
                float cSqr = (shape[previous] - shape[i]).sqrMagnitude;

                if (IsCollision(aSqr, bSqr, cSqr, radius)) return true;
            }

            return false;
        }

        private static bool IsCollision(float aSqr, float bSqr, float cSqr, float radius)
        {
            float a = Mathf.Sqrt(aSqr);
            float b = Mathf.Sqrt(bSqr);
            float c = Mathf.Sqrt(cSqr);

            float angelA = Mathf.Acos((aSqr + cSqr - bSqr) / (2 * a * c)) * Mathf.Rad2Deg;
            float angelY = Mathf.Acos((bSqr + cSqr - aSqr) / (2 * c * b)) * Mathf.Rad2Deg;

            if (angelA > 90 && radius > a)
            {
                return true;
            }
            else if (angelY > 90 && radius > b)
            {
                return true;
            }
            else if (angelA <= 90 && angelY <= 90)
            {
                float p = (a + b + c) / 2;

                float h = (2 / c) * Mathf.Sqrt(p * (p - a) * (p - b) * (p - c));

                if (radius > h) return true;
            }

            return false;
        }
    }
}