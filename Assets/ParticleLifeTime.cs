using UnityEngine;

public class ParticleLifeTime : MonoBehaviour
{
    private ParticleSystem particle;
    
    void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if(particle != null)
        {
            if(!particle.IsAlive())
            {
                ObjectPoolManager.Instance.ReturnToPool(PoolTags.EnemyLimbs, gameObject);
            }
        }
    }
}
