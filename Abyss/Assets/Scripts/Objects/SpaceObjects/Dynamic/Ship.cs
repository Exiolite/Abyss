using Modules.Movements;
using Objects.Turrets;
using UnityEngine;

namespace Objects.SpaceObjects.Dynamic
{
    public class Ship : SpaceObject
    {
        [SerializeField] private Movement movement;
        [SerializeField] private TurretBehaviour[] turretBehaviours;

        public SpaceObject target;



        public void ApplyDamage(float value)
        {
            
            
            //DestroyItSelf();
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