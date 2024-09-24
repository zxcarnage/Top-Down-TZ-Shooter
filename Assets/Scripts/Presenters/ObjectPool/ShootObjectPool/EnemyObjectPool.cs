using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using DefaultNamespace.Presenters.Enemy.EnemyFactory;
using Presenters.ProjectileFactory;
using UnityEngine;
using Utils;

namespace Presenters.ObjectPool.ShootObjectPool
{
    public class EnemyObjectPool
    {
        private readonly Dictionary<EnemyType, List<GameObject>> _enemyDictionary;
        private readonly EnemyFactory _factory;
        private readonly Transform _parentTransform;
        
        private const int SpawnAmount = 100;

        public EnemyObjectPool(EnemyFactory factory, Transform parenTransform)
        {
            InvariantChecker.CheckObjectInvariant<EnemyObjectPool>(factory, parenTransform);
            _enemyDictionary = new();
            _factory = factory;
            _parentTransform = parenTransform;
            Initialize();
        }

        private void Initialize()
        {
            var values = Enum.GetValues(typeof(EnemyType)).Cast<EnemyType>();
            foreach (var value in values)
            {
                var newObjectsContainer = _factory.CreateContainer(value.ToString(),_parentTransform).transform;
                _enemyDictionary[value] = new List<GameObject>();
                for (int i = 0; i < SpawnAmount; i++)
                {
                    var instantiated = _factory.Create(value, Vector2.zero, newObjectsContainer);
                    instantiated.SetActive(false);
                    _enemyDictionary[value].Add(instantiated);
                }
            }
        }

        public GameObject Get(EnemyType type)
        {
            return _enemyDictionary[type].FirstOrDefault(x => x.activeSelf == false);
        }
    }
}