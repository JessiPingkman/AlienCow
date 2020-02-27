using System.Collections.Generic;
using UnityEngine;
using System;


public class CountManager : MonoBehaviour
{
    public static CountManager Instance;

    [SerializeField]
    private List<Counter> counters;

    private Dictionary<CounterTags, Counter> countersDictionary;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        countersDictionary = new Dictionary<CounterTags, Counter>();

        foreach(Counter counter in counters)
        {
            countersDictionary.Add(counter.counterTag, counter);
        }

        UIManager.Instance.UpdateCounterText(CounterTags.pets, countersDictionary[CounterTags.pets].counter);
    }
    
    
    public void Increment(CounterTags tag, int value)
    {
        if(countersDictionary.ContainsKey(tag) == false)
        {
            return;
        }

        var incrementedValue = countersDictionary[tag].counter += value;
        UIManager.Instance.UpdateCounterText(tag, incrementedValue);
    }

    public void Decrement(CounterTags tag, int value)
    {
        if(countersDictionary.ContainsKey(tag) == false)
        {
            return;
        }
        var decrementedValue = countersDictionary[tag].counter -= value;
        UIManager.Instance.UpdateCounterText(tag, decrementedValue);
    }

    public int GetCounter(CounterTags tag)
    {
        return countersDictionary[tag].counter;
    }
}
