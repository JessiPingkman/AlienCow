using Common;
using Enums;
using UnityEngine;

namespace Pets
{
    public class Pet : MonoBehaviour
    {
        public float Speed = 1;
        
        [HideInInspector]
        public bool IsFree= true;
        [HideInInspector]
        public bool IsNotInPetZone;
    
        public string[] Sounds;
    
        private Movement _movement;
        private Vector3 _targetPosition;

        private void Awake()
        {
            IsFree= true;
            _movement = GetComponent<Movement>();
            _targetPosition = _movement.Target.position;
        }

        private void FixedUpdate()
        {
            if (IsFree && IsNotInPetZone)
            {
                _movement.Move(Speed);

                if (transform.position == _targetPosition)
                {
                    IsNotInPetZone = false;
                }
            }
        }

        public void BecomeFree()
        {
            transform.SetParent(null);
            IsFree = true;
            AudioManager.PlaySound(Sounds[Random.Range(0,Sounds.Length)]);
        }
    
        public void BecomeHostage(Transform enemy)
        {
            transform.SetParent(enemy);
            transform.localPosition = Vector2.zero;
            IsFree = false;
            IsNotInPetZone = true;
        }
    }
}
