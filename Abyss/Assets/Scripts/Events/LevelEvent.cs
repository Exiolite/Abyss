using Objects.SpaceObjects.Dynamic;
using UnityEngine.Events;

namespace Events
{
    public static class LevelEvent
    {
        public static readonly DestroyAllExcludePlayer DestroyAllExcludePlayer = new DestroyAllExcludePlayer();
        public static readonly PlayerDeath PlayerDeath = new PlayerDeath();
    }
    public class DestroyAllExcludePlayer : UnityEvent <Ship> {}
    public class PlayerDeath : UnityEvent {}
}