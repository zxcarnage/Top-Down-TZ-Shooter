using DefaultNamespace.Models.Health;
using Zenject;

namespace Views.UI.Healthbar
{
    public class EntityHealthbarView : HealthbarView
    {
        [Inject]
        public override void Initialize(HealthModel healthModel)
        {
            base.Initialize(healthModel);
        }
    }
}