using Core;
using UnityEngine;

namespace Objects.SpaceObjects
{
    public abstract class SpaceObject : ObjectBehaviour
    {
        public string ObjName => objName;
        
        
        
        [SerializeField] private string objName;
        
        
        
        public void DestroyItSelf()
        {
            Destroy(gameObject);
        }
    }
}