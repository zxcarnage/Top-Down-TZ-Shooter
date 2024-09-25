using DefaultNamespace.Models.Health;
using TMPro;
using UnityEngine;
using Views.UI.Healthbar;
using Zenject;

namespace Views.UI
{
    public class PlayerHealthbarView : HealthbarView
    {
        [SerializeField] private TMP_Text _healthText;

        [Inject]
        public override void Initialize(HealthModel playerHealthModel)
        {
            base.Initialize(playerHealthModel);
        }

        public override void ChangeVisual(float value)
        {
            base.ChangeVisual(value);
            _healthText.text = value.ToString();
        }
    }
}