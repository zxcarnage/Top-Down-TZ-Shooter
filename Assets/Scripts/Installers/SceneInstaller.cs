using System.Collections.Generic;
using DefaultNamespace.Dummies;
using DefaultNamespace.Models.Health;
using DefaultNamespace.Presenters.Enemy.EnemyFactory;
using Models.DetectedEnemiesModel;
using Models.MovementModel;
using Models.PlayerRotation;
using Models.WeaponModel;
using Presenters.ObjectPool.ShootObjectPool;
using Presenters.ProjectileFactory;
using UnityEngine;
using Views.Player;
using Zenject;

namespace Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private PlayerMoveView _player;
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Transform _shotsParent;
        [SerializeField] private List<EnemySpawnPoint> _enemySpawnPoints;   
        
        public override void InstallBindings()
        {
            BindMovementModel();
            BindPlayerHealthModel();
            BindEnemySpawnPoints();
            BindEnemyFactory();
            BindPlayerRotationModel();
            BindWeaponModel();
            BindProjectileFactory();
            BindShotObjectPool();
            BindDetectedEnemiesModel();
            BindMainCamera();
            InstallPlayer();
        }

        private void BindMovementModel()
        {
            Container.Bind<MovementModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindPlayerHealthModel()
        {
            Container.Bind<HealthModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindEnemySpawnPoints()
        {
            Container.Bind<List<EnemySpawnPoint>>()
                .FromInstance(_enemySpawnPoints)
                .AsSingle()
                .NonLazy();
        }

        private void BindEnemyFactory()
        {
            Container.Bind<EnemyFactory>()
                .AsSingle()
                .NonLazy();
        }

        private void BindPlayerRotationModel()
        {
            Container.Bind<PlayerRotationModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindWeaponModel()
        {
            Container.Bind<WeaponModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindProjectileFactory()
        {
            Container.Bind<ProjectileFactory>()
                .AsSingle()
                .NonLazy();
        }

        private void BindShotObjectPool()
        {
            Container.Bind<ShootObjectPool>()
                .AsSingle()
                .WithArguments(_shotsParent)
                .NonLazy();
        }

        private void BindDetectedEnemiesModel()
        {
            Container.Bind<DetectedEnemiesModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindMainCamera()
        {
            Container.Bind<Camera>()
                .FromInstance(_mainCamera)
                .AsSingle()
                .NonLazy();
        }

        private void InstallPlayer()
        {
            InstantiatePlayer();
            BindPlayerMoveView();
        }

        private void InstantiatePlayer()
        {
            _player = Container.InstantiatePrefabForComponent<PlayerMoveView>
                (_player, _playerSpawnPoint.position, Quaternion.identity, null);
        }

        private void BindPlayerMoveView()
        {
            Container.Bind<PlayerMoveView>()
                .FromInstance(_player)
                .AsSingle()
                .NonLazy();
        }
    }
}