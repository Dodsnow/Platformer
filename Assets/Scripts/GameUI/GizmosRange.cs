using UnityEngine;

namespace DefaultNamespace
{
    public class GizmosRange : MonoBehaviour
    {
        public Transform corner_min;
        public Transform corner_max;
        
        private void OnDrawGizmos()
        {
            Vector3 top_right = Vector3.zero;
            Vector3 bottom_right = Vector3.zero;
            Vector3 bottom_left = Vector3.zero;
            Vector3 top_left = Vector3.zero;

            if (corner_max && corner_max)
            {
                top_right = corner_max.position;
                bottom_left = corner_min.position;

                bottom_right = top_right;
                bottom_right.y = bottom_left.y;

                top_left = top_right;
                top_left.x = bottom_left.x;
            }

            Gizmos.color = Color.yellow;

            Gizmos.DrawLine(top_right, bottom_right);
            Gizmos.DrawLine(bottom_right, bottom_left);
            Gizmos.DrawLine(bottom_left, top_left);
            Gizmos.DrawLine(top_left, top_right);
        }
    }
}