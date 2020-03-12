using Enums;
using Pets;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Alien
{
    public class EscapeZone : MonoBehaviour
    {
        private Transform[] _escapePoints;
    
        private void Start()
        {
            _escapePoints = new Transform[transform.childCount];
        
            for (int i = 0; i < transform.childCount; i++)
            {
                _escapePoints[i] = transform.GetChild(i);
            }
        }

        public Transform GetRandomEscapePoint()
        {
            int pointsCount = _escapePoints.Length;
            return _escapePoints[Random.Range(0, pointsCount)];
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var enemy = other.GetComponent<Enemy>();
        
            if (enemy != null && enemy.HostageIsTaken)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
