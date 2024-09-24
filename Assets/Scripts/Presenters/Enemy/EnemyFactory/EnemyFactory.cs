using System;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace DefaultNamespace.Presenters.Enemy.EnemyFactory
{
    public class EnemyFactory
    {
        private readonly DiContainer _container;
        
        private const string EnemyPath = "Enemies/";
        private const string CommonEnemy = EnemyPath + "Common";
        private const string ProjectileException = "Enemy doesn't exist!";

        private Object _commonEnemy;

        public EnemyFactory(DiContainer container)
        {
            _container = container;
            Load();
        }

        private void Load()
        {
            _commonEnemy = Resources.Load(CommonEnemy);
        }
        
        public GameObject Create(EnemyType type, Vector2 at, Transform parent = null)
        {
            switch (type)
            {
                case EnemyType.Common:
                    return _container.InstantiatePrefab(_commonEnemy as GameObject, at, Quaternion.identity, parent);
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