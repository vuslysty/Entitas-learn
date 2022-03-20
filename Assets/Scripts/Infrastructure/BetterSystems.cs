using System;
using System.Collections.Generic;
using System.Reflection;
using Entitas;
using Factories;

namespace Infrastructure
{
    public class BetterSystems : Entitas.Systems
    {
        private readonly ISystemFactory _systemFactory;

        private readonly List<IExecuteSystem> _simpleExecuteSystems = new List<IExecuteSystem>();
        private readonly List<IFixedExecuteSystem> _fixedExecuteSystems = new List<IFixedExecuteSystem>();
        private readonly List<ILateExecuteSystem> _lateExecuteSystems = new List<ILateExecuteSystem>();

        public BetterSystems(ISystemFactory systemFactory)
        {
            _systemFactory = systemFactory;
        }
        
        public override void Initialize()
        {
            base.Initialize();

            GroupExecuteSystemsByTypes(_executeSystems);
        }

        public override void Execute()
        {
            for (int index = 0; index < _simpleExecuteSystems.Count; ++index)
            {
                _simpleExecuteSystems[index].Execute();
            }
        }

        public void FixedExecute()
        {
            for (int index = 0; index < _fixedExecuteSystems.Count; ++index)
            {
                _fixedExecuteSystems[index].Execute();
            }
        }

        public void LateExecute()
        {
            for (int index = 0; index < _lateExecuteSystems.Count; ++index)
            {
                _lateExecuteSystems[index].Execute();
            }
        }

        public void Add<T>() where T : ISystem
        {
            Add(_systemFactory.CreateSystem<T>());
        }

        private void GroupExecuteSystemsByTypes(List<IExecuteSystem> executeSystems)
        {
            foreach (IExecuteSystem system in executeSystems)
            {
                switch (system)
                {
                    case IFixedExecuteSystem fixedExecuteSystem:
                        _fixedExecuteSystems.Add(fixedExecuteSystem);
                        break;
                    case ILateExecuteSystem lateExecuteSystem:
                        _lateExecuteSystems.Add(lateExecuteSystem);
                        break;
                    case Feature feature:
                        GroupExecuteSystemsByTypes(GetExecuteSystems(feature));
                        break;
                    default:
                        _simpleExecuteSystems.Add(system);
                        break;
                }
            }
        }

        private static List<IExecuteSystem> GetExecuteSystems(Entitas.Systems systems)
        {
            return GetInstanceField(typeof(Entitas.Systems), systems, "_executeSystems") as List<IExecuteSystem>;
        }

        private static object GetInstanceField(Type type, object instance, string fieldName)
        {
            BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
                                     | BindingFlags.Static;
            FieldInfo field = type.GetField(fieldName, bindFlags);
            return field.GetValue(instance);
        }
    }
    
    public interface IFixedExecuteSystem : IExecuteSystem { }
    public interface ILateExecuteSystem : IExecuteSystem { }
}