using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public void ReturnToPool()
    {
        ObjectPoolManager.Instance.ReturnToPool(PoolTags.ExplosionFx, gameObject);
    }
}
