using Models.MovementModel;
using UnityEngine;
using Zenject;

namespace Installers.GameObjectInstallers
{
    public class PlayerInstaller : MonoInstaller<PlayerInstaller>
    {
        [SerializeField] private Animator _playerAnimator;
        [SerializeField] private Transform _playerModelTransform;
        
        public override void InstallBindings()
        {
            BindPlayerModelTransform();
            BindMovementModel();
            BindPlayerAnimator();
        }

        private void BindPlayerModelTransform()
        {
            Container.Bind<Transform>()
                .FromInstance(_playerModelTransform)
                .AsSingle()
                .NonLazy();
        }

        private void BindMovementModel()
        {
            Container.Bind<MovementModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindPlayerAnimator()
        {
            Container.Bind<Animator>()
                .FromInstance(_playerAnimator)
                .AsSingle()
                .NonLazy();
        }
    }
}