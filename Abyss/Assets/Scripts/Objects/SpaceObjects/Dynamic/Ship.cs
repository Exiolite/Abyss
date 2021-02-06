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

        private SpaceObject _target;
        private float _damagedTime;


        public void ApplyDamage(float value)
        {
            _damagedTime = Time.time;
            healthStats.TryApplyDamage(value, out var haveHp);
            if (!haveHp) return;
            NavigationEvent.RemoveArrow.Invoke(this);
            DestroyItSelf();
        }

        public void SetTarget(SpaceObject target)
        {
            _target = target;
        }
        
        protected override void Execute()
        {
            if (Time.time > _damagedTime + 3.0f)healthStats.RegenerateShield();
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