using System;
using Models.MovementModel;
using Presenters.Player;
using UnityEngine;
using Zenject;

namespace Views.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimatorView : MonoBehaviour
    {
        private PlayerAnimatorPresenter _presenter;

        [Inject]
        public void Initialize(Animator animator, MovementModel movementModel, Transform playerModelTransform)
        {
            _presenter = new PlayerAnimatorPresenter(animator, movementModel, playerModelTransform);
        }

        private void Update()
        {
            _presenter.Animate();
        }
    }
}