using Enums;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public int SpawnCount;
    public PoolTag PoolTag;
    public Transform ObjectParent;
    public Transform SpawnPosition;
    protected GameObject _spawnedObject;

    public virtual void Spawn(Vector3 spawnPosition) 
    {
        if(ObjectPoolManager.Instance.GetPoolCount(PoolTag) == 0)
        {
            throw new UnityException("Pool count is 0");
        }

        _spawnedObject = ObjectPoolManager.Instance.GetFromPool(PoolTag);
        _spawnedObject.transform.position = spawnPosition;

        if(ObjectParent != null)
        {
            _spawnedObject.transform.parent = ObjectParent;
        }
    }
}
