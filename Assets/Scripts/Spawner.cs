using UnityEngine;
 

public abstract class Spawner : MonoBehaviour
{
    public int Count;
    public PoolTags PoolTag;
    public Transform Parent;

    public Transform SpawnPosition;

    protected GameObject SpawnedObject;

    protected virtual void Spawn() 
    {
        SpawnedObject = ObjectPoolManager.Instance.GetFromPool(PoolTag);
        SpawnedObject.transform.parent = Parent;
        SpawnedObject.transform.position = SpawnPosition.position;
    }
}
