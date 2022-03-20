using Entitas;
using Extensions;
using Services.Interfaces;
using UnityEngine;

namespace Systems.Input
{
    public class EmitInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;

        private readonly IGroup<InputEntity> _leftMouse;
        private readonly IGroup<InputEntity> _rightMouse;
        private readonly IGroup<InputEntity> _keyboard;

        public EmitInputSystem(InputContext inputContext, IInputService inputService)
        {
            _inputService = inputService;
            _leftMouse = inputContext.GetGroup(InputMatcher.LeftMouse);
            _rightMouse = inputContext.GetGroup(InputMatcher.RightMouse);
            _keyboard = inputContext.GetGroup(InputMatcher.Keyboard);
        }

        public void Execute()
        {
            Vector2 screenPosition = _inputService.GetScreenMousePosition();
            Vector2 worldPosition = _inputService.GetWorldMousePosition();

            foreach (InputEntity leftMouse in _leftMouse)
            {
                leftMouse.isMouseDown = _inputService.GetLeftMouseButtonDown();
                leftMouse.isMouse = _inputService.GetLeftMouseButton();
                leftMouse.Do(l => l.ReplaceMouseScreenPosition(screenPosition), leftMouse.isMouse);
                leftMouse.Do(l => l.ReplaceMouseWorldPosition(worldPosition), leftMouse.isMouse);
                leftMouse.isMouseUp = _inputService.GetLeftMouseButtonUp();
            }

            foreach (InputEntity rightMouse in _rightMouse)
            {
                rightMouse.isMouseDown = _inputService.GetRightMouseButtonDown();        
                rightMouse.isMouse = _inputService.GetRightMouseButton();
                rightMouse.Do(r => r.ReplaceMouseScreenPosition(screenPosition), rightMouse.isMouse);
                rightMouse.Do(r => r.ReplaceMouseWorldPosition(worldPosition), rightMouse.isMouse);
                rightMouse.isMouseUp = _inputService.GetRightMouseButtonUp();
            }
      
            foreach (InputEntity keyboard in _keyboard)
            {
                keyboard.ReplaceVertical(_inputService.Vertical);
                keyboard.ReplaceHorizontal(_inputService.Horizontal);
                keyboard.isJump = _inputService.Jump > 0;
            }
        }
    }
}