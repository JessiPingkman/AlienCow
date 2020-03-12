using System;
using Enums;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Common
{
    [Serializable]
    public struct TextCounter
    {
        public CounterTag Tag;
        public Text Text;
    }
}
