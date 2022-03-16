using System;
using UnityEngine;

namespace Game
{
    public class GameControllerBehaviour : MonoBehaviour
    {
        private GameController _gameController;

        private void Awake()
        {
            Contexts.sharedInstance.SubscribeId();
        }

        private void Start()
        {
            _gameController = new GameController(Contexts.sharedInstance);
            _gameController.Initialize();
        }

        private void Update()
        {
            _gameController.Execute();
        }

        private void OnDestroy()
        {
            _gameController.Destroy();
        }
    }
}