using UnityEngine;
using Utils;

namespace Presenters.Player
{

    public class PlayerRotatorPresenter
    {
        private readonly Transform _playerGameModelTransform;
        private readonly UnityEngine.Camera _mainCamera;

        public PlayerRotatorPresenter(UnityEngine.Camera mainCamera, Transform playerGameModelTransform)
        {
            InvariantChecker.CheckObjectInvariant( playerGameModelTransform, mainCamera);
            
            _mainCamera = mainCamera;
            _playerGameModelTransform = playerGameModelTransform;
        }
        
        public void TryRotate()
        {
            Plane plane = new Plane(Vector3.up, _playerGameModelTransform.position);
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out var hitDistance))
                _playerGameModelTransform.forward = ray.GetPoint(hitDistance) - _playerGameModelTransform.position;
        }
    }

}