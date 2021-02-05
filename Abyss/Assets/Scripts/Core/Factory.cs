using Objects.SpaceObjects;
using Statics;
using UnityEngine;

namespace Core
{
    public class Factory : MonoBehaviour
    {
        public void SpawnObject(GameObject target)
        {
            Instantiate(target);
        }

        public void SpawnObjectAtTransform(GameObject target, Transform parentTransform)
        {
            Instantiate(target, parentTransform);
        }
        
        
        public void SpawnSpaceObject(SpaceObject target)
        {
            Instantiate(target);
        }
        
        public void SpawnSpaceObjectAtTransform(SpaceObject target, Transform parentTransform)
        {
            Instantiate(target, parentTransform);
        }
        
        public void SpawnSpaceObjectAtRange(SpaceObject target)
        {
            var spaceObject = Instantiate(target);
            spaceObject.transform.position = Randomizer.GenerateDotOfInterest(60);
        }
    }
}