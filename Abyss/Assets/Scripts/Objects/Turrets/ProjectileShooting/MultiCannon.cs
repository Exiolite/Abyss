using UnityEngine;

namespace Objects.Turrets.ProjectileShooting
{
    public class MultiCannon : TurretBehaviour
    {
        [SerializeField] private ProjectileBehaviour projectileBehaviour;
        
        protected override void AttackTarget()
        {
            if (Target == null) return;
            var projectile = Instantiate(projectileBehaviour, transform);
            projectile.SetTarget(Target);
            projectile.transform.parent = null;
        }
    }
}