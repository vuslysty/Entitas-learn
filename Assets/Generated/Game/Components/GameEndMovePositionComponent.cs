//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public EndMovePositionComponent endMovePosition { get { return (EndMovePositionComponent)GetComponent(GameComponentsLookup.EndMovePosition); } }
    public bool hasEndMovePosition { get { return HasComponent(GameComponentsLookup.EndMovePosition); } }

    public void AddEndMovePosition(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.EndMovePosition;
        var component = (EndMovePositionComponent)CreateComponent(index, typeof(EndMovePositionComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceEndMovePosition(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.EndMovePosition;
        var component = (EndMovePositionComponent)CreateComponent(index, typeof(EndMovePositionComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveEndMovePosition() {
        RemoveComponent(GameComponentsLookup.EndMovePosition);
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

    static Entitas.IMatcher<GameEntity> _matcherEndMovePosition;

    public static Entitas.IMatcher<GameEntity> EndMovePosition {
        get {
            if (_matcherEndMovePosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EndMovePosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEndMovePosition = matcher;
            }

            return _matcherEndMovePosition;
        }
    }
}