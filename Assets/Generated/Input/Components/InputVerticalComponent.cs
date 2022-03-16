//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public Vertical vertical { get { return (Vertical)GetComponent(InputComponentsLookup.Vertical); } }
    public bool hasVertical { get { return HasComponent(InputComponentsLookup.Vertical); } }

    public void AddVertical(float newValue) {
        var index = InputComponentsLookup.Vertical;
        var component = (Vertical)CreateComponent(index, typeof(Vertical));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceVertical(float newValue) {
        var index = InputComponentsLookup.Vertical;
        var component = (Vertical)CreateComponent(index, typeof(Vertical));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveVertical() {
        RemoveComponent(InputComponentsLookup.Vertical);
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

    static Entitas.IMatcher<InputEntity> _matcherVertical;

    public static Entitas.IMatcher<InputEntity> Vertical {
        get {
            if (_matcherVertical == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Vertical);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherVertical = matcher;
            }

            return _matcherVertical;
        }
    }
}
