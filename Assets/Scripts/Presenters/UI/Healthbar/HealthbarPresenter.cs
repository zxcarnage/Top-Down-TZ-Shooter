using DefaultNamespace.Models.Health;
using Utils;
using Views.UI.Healthbar;

namespace Presenters.UI.Healthbar
{
    public class HealthbarPresenter
    {
        private readonly HealthModel _model;
        private readonly HealthbarView _view;
        
        public HealthbarPresenter(HealthModel model, HealthbarView view)
        {
            InvariantChecker.CheckObjectInvariant<HealthbarPresenter>(model, view);
            
            _model = model;
            _view = view;
        }
        

        public void Enable()
        {
            _model.HealthChanged += ChangeHealthbarValue;
        }

        public void Disable()
        {
            _model.HealthChanged -= ChangeHealthbarValue;
        }

        private void ChangeHealthbarValue(float value)
        {
            _view.ChangeVisual(value);
        }
    }
}