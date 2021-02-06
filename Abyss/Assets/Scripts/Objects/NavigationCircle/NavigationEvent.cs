using Objects.SpaceObjects;
using UnityEngine.Events;

namespace Objects.NavigationCircle
{
    public static class NavigationEvent
    {
        public static AddArrow AddArrow = new AddArrow();
        public static RemoveArrow RemoveArrow = new RemoveArrow();
    }
    public class AddArrow : UnityEvent <SpaceObject> {}
    public class RemoveArrow : UnityEvent <SpaceObject> {}
}