using Objects.SpaceObjects.Dynamic;
using UnityEngine.Events;

namespace Core.LevelManaging
{
    public static class LevelEvent
    {
        public static readonly DestroyAllExcludePlayer DestroyAllExcludePlayer = new DestroyAllExcludePlayer();
    }
    public class DestroyAllExcludePlayer : UnityEvent <Ship> {}
}