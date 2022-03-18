using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using View;

[Unique, Input] public class LeftMouse : IComponent { }
[Unique, Input] public class RightMouse : IComponent { }
[Unique, Input] public class Keyboard : IComponent { }
  
[Input] public class MouseDown : IComponent { }
[Input] public class MouseWorldPosition : IComponent { public Vector2 Value; }
[Input] public class MouseScreenPosition : IComponent { public Vector2 Value; }
[Input] public class MouseUp : IComponent { }
[Input] public class Mouse : IComponent { }
[Input] public class Jump : IComponent { }
[Input] public class Horizontal : IComponent { public float Value; }
[Input] public class Vertical : IComponent { public float Value; }

public class ViewComponent : IComponent { public GameObject Value; }
public class ViewControllerComponent : IComponent { public IViewController Value; }
public class NavMeshAgentComponent : IComponent { public INavMeshAgent Value; }
public class PlayerAnimatorComponent : IComponent { public PlayerAnimator Value; }

[Cleanup(CleanupMode.RemoveComponent)] public class TriggerEnterComponent : IComponent { }
[Cleanup(CleanupMode.RemoveComponent)] public class TriggerStayComponent : IComponent { }
[Cleanup(CleanupMode.RemoveComponent)] public class TriggerExitComponent : IComponent { }

[Debug] public class DebugLogComponent : IComponent { public string message; }

[Game, Debug, Event(EventTarget.Self), Cleanup(CleanupMode.DestroyEntity)]
public class DestroyedComponent : IComponent { }

public class DoorButtonComponent : IComponent { public DoorButtonType value; }
public class DoorStateComponent : IComponent { public bool isOpen; }

public class IdComponent : IComponent { [PrimaryEntityIndex] public float value; }
public class ConnectedIdComponent : IComponent { public float value; }

[Event(EventTarget.Self)] public class PositionComponent : IComponent { public Vector3 value; }
public class TargetPositionComponent : IComponent { public Vector3 value; }

public class TwoPositionsComponent : IComponent
{
    public Vector3 firstPosition;
    public Vector3 secondPosition;
}

public class SpeedComponent : IComponent { public float value; }