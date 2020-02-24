using UnityEngine;
 

public abstract class Spawner : MonoBehaviour
{
    public int spawnCount;
    public PoolTags poolTag;
    public Transform objectParent;
    public Transform spawnPosition;
    protected GameObject SpawnedObject;

    protected virtual void Spawn() 
    {
        SpawnedObject = ObjectPoolManager.Instance.GetFromPool(poolTag);
        SpawnedObject.transform.parent = objectParent;
        SpawnedObject.transform.position = spawnPosition.position;
    }
}
