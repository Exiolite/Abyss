using Objects.SpaceObjects;
using Objects.SpaceObjects.Dynamic;
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

        public float GetSpeed()
        {
            return _speed * Time.deltaTime;
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
        
        public void HardMoveForwardWithCurrentSpeed(Transform transform)
        {
            transform.position += transform.right * (Time.deltaTime * _speed);
        }

        public void HardMoveForwardWithMinSpeed(Transform transform)
        {
            transform.position += transform.right * (Time.deltaTime * 1);
        }

        public void SmoothMoveForward(Transform transform, bool flag)
        {
            if (flag)
            {
                _speed = Mathf.Clamp(_speed + (velocity * Time.deltaTime), 0, maxSpeed);
            }
            else
            {
                _speed = Mathf.Clamp(_speed - (_speed * Time.deltaTime), 0, maxSpeed);
            }
            transform.position += transform.right * (Time.deltaTime * _speed);
        }

        public void MoveSlowDownToMinSpeed(Transform transform)
        {
            _speed = Mathf.Clamp(_speed - (_speed * Time.deltaTime), 2, maxSpeed);
            transform.position += transform.right * (Time.deltaTime * _speed);
        }

        public void MoveShipToTarget(Transform transform, SpaceObject target)
        {
            if (target == null)
            {
                SmoothMoveForward(transform, false);
                return;
            }
            SmoothRotateToTarget(transform, target.transform);
            if (target.GetType() == typeof(Ship))
            {
                SmoothMoveForward(transform, true);
            }
            else
            {
                if (RangeFinder.CalculateDistance(transform, target)>20)
                {
                    SmoothMoveForward(transform, true);
                }
                else
                {
                    if (RangeFinder.CalculateDistance(transform, target) < 1)
                    {
                        _speed = 0;
                    }
                    else
                    {
                        MoveSlowDownToMinSpeed(transform);
                    }
                }
            }
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