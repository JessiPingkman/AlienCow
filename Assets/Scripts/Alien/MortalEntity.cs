using UnityEngine;

namespace Alien
{
    public abstract class MortalEntity : MonoBehaviour
    {
        public float HealthPoint = 10;

        public void CheckDeath()
        {
            if (HealthPoint <= 0)
            {
                Die();
            }
        }

        protected abstract void Die();
    }
}
