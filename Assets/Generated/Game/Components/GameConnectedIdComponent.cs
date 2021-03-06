//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ConnectedIdComponent connectedId { get { return (ConnectedIdComponent)GetComponent(GameComponentsLookup.ConnectedId); } }
    public bool hasConnectedId { get { return HasComponent(GameComponentsLookup.ConnectedId); } }

    public void AddConnectedId(float newValue) {
        var index = GameComponentsLookup.ConnectedId;
        var component = (ConnectedIdComponent)CreateComponent(index, typeof(ConnectedIdComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceConnectedId(float newValue) {
        var index = GameComponentsLookup.ConnectedId;
        var component = (ConnectedIdComponent)CreateComponent(index, typeof(ConnectedIdComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveConnectedId() {
        RemoveComponent(GameComponentsLookup.ConnectedId);
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

    static Entitas.IMatcher<GameEntity> _matcherConnectedId;

    public static Entitas.IMatcher<GameEntity> ConnectedId {
        get {
            if (_matcherConnectedId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ConnectedId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherConnectedId = matcher;
            }

            return _matcherConnectedId;
        }
    }
}
