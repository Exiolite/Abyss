using Objects.SpaceObjects;
using UnityEngine;

namespace Objects.Turrets.ProjectileShooting
{
    public class MultiCannon : Turret
    {
        //TurretAttributes
        [SerializeField] private Projectile projectile;
        
        
        
        protected override void AttackTarget(SpaceObject target)
        {
            var projectile = Instantiate(this.projectile, transform);
            projectile.SetTarget(target);
            projectile.transform.parent = null;
        }
    }
}