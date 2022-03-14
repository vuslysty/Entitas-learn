using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self), Cleanup(CleanupMode.DestroyEntity)]
public class DestroyedComponent : IComponent
{
}