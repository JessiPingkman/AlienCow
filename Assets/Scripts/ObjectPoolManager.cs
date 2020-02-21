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

    public static Dictionary<string, Queue<GameObject>> PoolsDictionary;

    private void InitializePoolsDictionary(Dictionary<string, Queue<GameObject>> InitializableDictionary)
    {
        foreach(PoolModel poolModel in poolModels)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0;i<poolModel.size;i++)
            {
                objectPool.Enqueue(Instantiate(poolModel.prefab, poolModel.parent));
            }

            InitializableDictionary.Add(poolModel.tag.ToString(), objectPool);
        }

    }

    public void Awake()
    {
        InitializePoolsDictionary(PoolsDictionary);
    }
}
