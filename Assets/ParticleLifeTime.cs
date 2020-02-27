using UnityEngine;

public class ParticleLifeTime : MonoBehaviour
{
    private ParticleSystem particle;
    
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if(particle)
        {
            if(!particle.IsAlive())
            {
                ObjectPoolManager.Instance.ReturnToPool(PoolTags.EnemyLimbs, gameObject);
            }
        }
    }
}
