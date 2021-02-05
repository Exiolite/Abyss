using Modules.LevelManager;
using UnityEngine.Events;

namespace Core
{
    public class EventCore
    {
        public static CallForDataBase CallForDataBase = new CallForDataBase();
        public static CallBackDataBase CallBackDataBase = new CallBackDataBase();
    }
    public class CallForDataBase : UnityEvent { }
    public class CallBackDataBase : UnityEvent <SpaceObjectsDataBase> { }
}