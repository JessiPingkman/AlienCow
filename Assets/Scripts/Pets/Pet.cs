using Common;
using Enums;
using UnityEngine;

namespace Pets
{
    public class Pet : MonoBehaviour
    {
        private bool _isFree = true;
        private Movement _movement;
        private CountManager _countManager;

        private void Awake()
        {
            _movement = GetComponent<Movement>();
            _countManager = CountManager.Instance;
        }

        private void FixedUpdate()
        {
            ReturnToPetZone();
        }
        
        public void BecomeFree()
        {
            transform.SetParent(null);
            _countManager.Increment(CounterTag.Pets, 1);
            _isFree = true;
        }
    
        public bool BecomeHostage(Transform enemy)
        {
            if (_isFree == false)
            {
                return false;
            }
            
            _isFree = false;
            transform.SetParent(enemy);
            transform.localPosition = Vector2.zero;
            _countManager.Decrement(CounterTag.Pets, 1);

            return true;
        }
        
        private void ReturnToPetZone()
        {
            if (_isFree && transform.position != _movement.GetTargetPosition()) 
            { 
                _movement.Move();
            } 
        }
    }
}
