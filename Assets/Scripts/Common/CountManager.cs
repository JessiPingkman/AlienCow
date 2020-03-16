using System.Collections.Generic;
using UnityEngine;
using System;
using Enums;


public class CountManager : MonoBehaviour
{
    public static CountManager Instance;

    [SerializeField]
    private List<Counter> _counters;

    private Dictionary<CounterTag, Counter> _countersDictionary;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        _countersDictionary = new Dictionary<CounterTag, Counter>();

        foreach(Counter counter in _counters)
        {
            _countersDictionary.Add(counter.CounterTag, counter);
        }

        UIManager.Instance.UpdateCounterText(CounterTag.Pets, _countersDictionary[CounterTag.Pets].Counter);
    }
    
    
    public void Increment(CounterTag tag, int value)
    {
        if(_countersDictionary.ContainsKey(tag) == false)
        {
            return;
        }

        var incrementedValue = _countersDictionary[tag].Counter += value;
        UIManager.Instance.UpdateCounterText(tag, incrementedValue);
    }

    public void Decrement(CounterTag tag, int value)
    {
        if(_countersDictionary.ContainsKey(tag) == false)
        {
            return;
        }
        var decrementedValue = _countersDictionary[tag].Counter -= value;
        UIManager.Instance.UpdateCounterText(tag, decrementedValue);
    }

    public int GetCounter(CounterTag tag)
    {
        if(_countersDictionary.ContainsKey(tag) == false)
        {
            return 0;
        }
        
        return _countersDictionary[tag].Counter;
    }
}
