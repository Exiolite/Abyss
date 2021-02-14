using UnityEngine.Events;

namespace Events
{
    public static class GuiEvent
    {
        public static UpdateNavCircleResources UpdateNavCircleResources = new UpdateNavCircleResources();
        public static readonly OnZoomSliderChanged OnZoomSliderChanged = new OnZoomSliderChanged();
    }
    public class UpdateNavCircleResources : UnityEvent {}
    public class OnZoomSliderChanged : UnityEvent <float> {}
}