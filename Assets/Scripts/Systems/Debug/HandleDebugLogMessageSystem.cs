using System.Collections.Generic;
using Entitas;
using Zenject;

public class HandleDebugLogMessageSystem : ReactiveSystem<DebugEntity>
{
    [Inject] private readonly ILogService _logService;

    public HandleDebugLogMessageSystem(Contexts contexts) : base(contexts.debug)
    {
    }

    protected override ICollector<DebugEntity> GetTrigger(IContext<DebugEntity> context)
    {
        return context.CreateCollector(DebugMatcher.DebugLog);
    }

    protected override bool Filter(DebugEntity entity)
    {
        return entity.hasDebugLog;
    }

    protected override void Execute(List<DebugEntity> entities)
    {
        foreach (var entity in entities)
        {
            _logService.LogMessage(entity.debugLog.message);
            entity.isDestroyed = true;
        }
    }
}