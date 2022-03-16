//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity leftMouseEntity { get { return GetGroup(InputMatcher.LeftMouse).GetSingleEntity(); } }

    public bool isLeftMouse {
        get { return leftMouseEntity != null; }
        set {
            var entity = leftMouseEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isLeftMouse = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly LeftMouse leftMouseComponent = new LeftMouse();

    public bool isLeftMouse {
        get { return HasComponent(InputComponentsLookup.LeftMouse); }
        set {
            if (value != isLeftMouse) {
                var index = InputComponentsLookup.LeftMouse;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : leftMouseComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherLeftMouse;

    public static Entitas.IMatcher<InputEntity> LeftMouse {
        get {
            if (_matcherLeftMouse == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.LeftMouse);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherLeftMouse = matcher;
            }

            return _matcherLeftMouse;
        }
    }
}
