using Enums;
using UnityEngine;

public class ParticleLifeTime : MonoBehaviour
{
    private ParticleSystem _particle;
    
    void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if(_particle != null)
        {
            if(!_particle.IsAlive())
            {
                ObjectPoolManager.Instance.ReturnToPool(PoolTag.EnemyLimbs, gameObject);
            }
        }
    }
}
