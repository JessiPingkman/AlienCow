using UnityEngine;

namespace Alien
{
    public class EscapeZone : MonoBehaviour
    {
        private Transform[] _escapePoints;
    
        private void Awake()
        {
            _escapePoints = new Transform[transform.childCount];
        
            for(var i = 0; i < _escapePoints.Length; i++)
            {
                _escapePoints[i] = transform.GetChild(i);
            }
        }

        public Transform GetRandomEscapePoint()
        {
            var randomPoint = _escapePoints[Random.Range(0, _escapePoints.Length)];
            return randomPoint;   
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var enemy = other.GetComponent<Enemy>();
        
            if (enemy != null)
            {
                enemy.EscapeToShip();
            }
        }
    }
}
