using Entitas;
using Entitas.CodeGeneration.Attributes;
using Servises;
using UnityEngine;

[Unique] public class Logger : IComponent, IService { public ILogService Value; }
[Unique] public class Camera : IComponent, IService { public ICameraService Value; }
[Unique, Input] public class Input : IComponent, IService { public IInputService Value; }

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