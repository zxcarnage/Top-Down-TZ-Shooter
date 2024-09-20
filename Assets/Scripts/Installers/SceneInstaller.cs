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
        
        public override void InstallBindings()
        {
            BindMainCamera();
            InstallPlayer();
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