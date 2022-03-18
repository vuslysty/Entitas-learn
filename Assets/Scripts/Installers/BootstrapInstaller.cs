using Game;
using Servises;
using Zenject;

namespace Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();
            Container.BindInterfacesAndSelfTo<GameController>().AsSingle();

            BindServices();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<UnityTimeService>().AsSingle();
            Container.Bind<ICameraService>().To<CameraService>().AsSingle();
            Container.Bind<IInputService>().To<UnityInputService>().AsSingle();
            Container.Bind<ILogService>().To<UnityDebugLogService>().AsSingle();
        }
    }
}