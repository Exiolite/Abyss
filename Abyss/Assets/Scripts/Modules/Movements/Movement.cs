using UnityEngine;

namespace Modules.Movements
{
    [System.Serializable]
    public class Movement
    {
        [SerializeField] private float speed;
        [SerializeField] private float angleSpeed;
        
        
        
        public void HardRotateToTarget(Transform transform, Transform target)
        {
            var deirectionToTarget = target.transform.position - transform.position;
            var angleToTarget = Mathf.Atan2(deirectionToTarget.y, deirectionToTarget.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angleToTarget);
        }
        
        public void SmoothRotateToTarget(Transform transform, Transform target)
        {
            var deirectionToTarget = target.transform.position - transform.position;
            var angleToTarget = Mathf.Atan2(deirectionToTarget.y, deirectionToTarget.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0,0, angleToTarget);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * angleSpeed / 10);
        }
        
        public void HardMoveForward(Transform transform)
        {
            transform.position += transform.right * (Time.deltaTime * speed);
        }

        public void HardMoveRandomSpeed(Transform transform)
        {
            transform.position += transform.right * (Time.deltaTime * Random.Range(speed-Random.Range(0,50),speed+Random.Range(0,50)));
        }
    }
}