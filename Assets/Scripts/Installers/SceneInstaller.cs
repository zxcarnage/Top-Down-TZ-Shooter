using Models.DetectedEnemiesModel;
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
        
        public override void InstallBindings()
        {
            BindPlayerRotationModel();
            BindWeaponModel();
            BindProjectileFactory();
            BindShotObjectPool();
            BindDetectedEnemiesModel();
            BindMainCamera();
            InstallPlayer();
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