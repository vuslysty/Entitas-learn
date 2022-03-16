using Assets.Code.ViewComponentRegistrators;
using UnityEngine;

namespace View
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour, IViewComponentRegistrator
    {
        private static readonly int _speedHashFloat = Animator.StringToHash("Speed");
        
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetNormalizedSpeed(float speed)
        {
            speed = Mathf.Clamp01(speed);
            
            _animator.SetFloat(_speedHashFloat, speed);
        }
        
        public void Register(GameEntity entity)
        {
            entity.AddPlayerAnimator(this);
        }
    }
}