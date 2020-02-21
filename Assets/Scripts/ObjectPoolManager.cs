using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    [Serializable]
    public class PoolModel
    {
        public PoolTags tag;
        public GameObject prefab;
        public int size;
        public Transform parent;
    }

    public List<PoolModel> poolModels;

    public static Dictionary<PoolTags, Queue<GameObject>> PoolsDictionary;

    private void InitializePoolsDictionary(Dictionary<PoolTags, Queue<GameObject>> InitializableDictionary)
    {
        foreach(PoolModel poolModel in poolModels)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0;i<poolModel.size;i++)
            {
                objectPool.Enqueue(Instantiate(poolModel.prefab, poolModel.parent));
            }

            InitializableDictionary.Add(poolModel.tag, objectPool);
        }
    }

    public GameObject getFromPool(PoolTags tag){
        if(PoolsDictionary[tag] == null) throw new NullReferenceException("This tag doesn't exist in PoolsDictionary");
        return PoolsDictionary[tag].Dequeue();
    }

    public void ReturnToPool(PoolTags tag, GameObject obj){
        PoolsDictionary[tag].Enqueue(obj);
    }

    void Awake()
    {
        InitializePoolsDictionary(PoolsDictionary);
    }
}
