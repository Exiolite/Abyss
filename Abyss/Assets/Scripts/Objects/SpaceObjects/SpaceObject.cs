using Core;
using Core.LevelManaging;
using Events;
using Objects.NavigationCircle;
using Objects.SpaceObjects.Dynamic;
using UnityEngine;

namespace Objects.SpaceObjects
{
    public abstract class SpaceObject : ObjectBehaviour
    {
        public string ObjName => objName;
        

        [SerializeField] private string objName;
        
        
        
        public void DestroyItSelf()
        {
            NavigationEvent.RemoveArrow.Invoke(this);
            Destroy(gameObject);
        }
        
        
        
        protected override void Initialize()
        {
            if (this is Ship)
            {
                var ship = (Ship)this;
                if (ship.ShipPriceCredits == 0) NavigationEvent.AddArrow.Invoke(this);
            }
            else
            {
                NavigationEvent.AddArrow.Invoke(this);
            }
        }
        
        
        
        private void OnMouseDown()
        {
            LevelManager.InstancedPlayer.SetTarget(this == LevelManager.InstancedPlayer ? null : this);
        }
        
        private void Awake()
        {
            LevelEvent.DestroyAllExcludePlayer.AddListener(DestroyObject);
        }
        
        private void DestroyObject(Ship player)
        {
            if (this == player) return;
            DestroyItSelf();
            
        }
    }
}