//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ViewControllerComponent viewController { get { return (ViewControllerComponent)GetComponent(GameComponentsLookup.ViewController); } }
    public bool hasViewController { get { return HasComponent(GameComponentsLookup.ViewController); } }

    public void AddViewController(IViewController newValue) {
        var index = GameComponentsLookup.ViewController;
        var component = (ViewControllerComponent)CreateComponent(index, typeof(ViewControllerComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceViewController(IViewController newValue) {
        var index = GameComponentsLookup.ViewController;
        var component = (ViewControllerComponent)CreateComponent(index, typeof(ViewControllerComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveViewController() {
        RemoveComponent(GameComponentsLookup.ViewController);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherViewController;

    public static Entitas.IMatcher<GameEntity> ViewController {
        get {
            if (_matcherViewController == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ViewController);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherViewController = matcher;
            }

            return _matcherViewController;
        }
    }
}
