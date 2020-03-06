using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance;

    [Serializable]
    internal struct PoolModel
    {
        public PoolTag Tag;
        public GameObject Prefab;
        public int Size;
    }

    [SerializeField]
    private List<PoolModel> _poolModels;

    private Dictionary<PoolTag, Queue<GameObject>> _poolsDictionary;
    
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

        _poolsDictionary = new Dictionary<PoolTag, Queue<GameObject>>();
        
        InitializePoolsDictionary(_poolsDictionary);
    }

    private void InitializePoolsDictionary(Dictionary<PoolTag, Queue<GameObject>> InitializableDictionary)
    {
        foreach(PoolModel poolModel in _poolModels)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i<poolModel.Size; i++)
            {
                GameObject poolObject = Instantiate(poolModel.Prefab, transform);
                poolObject.SetActive(false);
                objectPool.Enqueue(poolObject);
            }

            InitializableDictionary.Add(poolModel.Tag, objectPool);
        }
    }
     
     
    public GameObject GetFromPool(PoolTag tag)
    {
        if(_poolsDictionary[tag] == null)
        {
            throw new NullReferenceException("This tag doesn't exist in PoolsDictionary");
        }
        GameObject objectFromPool = _poolsDictionary[tag].Dequeue();
        objectFromPool.SetActive(true);
        return objectFromPool;
    }

    public void ReturnToPool(PoolTag tag, GameObject objectToReturn)
    {
        if(_poolsDictionary[tag] == null)
        {
            throw new NullReferenceException("This tag doesn't exist in PoolsDictionary");
        }
        
        objectToReturn.SetActive(false);
        _poolsDictionary[tag].Enqueue(objectToReturn);
    }

    public int GetPoolCount(PoolTag tag){
        return _poolsDictionary[tag].Count;
    }
}
