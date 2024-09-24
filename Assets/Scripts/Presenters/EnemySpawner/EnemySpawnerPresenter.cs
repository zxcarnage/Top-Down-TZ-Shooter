using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DefaultNamespace;
using DefaultNamespace.Dummies;
using DefaultNamespace.Presenters.Enemy.EnemyFactory;
using Presenters.ObjectPool.ShootObjectPool;
using ScriptableObjects;
using Structs;
using UnityEngine;
using Utils;

namespace Presenters.EnemySpawner
{
    public class EnemySpawnerPresenter
    {
        private readonly EnemyObjectPool _enemyPool;
        private readonly SpawnerConfig _spawnerConfig;
        private readonly List<EnemySpawnPoint> _spawnPoints;
        
        public EnemySpawnerPresenter(EnemyFactory enemyFactory, Transform parentTransform, SpawnerConfig spawnerConfig, List<EnemySpawnPoint> spawnPoints)
        {
            InvariantChecker.CheckObjectInvariant<EnemySpawnerPresenter>(spawnerConfig, spawnPoints);
            _enemyPool = new EnemyObjectPool(enemyFactory, parentTransform);
            _spawnerConfig = spawnerConfig;
            _spawnPoints = spawnPoints;
        }

        public void Enable()
        {
            foreach (var keyValuePair in _spawnerConfig.TypeToDelay)
            {
                SpawnEnemy(keyValuePair).Forget();
            }
        }

        private async UniTask SpawnEnemy(SerializableKeyValuePair<EnemyType, float> keyValuePair)
        {
            while (true)
            {
                Debug.Log("In spawn enemy");
                await UniTask.Delay((int) (keyValuePair.Value * 1000));
                Spawn(keyValuePair, out GameObject currentEnemy);
                PositionEnemy(currentEnemy);
            }
        }

        private void PositionEnemy(GameObject currentEnemy)
        {
            currentEnemy.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Count - 1)].Position;
        }

        private void Spawn(SerializableKeyValuePair<EnemyType, float> keyValuePair, out GameObject currentEnemy)
        {
            currentEnemy = _enemyPool.Get(keyValuePair.Key);
            if (currentEnemy != null)
                currentEnemy.SetActive(true);
        }
    }
}