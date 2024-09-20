using System;
using Presenters.Player;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Views.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerRotatorView : MonoBehaviour
    {
        private PlayerRotatorPresenter _presenter;

        [Inject]
        public void Initialize(UnityEngine.Camera mainCamera, Transform playerModelTransform)
        {
            _presenter = new PlayerRotatorPresenter(mainCamera, playerModelTransform);
        }

        private void FixedUpdate()
        {
            _presenter.TryRotate();
        }
    }
}