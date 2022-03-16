using UnityEngine;

public class EntityBehaviour : MonoBehaviour
{
    public UnityViewController ViewController;

    public UnityViewController Controller => ViewController;

    public GameContext Game => Contexts.sharedInstance.game;
    public GameEntity Entity => Controller.Entity;
    
    private void Awake() => OnAwake();
    private void Start() => OnStart();
    private void OnDestroy() => OnDestroying();
    private void OnEnable() => OnEnabled();
    private void OnDisable() => OnDisabled();
    
    protected virtual void OnAwake()
    {
    }

    protected virtual void OnStart()
    {
    }

    protected virtual void OnEnabled()
    {
    }

    protected virtual void OnDisabled()
    {
    }

    protected virtual void OnDestroying()
    {
    }
}