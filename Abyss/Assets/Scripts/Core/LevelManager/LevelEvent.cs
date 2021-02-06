using Objects.SpaceObjects.Dynamic;
using UnityEngine.Events;

namespace Core.LevelManager
{
    public static class LevelEvent
    {
        public static DestoryAllExcludePlayer DestoryAllExcludePlayer = new DestoryAllExcludePlayer();
    }
    public class DestoryAllExcludePlayer : UnityEvent <Ship> {}
}