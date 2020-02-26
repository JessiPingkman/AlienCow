using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public int spawnCount;
    public PoolTags poolTag;
    public Transform objectParent;
    public Transform spawnPosition;
    protected GameObject spawnedObject;

    protected virtual void Spawn(int spawnCount, Vector3 spawnPosition) 
    {
        if(ObjectPoolManager.Instance.GetPoolCount(poolTag) == 0)
        {
            throw new UnityException("Pool count is 0");
        }

        spawnedObject = ObjectPoolManager.Instance.GetFromPool(poolTag);
        spawnedObject.transform.position = spawnPosition;
        
        if(objectParent != null)
        {
            spawnedObject.transform.parent = objectParent;
        }
    }
}
