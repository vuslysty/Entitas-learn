using System;
using DefaultNamespace.Systems;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameController : MonoBehaviour
    {
        private RootSystems _systems;

        private void Start()
        {
            _systems = new RootSystems(Contexts.sharedInstance);
            
            _systems.Initialize();
        }

        private void Update()
        {
            _systems.Execute();
        }
    }
}