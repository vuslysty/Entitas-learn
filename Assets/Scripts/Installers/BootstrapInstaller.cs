using Game;
using Servises;
using Zenject;

namespace Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindContexts();
            BindServices();
            BindFactories();
            
            Container.BindInterfacesAndSelfTo<GameController>().AsSingle();
        }

        private void BindContexts()
        {
            var contexts = Contexts.sharedInstance;

            Container.BindInstance(contexts);

            foreach (var context in contexts.allContexts)
            {
                Container.Bind(context.GetType()).FromInstance(context).AsSingle();
            }
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<UnityTimeService>().AsSingle();
            Container.Bind<ICameraService>().To<CameraService>().AsSingle();
            Container.Bind<IInputService>().To<UnityInputService>().AsSingle();
            Container.Bind<ILogService>().To<UnityDebugLogService>().AsSingle();
        }

        private void BindFactories()
        {
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
        }
    }
}