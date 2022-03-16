using Assets.Code;
using Servises;

public class ServiceRegistrationSystems : Feature
{
    public ServiceRegistrationSystems(Contexts contexts, Services services)
        : base(nameof(ServiceRegistrationSystems))
    {
        GameContext game = contexts.game;
        InputContext input = contexts.input;

        Add(new RegisterServiceSystem<ILogService>(services.Logger, game.ReplaceLogger));
        Add(new RegisterServiceSystem<IInputService>(services.InputService, input.ReplaceInput));
        Add(new RegisterServiceSystem<ICameraService>(services.CameraService, game.ReplaceCamera));
    }
}