using Core;
using Objects.SpaceObjects;
using UnityEngine;

namespace Modules.LevelManager.Factory
{
    public class Factory : ObjectBehaviour
    {
        protected override void Execute(){}
        protected override void Initialize()
        {
            #region AddListeners

            EventFactory.SpawnObject.AddListener(SpawnObject);
            EventFactory.SpawnObjectAtTransform.AddListener(SpawnObjectAtTransform);
            EventFactory.SpawnSpaceObject.AddListener(SpawnSpaceObject);
            EventFactory.SpawnSpaceObjectAtTransform.AddListener(SpawnSpaceObjectAtTransform);
            
            #endregion
        }


        #region Listeners

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

        #endregion

    }
}