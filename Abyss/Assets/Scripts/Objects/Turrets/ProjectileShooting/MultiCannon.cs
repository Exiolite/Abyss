using Objects.SpaceObjects;
using UnityEngine;

namespace Objects.Turrets.ProjectileShooting
{
    public class MultiCannon : TurretBehaviour
    {
        [SerializeField] private ProjectileBehaviour projectileBehaviour;
        
        protected override void AttackTarget(SpaceObject target)
        {
            var projectile = Instantiate(projectileBehaviour, transform);
            projectile.SetTarget(target);
            projectile.transform.parent = null;
        }
    }
}