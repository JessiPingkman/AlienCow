using UnityEngine;

namespace Common
{
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        private float _moveSpeed = 0.02f;
        [SerializeField]
        private Transform _target;
    
        private float _distance;
        private float _startTime;

        private void OnEnable() 
        {
            Initialize();
        }

        private void Initialize()
        {
            _startTime = Time.time;
            _distance = Vector3.Distance(transform.position, _target.position);
        }

        public void Move()
        {
            var distCovered = (Time.time - _startTime) * _moveSpeed;
            var step = distCovered / _distance;
            transform.position = Vector2.Lerp(transform.position, _target.position, step);
        }

        public void SetTarget(Transform newTarget)
        {
            _target = newTarget;
            _startTime = Time.time;
            _distance = Vector3.Distance(transform.position, _target.position);
        }

        public Vector3 GetTargetPosition()
        {
            return _target.position;
        }
    }
}
