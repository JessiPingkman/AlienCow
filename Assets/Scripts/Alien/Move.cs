using UnityEngine;

namespace Alien
{
    public class Move : MonoBehaviour
    {
        public Transform Target;
    
        private float _startTime;
        private float _distance;

        private void OnEnable() 
        {
            Initialize();
        }

        private void Initialize()
        {
            _startTime = Time.time;
            _distance = Vector3.Distance(transform.position, Target.position);
        }

        public void MoveForward(float speed)
        {
            float distCovered = (Time.time - _startTime) * speed;
            float fractionOfDistance = distCovered / _distance;
            transform.position = Vector2.Lerp(transform.position, Target.position, fractionOfDistance);
        }

        public void ChangeTarget(Transform newTarget)
        {
            Target = newTarget;
            _startTime = Time.time;
            _distance = Vector3.Distance(transform.position, Target.position);
        }
    }
}
