using UnityEngine;

namespace Objects.Camera
{
    public class SmoothCamera : MonoBehaviour
    {
        [SerializeField] private float smoothSpeed = 3;
        [SerializeField] private Vector3 offset;
        
        
        /*private void LateUpdate()
        {
            var desiredPosition = Core.Core.Instance.GetPlayer().transform.position + offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            smoothedPosition.z = -100;
            transform.position = smoothedPosition;
        }*/
    }
}