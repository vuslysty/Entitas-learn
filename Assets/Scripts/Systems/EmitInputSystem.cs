using Assets.Code.Extensions;
using Entitas;
using Servises;
using UnityEngine;

namespace Systems
{
    public class EmitInputSystem : IExecuteSystem
    {
        private readonly InputContext _inputContext;
        private readonly IGroup<InputEntity> _leftMouse;
        private readonly IGroup<InputEntity> _rightMouse;
        private IInputService Input => _inputContext.input.Value;
        private readonly IGroup<InputEntity> _keyboard;

        public EmitInputSystem(InputContext inputContext)
        {
            _inputContext = inputContext;
            _leftMouse = inputContext.GetGroup(InputMatcher.LeftMouse);
            _rightMouse = inputContext.GetGroup(InputMatcher.RightMouse);
            _keyboard = inputContext.GetGroup(InputMatcher.Keyboard);
        }

        public void Execute()
        {
            Vector2 screenPosition = Input.GetScreenMousePosition();
            Vector2 worldPosition = Input.GetWorldMousePosition();

            foreach (InputEntity leftMouse in _leftMouse)
            {
                leftMouse.isMouseDown = Input.GetLeftMouseButtonDown();
                leftMouse.isMouse = Input.GetLeftMouseButton();
                leftMouse.Do(l => l.ReplaceMouseScreenPosition(screenPosition), leftMouse.isMouse);
                leftMouse.Do(l => l.ReplaceMouseWorldPosition(worldPosition), leftMouse.isMouse);
                leftMouse.isMouseUp = Input.GetLeftMouseButtonUp();
            }

            foreach (InputEntity rightMouse in _rightMouse)
            {
                rightMouse.isMouseDown = Input.GetRightMouseButtonDown();        
                rightMouse.isMouse = Input.GetRightMouseButton();
                rightMouse.Do(r => r.ReplaceMouseScreenPosition(screenPosition), rightMouse.isMouse);
                rightMouse.Do(r => r.ReplaceMouseWorldPosition(worldPosition), rightMouse.isMouse);
                rightMouse.isMouseUp = Input.GetRightMouseButtonUp();
            }
      
            foreach (InputEntity keyboard in _keyboard)
            {
                keyboard.ReplaceVertical(Input.Vertical);
                keyboard.ReplaceHorizontal(Input.Horizontal);
                keyboard.isJump = Input.Jump > 0;
            }
        }
    }
}