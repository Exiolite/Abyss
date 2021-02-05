using Core;
using Objects.SpaceObjects;
using UnityEngine;

namespace Modules.LevelManager.Factory
{
    public class Factory : MonoBehaviour
    {
        private void SpawnObject(GameObject target)
        {
            Instantiate(target);
        }

        private void SpawnObjectAtTransform(GameObject target, Transform parentTransform)
        {
            Instantiate(target, parentTransform);
        }
        
        
        private void SpawnSpaceObject(SpaceObject target)
        {
            Instantiate(target);
        }
        
        private void SpawnSpaceObjectAtTransform(SpaceObject target, Transform parentTransform)
        {
            Instantiate(target, parentTransform);
        }
    }
}