using Objects.SpaceObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Modules.LevelManager.Factory
{
    public static class EventFactory
    {
        public static readonly SpawnObject SpawnObject = new SpawnObject();
        public static readonly SpawnObjectAtTransform SpawnObjectAtTransform = new SpawnObjectAtTransform();
        public static readonly SpawnSpaceObject SpawnSpaceObject = new SpawnSpaceObject();
        public static readonly SpawnSpaceObjectAtTransform SpawnSpaceObjectAtTransform = new SpawnSpaceObjectAtTransform();
    }
    
    public class SpawnObject : UnityEvent <GameObject> {}
    public class SpawnObjectAtTransform : UnityEvent <GameObject,Transform> {}
    public class SpawnSpaceObject : UnityEvent <SpaceObject> {}
    public class SpawnSpaceObjectAtTransform : UnityEvent <SpaceObject, Transform> {}
}