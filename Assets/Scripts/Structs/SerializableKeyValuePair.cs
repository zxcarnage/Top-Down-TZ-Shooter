using System;

namespace Structs
{
    [Serializable]
    public struct SerializableKeyValuePair <TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
    }
}