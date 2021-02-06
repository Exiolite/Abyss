using Modules.HealthStats;
using Modules.Movements;
using Objects.Turrets;
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

        private SpaceObject _target;



        public void ApplyDamage(float value)
        {
            healthStats.TryRemoveShield(value, out var success);
            if (!success)
            {
                healthStats.TryRemoveHitPoints(value, out var haveHp);
                if (!haveHp) DestroyItSelf();
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
            movement.MoveShipForward(gameObject.transform);
            if (_target.GetType() != typeof(Ship)) return;
            foreach (var turretBehaviour in turretBehaviours)
            {
                turretBehaviour.SetTarget(_target);
            }
        }
    }
}