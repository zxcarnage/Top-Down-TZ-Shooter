using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using Presenters.ProjectileFactory;
using UnityEngine;
using Utils;

namespace Presenters.ObjectPool.ShootObjectPool
{
    public class ShootObjectPool
    {
        private readonly Dictionary<ProjectileType, List<GameObject>> _projectileDictionary;
        private readonly IFactory _factory;
        private readonly Transform _parentTransform;
        
        private const int SpawnAmount = 500;

        public ShootObjectPool(ProjectileFactory.ProjectileFactory factory, Transform parenTransform)
        {
            InvariantChecker.CheckObjectInvariant<ShootObjectPool>(factory, parenTransform);
            _projectileDictionary = new();
            _factory = factory;
            _parentTransform = parenTransform;
            Initialize();
        }

        private void Initialize()
        {
            var values = Enum.GetValues(typeof(ProjectileType)).Cast<ProjectileType>();
            foreach (var value in values)
            {
                var newObjectsContainer = _factory.CreateContainer(value.ToString(),_parentTransform).transform;
                _projectileDictionary[value] = new List<GameObject>();
                for (int i = 0; i < SpawnAmount; i++)
                {
                    var instantiated = _factory.Create(value, Vector2.zero, newObjectsContainer);
                    instantiated.SetActive(false);
                    _projectileDictionary[value].Add(instantiated);
                }
            }
        }

        public GameObject Get(ProjectileType type)
        {
            return _projectileDictionary[type].FirstOrDefault(x => x.activeSelf == false);
        }
    }
}