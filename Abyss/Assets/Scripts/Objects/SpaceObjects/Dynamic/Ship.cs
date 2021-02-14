using Events;
using Modules.HealthStats;
using Modules.Movements;
using Objects.NavigationCircle;
using Objects.Turrets;
using Statics;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Objects.SpaceObjects.Dynamic
{
    public class Ship : SpaceObject
    {
        public int MaxDepth => maxDepth;
        public HealthStats HealthStats => healthStats;
        public Movement Movement => movement;
        
        public int ShipPriceCredits => shipPriceCredits;
        public int ShipPriceMaterials => shipPriceMaterials;
        
        
        //SpaceObject attributes
        [SerializeField] private int maxDepth;
        [SerializeField] private Turret[] turretBehaviours;
        
        //Modules
        [SerializeField] private Movement movement;
        
        //Pricing
        [SerializeField] private int shipPriceCredits;
        [SerializeField] private int shipPriceMaterials;
        
        //HealthStats
        [SerializeField] private HealthStats healthStats;
        private float _damagedTime;
        
        //Particles
        private readonly ParticlesPlayer _particlesPlayer = new ParticlesPlayer();
        private ParticleSystem _shieldParticles;
        
        //Targeting
        private SpaceObject _target;

        
        
        public void SetTarget(SpaceObject target)
        {
            _target = target;
        }
        
        public void AddParticles(ParticleSystem shieldParticles)
        {
            _shieldParticles = shieldParticles;
        }
        
        public void ApplyDamage(float value)
        {
            _particlesPlayer.PlayShieldDamage(_shieldParticles);
            _damagedTime = Time.time;
            healthStats.TryApplyDamage(value, out var haveHp);
            if (!haveHp) return;
            NavigationEvent.RemoveArrow.Invoke(this);
            LevelManager.SpawnSmallContainer(transform);
            if (this == LevelManager.InstancedPlayer)
            {    
                if (Advertisement.IsReady())
                {
                    Advertisement.Show();
                }
                PlayersAccount.OnShipAccountResources.ResetCredits();
                PlayersAccount.OnShipAccountResources.ResetMaterials();
                LevelEvent.PlayerDeath.Invoke();
            }
            DestroyItSelf();
        }
        
        
        
        protected override void Initialize()
        {
            base.Initialize();
            LevelManager.AddShieldParticle(this);
        }
        
        protected override void Execute()
        {
            UpdateBehaviour();
        }


        
        private void UpdateBehaviour()
        {
            if (Time.time > _damagedTime + 1.0f)
            {
                healthStats.RegenerateShield();
            }
            movement.MoveShipToTarget(transform, _target);
            
            if (_target == null) return;
            
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