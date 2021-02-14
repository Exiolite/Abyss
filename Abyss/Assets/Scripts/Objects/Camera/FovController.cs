using Events;
using UnityEngine;

namespace Objects.Camera
{
    public class FovController : MonoBehaviour
    {
        [SerializeField] private GameObject cameraHolder;

        [Header("Camera Parameters")]
        [SerializeField] private float minCameraDistance = -80;
        [SerializeField] private float maxCameraDistance = -160;
        
        

        private void Awake()
        {
            GuiEvent.OnZoomSliderChanged.AddListener(OnZoomSliderEvent);
        }


        private void OnZoomSliderEvent(float value)
        {
            var cameraPosZ = Mathf.Clamp((value * maxCameraDistance), maxCameraDistance, minCameraDistance);
            cameraHolder.transform.localPosition = new Vector3(0,0,cameraPosZ);
        }
        
    }
}