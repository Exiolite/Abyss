using Objects.SpaceObjects;
using UnityEngine;

namespace Objects.Turrets.ProjectileShooting
{
    public class MultiCannon : Turret
    {
        //TurretAttributes
        [SerializeField] private Projectile _projectile;
        
        
        
        protected override void AttackTarget(SpaceObject target)
        {
            var projectile = Instantiate(this._projectile, transform);
            projectile.SetTarget(target);
        }
    }
}