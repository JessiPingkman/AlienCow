using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance;

    [Serializable]
    public class PoolModel
    {
        public PoolTags tag;
        public GameObject prefab;
        public int size;
        public Transform parent;
    }

    public List<PoolModel> poolModels;

    private Dictionary<PoolTags, Queue<GameObject>> PoolsDictionary;



    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        InitializePoolsDictionary(PoolsDictionary);
    }

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

    public GameObject GetFromPool(PoolTags tag)
    {
        if(PoolsDictionary[tag] == null)
        {
            throw new NullReferenceException("This tag doesn't exist in PoolsDictionary");
        }
        
        return PoolsDictionary[tag].Dequeue();
    }

    public void ReturnToPool(PoolTags tag, GameObject obj)
    {
        if(PoolsDictionary[tag] == null)
        {
            throw new NullReferenceException("This tag doesn't exist in PoolsDictionary");
        }

        PoolsDictionary[tag].Enqueue(obj);
    }
}
