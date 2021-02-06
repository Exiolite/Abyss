using Core;
using UnityEngine;

namespace Objects.Camera
{
    public class SmoothCamera : ObjectBehaviour
    {
        [SerializeField] private float smoothSpeed = 3;
        [SerializeField] private Vector3 offset;
        
        
        private void LateUpdate()
        {
            var desiredPosition = LevelManager.InstancedPlayer.transform.position + offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }

        protected override void Initialize()
        {
            
        }

        protected override void Execute()
        {
            
        }
    }
}