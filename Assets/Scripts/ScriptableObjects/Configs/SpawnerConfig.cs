using System.Collections.Generic;
using DefaultNamespace;
using Structs;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Spawner config", menuName = "Configs/Spawner", order = 0)]
    public class SpawnerConfig : ScriptableObject
    {
        [SerializeField] private List<SerializableKeyValuePair<EnemyType, float>> _typeToDelay;

        public List<SerializableKeyValuePair<EnemyType, float>> TypeToDelay => _typeToDelay;
    }
}