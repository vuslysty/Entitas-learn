using Entitas;

public interface IViewController
{
    IViewController InitializeView(GameContext gameContext, IEntity entity);
    void Destroy();
    GameEntity Entity { get; }
}