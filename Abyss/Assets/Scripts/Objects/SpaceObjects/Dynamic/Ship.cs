using Modules.HealthStats;
using Modules.Movements;
using Objects.Turrets;
using UnityEngine;

namespace Objects.SpaceObjects.Dynamic
{
    public class Ship : SpaceObject
    {
        [SerializeField] private Movement movement;
        [SerializeField] private TurretBehaviour[] turretBehaviours;
        [SerializeField] private HealthStats healthStats;

        public SpaceObject target;



        public void ApplyDamage(float value)
        {
            healthStats.TryRemoveShield(value, out var success);
            if (!success)
            {
                healthStats.TryRemoveHitPoints(value, out var haveHp);
                if (!haveHp) DestroyItSelf();
            }

            
        }

        protected override void Initialize()
        {
            
        }

        protected override void Execute()
        {
            if (target == null) return;
            movement.SmoothRotateToTarget(gameObject.transform, target.transform);
            movement.MoveShipForward(gameObject.transform);
            foreach (var turretBehaviour in turretBehaviours)
            {
                turretBehaviour.SetTarget(target);
            }
        }
    }
}