using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DefaultNamespace;
using Dummies;
using UnityEngine;
using Zenject;
using Object = System.Object;

namespace Presenters.ProjectileFactory
{
    public class ProjectileFactory : IFactory
    {
        private readonly DiContainer _container;

        private const string ProjectilePath = "Projectiles/";
        private const string CommonProjectile = ProjectilePath + "Common";
        private const string ProjectileException = "Projectile doesn't exist!";

        private Object _projectile;
        
        public ProjectileFactory(DiContainer container)
        {
            _container = container;
            Load();
        }

        private void Load()
        {
            _projectile = Resources.Load(CommonProjectile);
        }

        public GameObject Create(ProjectileType type, Vector2 at, Transform parent = null)
        {
            switch (type)
            {
                case ProjectileType.Common:
                    return _container.InstantiatePrefab(_projectile as GameObject, at, Quaternion.identity, parent);
                default:
                    throw new ArgumentOutOfRangeException(ProjectileException);
            }
        }

        public GameObject CreateContainer(string containerName, Transform parent)
        {
            var obj = _container.Instantiate(typeof(GameObject)) as GameObject;
            obj.name = containerName;
            obj.transform.SetParent(parent);
            return obj;
        }
    }
}