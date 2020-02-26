using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance;

    [Serializable]
    internal struct PoolModel
    {
        public PoolTags tag;
        public GameObject prefab;
        public int size;
    }


    [SerializeField]
    private List<PoolModel> poolModels;

    private Dictionary<PoolTags, Queue<GameObject>> poolsDictionary;
    
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

        poolsDictionary = new Dictionary<PoolTags, Queue<GameObject>>();
        
        InitializePoolsDictionary(poolsDictionary);
    }

    private void InitializePoolsDictionary(Dictionary<PoolTags, Queue<GameObject>> InitializableDictionary)
    {
        foreach(PoolModel poolModel in poolModels)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i<poolModel.size; i++)
            {
                GameObject poolObject = Instantiate(poolModel.prefab, transform);
                poolObject.SetActive(false);
                objectPool.Enqueue(poolObject);
            }

            InitializableDictionary.Add(poolModel.tag, objectPool);
        }
    }

    public GameObject GetFromPool(PoolTags tag)
    {
        if(poolsDictionary[tag] == null)
        {
            throw new NullReferenceException("This tag doesn't exist in PoolsDictionary");
        }
        GameObject objectFromPool = poolsDictionary[tag].Dequeue();
        objectFromPool.SetActive(true);
        return objectFromPool;
    }

    public void ReturnToPool(PoolTags tag, GameObject objectToReturn)
    {
        if(poolsDictionary[tag] == null)
        {
            throw new NullReferenceException("This tag doesn't exist in PoolsDictionary");
        }
        
        objectToReturn.SetActive(false);
        poolsDictionary[tag].Enqueue(objectToReturn);
    }

    public int GetPoolCount(PoolTags tag){
        return poolsDictionary[tag].Count;
    }
}
