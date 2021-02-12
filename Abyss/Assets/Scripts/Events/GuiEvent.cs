using UnityEngine.Events;

namespace Events
{
    public static class GuiEvent
    {
        public static UpdateNavCircleResources UpdateNavCircleResources = new UpdateNavCircleResources();
    }
    public class UpdateNavCircleResources : UnityEvent {}
}