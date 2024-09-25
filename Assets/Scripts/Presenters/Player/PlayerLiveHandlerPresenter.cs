using DefaultNamespace.Models.Health;
using UnityEngine.SceneManagement;
using Utils;

namespace Presenters.Player
{
    public class PlayerLiveHandlerPresenter
    {
        private readonly HealthModel _healthModel;

        public PlayerLiveHandlerPresenter(HealthModel healthModel)
        {
            InvariantChecker.CheckObjectInvariant<PlayerLiveHandlerPresenter>(healthModel);

            _healthModel = healthModel;
        }

        public void Enable()
        {
            _healthModel.Died += OnPlayerDied;
        }

        private void OnPlayerDied()
        {
            ShowDeathScreen();
        }

        private static void ShowDeathScreen()
        {
            SceneManager.LoadScene(1);
        }

        public void Disable()
        {
            _healthModel.Died -= OnPlayerDied;
        }
    }
}