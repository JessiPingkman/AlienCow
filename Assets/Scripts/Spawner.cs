using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public int spawnCount;
    public PoolTags poolTag;
    public Transform objectParent;
    public Transform spawnPosition;
    protected GameObject spawnedObject;

    protected virtual void Spawn() 
    {
        spawnedObject = ObjectPoolManager.Instance.GetFromPool(poolTag);
        spawnedObject.transform.parent = objectParent;
        spawnedObject.transform.position = spawnPosition.position;
    }
}
