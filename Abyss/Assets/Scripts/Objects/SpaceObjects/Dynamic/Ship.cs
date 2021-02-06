using Modules.HealthStats;
using Modules.Movements;
using Objects.NavigationCircle;
using Objects.Turrets;
using Statics;
using UnityEngine;

namespace Objects.SpaceObjects.Dynamic
{
    public class Ship : SpaceObject
    {
        public int MaxDepth => maxDepth;
        public HealthStats HealthStats => healthStats;
        
        [SerializeField] private int maxDepth;
        [SerializeField] private Movement movement;
        [SerializeField] private TurretBehaviour[] turretBehaviours;
        [SerializeField] private HealthStats healthStats;

        public SpaceObject _target;



        public void ApplyDamage(float value)
        {
            healthStats.TryRemoveShield(value, out var success);
            if (!success)
            {
                healthStats.TryRemoveHitPoints(value, out var haveHp);
                if (!haveHp)
                {
                    NavigationEvent.RemoveArrow.Invoke(this);
                    DestroyItSelf();
                }
            }
        }

        public void SetTarget(SpaceObject target)
        {
            _target = target;
        }
        
        protected override void Execute()
        {
            if (_target == null) return;
            movement.SmoothRotateToTarget(gameObject.transform, _target.transform);
            movement.HardMoveForward(gameObject.transform);
            if (_target.GetType() != typeof(Ship)) return;
            var distanceToTarget = RangeFinder.CalculateDistance(transform, _target);
            if (distanceToTarget > 60) return;
            foreach (var turretBehaviour in turretBehaviours)
            {
                turretBehaviour.SetTarget(_target);
            }
        }
    }
}