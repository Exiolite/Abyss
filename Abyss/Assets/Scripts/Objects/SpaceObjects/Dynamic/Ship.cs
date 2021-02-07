
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

        [SerializeField] private ParticleSystem explosionParticles;
        [SerializeField] private int maxDepth;
        [SerializeField] private Movement movement;
        [SerializeField] private TurretBehaviour[] turretBehaviours;
        [SerializeField] private HealthStats healthStats;

        private SpaceObject _target;
        private float _damagedTime;


        public void ApplyDamage(float value)
        {
            explosionParticles.transform.localPosition = new Vector3(Random.Range(-1.5f,1.5f),Random.Range(-1.5f,1.5f), 0);
            explosionParticles.Play();
            _damagedTime = Time.time;
            healthStats.TryApplyDamage(value, out var haveHp);
            if (!haveHp) return;
            NavigationEvent.RemoveArrow.Invoke(this);
            LevelManager.SpawnSmallContainer(transform);
            DestroyItSelf();
        }

        public void SetTarget(SpaceObject target)
        {
            _target = target;
        }
        
        protected override void Execute()
        {
            movement.SmoothMoveForvard(gameObject.transform, _target != null);
            if (Time.time > _damagedTime + 3.0f)healthStats.RegenerateShield();
            if (_target == null) return;
            movement.SmoothRotateToTarget(gameObject.transform, _target.transform);
            if (_target.GetType() != typeof(Ship)) return;
            var distanceToTarget = RangeFinder.CalculateDistance(transform, _target);
            if (distanceToTarget > 60) return;
            foreach (var turretBehaviour in turretBehaviours)
            {
                turretBehaviour.SetTarget(_target);
            }
        }

        private void MoveToTarget()
        {
            if (_target.GetType() == typeof(Ship))
            {
                movement.SmoothMoveForvard(gameObject.transform, true);
            }
            else
            {
                if (RangeFinder.CalculateDistance(transform, _target)>10)
                {
                    movement.SmoothMoveForvard(gameObject.transform, true);
                }
                else
                {
                    if (RangeFinder.CalculateDistance(transform, _target)<1)
                    {
                        
                    }
                    else
                    {
                        movement.SmoothMoveForvard(gameObject.transform, false);
                    }
                }
            }
        }
    }
}