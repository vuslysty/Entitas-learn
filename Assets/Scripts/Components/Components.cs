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

public class Duration : IComponent { public float Value; }
public class DurationMax : IComponent { public float Value; }
public class DurationElapsed : IComponent { public float Value; }

[Event(EventTarget.Self)] public class PositionComponent : IComponent { public Vector3 value; }

[Debug] public class DebugLogComponent : IComponent { public string message; }

[Game, Debug, Event(EventTarget.Self), Cleanup(CleanupMode.DestroyEntity)]
public class DestroyedComponent : IComponent { }

public class BoolComponent : IComponent { public bool value; }

[Cleanup(CleanupMode.RemoveComponent)] public class TriggerEnterComponent : IComponent { }
[Cleanup(CleanupMode.RemoveComponent)] public class TriggerStayComponent : IComponent { }
[Cleanup(CleanupMode.RemoveComponent)] public class TriggerExitComponent : IComponent { }

public class DoorButtonComponent : IComponent { public DoorButtonType value; }

public class TwoPositionsComponent : IComponent
{
    public Vector3 firstPosition;
    public Vector3 secondPosition;
}

public class DoorStateComponent : IComponent { public bool isOpen; }

public class IdComponent : IComponent { [PrimaryEntityIndex] public float value; }
public class ConnectedIdComponent : IComponent { public float value; }

public class StartMovePositionComponent : IComponent { public Vector3 value; }
public class EndMovePositionComponent : IComponent { public Vector3 value; }

public class MovingComponent : IComponent { }
[Cleanup(CleanupMode.RemoveComponent)] public class StartMovingComponent : IComponent { }

public class TargetPositionComponent : IComponent { public Vector3 value; }
public class SpeedComponent : IComponent { public float value; }