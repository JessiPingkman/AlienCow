using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using UI;
using UnityEngine;

namespace Common
{
    public class CountManager : MonoBehaviour
    {
        public static CountManager Instance;

        private Dictionary<CounterTag, int> _countersDictionary;

        private void Awake()
        {
            InitializeInstance();
            InitializeDictionary();
        }

        private void InitializeInstance()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
        
        public void Increment(CounterTag counterTag, int value = 1)
        {
            ChangeCounterValue(counterTag, value);
        }

        public void Decrement(CounterTag counterTag, int value = 1)
        {
            ChangeCounterValue(counterTag, value * -1);
        }

        private void ChangeCounterValue(CounterTag counterTag, int value)
        {
            if(_countersDictionary.ContainsKey(counterTag) == false)
            {
                return;
            }
        
            int changedValue = _countersDictionary[counterTag] += value;
            UiManager.Instance.UpdateCounterText(counterTag, changedValue);
        }

        public int GetCapacity(CounterTag counterTag)
        {
            return _countersDictionary.ContainsKey(counterTag) == false ? 0 : _countersDictionary[counterTag];
        }

        private void InitializeDictionary()
        {
            _countersDictionary = new Dictionary<CounterTag, int>();
            
            var counterTags = Enum.GetValues(typeof(CounterTag)).Cast<CounterTag>();
            foreach (var counter in counterTags)
            {
                _countersDictionary.Add(counter, 0);
            }
        }
    }
}
