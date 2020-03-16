using Common;
using Enums;
using Pets;
using UnityEngine;

namespace Alien
{
    public class Enemy: MortalEntity
    {
        public EscapeZone EscapeZone;

        private Pet _hostage;
        private Animator _animator;
        private Movement _movement;
        private bool _hostageIsTaken;
        private UIManager _uIManager;
        private CountManager _countManager;
        private ObjectPoolManager _objectPoolManager;
        
        private const string ROTATE = "Rotate";

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _movement = GetComponent<Movement>();
            _uIManager = UIManager.Instance;
            _countManager = CountManager.Instance;
            _objectPoolManager = ObjectPoolManager.Instance;
        }

        private void FixedUpdate()
        {
            _movement.Move();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            var pet = other.GetComponent<Pet>();
        
            if (pet != null && _hostage == null)
            {
                TakeHostage(pet);
                return;
            }

            var petSpawner = other.GetComponent<PetSpawner>();
            
            if(petSpawner != null && _countManager.GetCounter(CounterTag.Pets) == 0)
            {
                _uIManager.ShowGameOverPanel();
            }
        }

        private void TakeHostage(Pet hostage)
        {
            var isTaken = hostage.BecomeHostage(transform);
            
            if (isTaken)
            {
                _hostage = hostage;
                _movement.ChangeTarget(EscapeZone.GetRandomEscapePoint());
                _animator.SetTrigger(ROTATE);
            }            
        }
        
        public void EscapeToShip()
        {
            if (_hostage == null)
            {
                return;
            }
            
            Object.Destroy(gameObject);
        }
        
        protected override void Die()
        {
            if (_hostage != null)
            {
                _hostage.BecomeFree();
                _hostage = null;
            }

            var particle = _objectPoolManager.GetFromPool(PoolTag.EnemyLimbs);
            particle.transform.position = transform.position;
        
            _countManager.Increment(CounterTag.Kills, 1);
            _countManager.Increment(CounterTag.Scores, 1);
            _countManager.Increment(CounterTag.TotalKills, 1);
            _objectPoolManager.ReturnToPool(PoolTag.Aliens, gameObject);
        }
    }
    
}
