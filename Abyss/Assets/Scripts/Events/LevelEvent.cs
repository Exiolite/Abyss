using Objects.SpaceObjects.Dynamic;
using UnityEngine.Events;

namespace Events
{
    public static class LevelEvent
    {
        public static readonly DestroyAllExcludePlayer DestroyAllExcludePlayer = new DestroyAllExcludePlayer();
        public static readonly PlayerDeath PlayerDeath = new PlayerDeath();
        public static readonly RestartGame RestartGame = new RestartGame();
    }
    public class DestroyAllExcludePlayer : UnityEvent <Ship> {}
    public class PlayerDeath : UnityEvent {}
    public class RestartGame : UnityEvent {}
}