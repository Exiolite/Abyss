using Objects.SpaceObjects;
using Statics;
using UnityEngine;

namespace Modules.Movements
{
    [System.Serializable]
    public class Movement
    {
        //Movement attributes
        [SerializeField] private float velocity;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float angleSpeed;
        private float _speed;



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
            transform.position += transform.right * (Time.deltaTime * maxSpeed);
        }

        public void SmoothMoveForvard(Transform transform, bool flag)
        {
            if (flag) _speed = Mathf.Clamp(_speed + (velocity * Time.deltaTime), 0, maxSpeed);
            else _speed = Mathf.Clamp(_speed - (velocity * Time.deltaTime), 0, maxSpeed);
            transform.position += transform.right * (Time.deltaTime * _speed);
        }

        public void HardMoveRandomSpeed(Transform transform)
        {
            transform.position += transform.right * (Time.deltaTime * Random.Range(maxSpeed-Random.Range(0,50),maxSpeed+Random.Range(0,50)));
        }
        
        public void MicroWarp(Transform transform, SpaceObject target)
        {
            transform.position += transform.right * (RangeFinder.CalculateDistance(transform, target)-50);
        }
    }
}