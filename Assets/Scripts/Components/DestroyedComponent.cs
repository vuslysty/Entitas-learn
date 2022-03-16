using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Debug, Event(EventTarget.Self), Cleanup(CleanupMode.DestroyEntity)]
public class DestroyedComponent : IComponent
{
}