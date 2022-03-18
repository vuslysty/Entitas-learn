using UnityEngine;
using Zenject;

public class EntityBehaviour : MonoBehaviour
{
    private Contexts contexts;
    
    public UnityViewController ViewController;

    public UnityViewController Controller => ViewController;

    public GameContext Game => contexts.game;
    public GameEntity Entity => Controller.Entity;

    [Inject]
    public void Construct(Contexts contexts)
    {
        this.contexts = contexts;
    }
    
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