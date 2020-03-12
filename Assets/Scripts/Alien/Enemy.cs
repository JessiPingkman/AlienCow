using Common;
using Enums;
using Pets;
using UnityEngine;

namespace Alien
{
    public class Enemy: MortalEntity
    {
        [HideInInspector]
        public bool HostageIsTaken;
        
        public EscapeZone EscapeZone;
        public float MoveSpeed;

        private Pet _hostage;
        private Movement _movement;
        private Animator _animator;
        private const string ROTATE = "Rotate";

        private void Start()
        {
            _movement = GetComponent<Movement>();
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            _movement.Move(MoveSpeed);
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            var pet = other.GetComponent<Pet>();
        
            if (pet != null && pet.IsFree && HostageIsTaken == false)
            {
                TakeHostage(pet);
                return;
            }

            if(other.gameObject.CompareTag(GameObjectTag.PetSpawner.ToString()) && CountManager.Instance.GetCounter(CounterTag.Pets) == 0)
            {
                UIManager.Instance.ShowGameOverPanel();
            }
        }

        private void TakeHostage(Pet hostage)
        {
            _hostage = hostage;
            _hostage.BecomeHostage(transform);
            _movement.ChangeTarget(EscapeZone.GetRandomEscapePoint());
            _animator.SetTrigger(ROTATE);
            HostageIsTaken = true;
        }
    
        protected override void Die()
        {
            if (HostageIsTaken)
            {
                _hostage.BecomeFree();
                HostageIsTaken = false;
                _hostage = null;
            }

            GameObject particle = ObjectPoolManager.Instance.GetFromPool(PoolTag.EnemyLimbs);
            particle.transform.position = transform.position;
        
            CountManager.Instance.Increment(CounterTag.Kills, 1);
            CountManager.Instance.Increment(CounterTag.Scores, 1);
            CountManager.Instance.Increment(CounterTag.TotalKills, 1);
            ObjectPoolManager.Instance.ReturnToPool(PoolTag.Aliens, gameObject);
        }
    }
}
