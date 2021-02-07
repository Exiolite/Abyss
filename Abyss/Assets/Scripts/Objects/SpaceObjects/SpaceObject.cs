
using Core;
using Core.LevelManaging;
using Objects.NavigationCircle;
using Objects.SpaceObjects.Dynamic;
using UnityEngine;

namespace Objects.SpaceObjects
{
    public abstract class SpaceObject : ObjectBehaviour
    {
        public string ObjName => objName;
        
        
        
        [SerializeField] private string objName;

        
        
        protected override void Initialize()
        {
            NavigationEvent.AddArrow.Invoke(this);
        }
        
        
        
        public void DestroyItSelf()
        {
            Destroy(gameObject);
        }
        
        
        
        private void Awake()
        {
            LevelEvent.DestroyAllExcludePlayer.AddListener(DestroyObject);
        }


        private void DestroyObject(Ship player)
        {
            if (this == player) return;
            NavigationEvent.RemoveArrow.Invoke(this);
            DestroyItSelf();
        }

        private void OnMouseDown()
        {
            LevelManager.InstancedPlayer.SetTarget(this == LevelManager.InstancedPlayer ? null : this);
        }
    }
}