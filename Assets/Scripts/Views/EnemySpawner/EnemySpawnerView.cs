using System.Collections.Generic;
using DefaultNamespace.Dummies;
using DefaultNamespace.Presenters.Enemy.EnemyFactory;
using Presenters.EnemySpawner;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Views.EnemySpawner
{
    public class EnemySpawnerView : MonoBehaviour
    {
        private EnemySpawnerPresenter _presenter;

        [Inject]
        public void Initialize(EnemyFactory factory, SpawnerConfig spawnerConfig, List<EnemySpawnPoint> spawnPoints)
        {
            _presenter = new EnemySpawnerPresenter(factory, transform, spawnerConfig, spawnPoints);
        }

        private void Start()
        {
            _presenter.Enable();
        }
    }
}