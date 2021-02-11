using Objects.SpaceObjects;
using Objects.SpaceObjects.Dynamic;
using Statics;
using UnityEngine;

namespace Core
{
    public class Factory : ObjectBehaviour
    {
        private readonly string _objectPreIndex = "IO";
        private int objectId;
        
        
        
        protected override void Initialize(){}
        protected override void Execute(){}
        
        
        
        public void SpawnObject(GameObject target)
        {
            var spawnedObject = Instantiate(target);
        }

        public void SpawnObjectAtTransform(GameObject target, Transform parentTransform)
        {
            var spawnedObject = Instantiate(target, parentTransform);
        }

        public void SpawnParticlesAtTransform(Ship target, ParticleSystem targetParticles)
        {
            var particles = Instantiate(targetParticles, target.transform);
            target.AddParticles(particles);
        }

        public void SpawnSpaceObject(SpaceObject target)
        {
            var spawnedObject = Instantiate(target);
            SetObjectId(spawnedObject.gameObject);
        }
        
        public void SpawnSpaceObjectAtTransform(SpaceObject target, Transform parentTransform)
        {
            var spawnedObject = Instantiate(target, parentTransform);
            spawnedObject.transform.parent = null;
            SetObjectId(spawnedObject.gameObject);
        }
        
        public void SpawnSpaceObjectAtRange(SpaceObject target)
        {
            var spawnedObject = Instantiate(target);
            SetObjectId(spawnedObject.gameObject);
            spawnedObject.transform.position = Randomizer.GenerateDotOfInterest(120);
        }

        public Ship SpawnPlayer(Ship ship)
        {
            var spawnedObject = Instantiate(ship);
            SetObjectId(spawnedObject.gameObject);
            return spawnedObject;
        }

        public void ResetId(bool isPlayerAlive)
        {
            objectId = isPlayerAlive ? 1 : 0;
        }
        
        
        
        private void SetObjectId(GameObject spawnedObject)
        {
            spawnedObject.name = _objectPreIndex + objectId;
            objectId++;
        }
    }
}