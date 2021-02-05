using Modules.Movements;
using UnityEngine;

namespace Objects.SpaceObjects.Dynamic
{
    public class Ship : SpaceObject
    {
        [SerializeField] private Movement movement;
        
        public SpaceObject target;


        protected override void Initialize()
        {
            
        }

        protected override void Execute()
        {
            if (target == null) return;
            movement.SmoothRotateToTarget(gameObject.transform, target.transform);
            movement.MoveShipForward(gameObject.transform);
        }
    }
}