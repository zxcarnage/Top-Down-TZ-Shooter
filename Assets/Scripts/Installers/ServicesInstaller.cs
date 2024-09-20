using Zenject;

namespace Installers
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputService();
        }

        private void BindInputService()
        {
            Container.Bind<InputService>()
                .AsSingle()
                .NonLazy();
        }
    }
}