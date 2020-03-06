using Enums;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public void ReturnToPool()
    {
        ObjectPoolManager.Instance.ReturnToPool(PoolTag.ExplosionFx, gameObject);
    }
}
