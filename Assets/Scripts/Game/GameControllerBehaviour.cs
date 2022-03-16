using UnityEngine;

namespace Game
{
    public class GameControllerBehaviour : MonoBehaviour
    {
        private GameController _gameController;

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