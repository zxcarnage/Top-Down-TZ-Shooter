using Models.PlayerRotation;
using Models.WeaponModel;
using Zenject;

namespace Dummies
{
    public class CommonProjectileView : ProjectileView
    {
        [Inject]
        public override void Initialize(WeaponModel weaponModel)
        {
            base.Initialize(weaponModel);
        }
    }
}