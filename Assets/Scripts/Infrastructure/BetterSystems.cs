using System.Collections.Generic;
using Entitas;
using Game;

namespace Systems
{
    public class BetterSystems : Entitas.Systems
    {
        private readonly ISystemFactory _systemFactory;
        
        protected readonly List<IExecuteSystem> simpleExecuteSystems = new List<IExecuteSystem>();
        protected readonly List<IFixedExecuteSystem> fixedExecuteSystems = new List<IFixedExecuteSystem>();
        protected readonly List<ILateExecuteSystem> lateExecuteSystems = new List<ILateExecuteSystem>();

        public BetterSystems(ISystemFactory systemFactory)
        {
            _systemFactory = systemFactory;
        }
        
        public override void Initialize()
        {
            base.Initialize();
            
            foreach (IExecuteSystem system in _executeSystems)
            {
                switch (system)
                {
                    case IFixedExecuteSystem fixedExecuteSystem:
                        fixedExecuteSystems.Add(fixedExecuteSystem);
                        break;
                    case ILateExecuteSystem lateExecuteSystem:
                        lateExecuteSystems.Add(lateExecuteSystem);
                        break;
                    default:
                        simpleExecuteSystems.Add(system);
                        break;
                }
            }
        }

        public override void Execute()
        {
            for (int index = 0; index < simpleExecuteSystems.Count; ++index)
            {
                simpleExecuteSystems[index].Execute();
            }
        }

        public void FixedExecute()
        {
            for (int index = 0; index < fixedExecuteSystems.Count; ++index)
            {
                fixedExecuteSystems[index].Execute();
            }
        }
        
        public void LateExecute()
        {
            for (int index = 0; index < lateExecuteSystems.Count; ++index)
            {
                lateExecuteSystems[index].Execute();
            }
        }
        
        public void Add<T>() where T : ISystem
        {
            Add(_systemFactory.CreateSystem<T>());
        }
    }
    
    public interface IFixedExecuteSystem : IExecuteSystem { }
    public interface ILateExecuteSystem : IExecuteSystem { }
}